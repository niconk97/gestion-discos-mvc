namespace Discos.Negocio;

using System;
using System.Data;
using Microsoft.Data.Sqlite;

public class AccesoDatosSQLITE : IAccesoDatos
{
    private static string CadenaConexion
    {
        get
        {
            // Opción 1 (PRIORIDAD): Subir un nivel y buscar en Discos.Negocio/script_db
            var rutaNegocio = Path.Combine(Directory.GetCurrentDirectory(), "..", "Discos.Negocio", "script_db", "discos.db");
            if (File.Exists(rutaNegocio))
                return $"Data Source={Path.GetFullPath(rutaNegocio)}";

            // Opción 2: En script_db dentro del directorio actual
            var rutaScriptDb = Path.Combine(Directory.GetCurrentDirectory(), "script_db", "discos.db");
            if (File.Exists(rutaScriptDb))
                return $"Data Source={rutaScriptDb}";

            // Opción 3: En el directorio actual (Discos.Web cuando corre la app)
            var rutaActual = Path.Combine(Directory.GetCurrentDirectory(), "discos.db");
            if (File.Exists(rutaActual))
                return $"Data Source={rutaActual}";

            // Si no encuentra, usa ruta relativa (se creará si no existe)
            return "Data Source=discos.db";
        }
    }

    private readonly SqliteConnection conexion;
    private readonly SqliteCommand comando;
    private SqliteDataReader? lector;

    public IDataReader Lector
    {
        get
        {
            if (lector is null)
                throw new InvalidOperationException("No hay un lector activo.");

            return lector;
        }
    }

    public AccesoDatosSQLITE()
    {
        conexion = new SqliteConnection(CadenaConexion);
        comando = new SqliteCommand();
    }

    public void setearConsulta(string consulta)
    {
        comando.Parameters.Clear();
        comando.CommandType = CommandType.Text;
        comando.CommandText = consulta;
    }

    public void ejecutarLectura()
    {
        comando.Connection = conexion;
        conexion.Open();
        lector = comando.ExecuteReader();
    }

    public void ejecutarAccion()
    {
        comando.Connection = conexion;
        conexion.Open();
        comando.ExecuteNonQuery();
    }

    public int ejecutarAccionScalar()
    {
        comando.Connection = conexion;
        conexion.Open();
        var result = comando.ExecuteScalar();
        return Convert.ToInt32(result);
    }

    public void setearParametro(string nombre, object valor)
    {
        comando.Parameters.AddWithValue(nombre, valor ?? DBNull.Value);
    }

    public void cerrarConexion()
    {
        if (lector is not null)
        {
            lector.Close();
            lector = null;
        }

        if (conexion.State == ConnectionState.Open)
            conexion.Close();
    }

    public void Dispose()
    {
        cerrarConexion();
        comando.Dispose();
        conexion.Dispose();
    }

    public void setearProcedimiento(string sp)
    {
        throw new NotImplementedException("SQLite no soporta procedimientos almacenados. Use setearConsulta en su lugar.");
    }
}