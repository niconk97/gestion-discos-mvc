using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace Discos.Negocio;

public class AccesoDatosSQLServer : IAccesoDatos
{
    private readonly SqlConnection conexion;
    private readonly SqlCommand comando;
    private SqlDataReader? lector;

    private const string CadenaConexion = "Server=.\\SQLEXPRESS;Database=DISCOS_DB;Integrated Security=True;TrustServerCertificate=True";

    public IDataReader Lector
    {
        get
        {
            if (lector is null)
                throw new InvalidOperationException("No hay un lector activo.");

            return lector;
        }
    }

    public AccesoDatosSQLServer()
    {
        conexion = new SqlConnection(CadenaConexion);
        comando = new SqlCommand();
    }

    public void setearConsulta(string consulta)
    {
        comando.Parameters.Clear();
        comando.CommandType = CommandType.Text;
        comando.CommandText = consulta;
    }

    public void setearProcedimiento(string sp)
    {
        comando.Parameters.Clear();
        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = sp;
    }

    public void ejecutarLectura()
    {
        comando.Connection = conexion;
        try
        {
            conexion.Open();
            lector = comando.ExecuteReader();
        }
        catch
        {
            throw;
        }
    }

    public void ejecutarAccion()
    {
        comando.Connection = conexion;
        try
        {
            conexion.Open();
            comando.ExecuteNonQuery();
        }
        catch
        {
            throw;
        }
    }

    public int ejecutarAccionScalar()
    {
        comando.Connection = conexion;
        try
        {
            conexion.Open();
            var result = comando.ExecuteScalar();
            return Convert.ToInt32(result);
        }
        catch
        {
            throw;
        }
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
}