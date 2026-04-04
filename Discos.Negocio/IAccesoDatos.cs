using System.Data;

namespace Discos.Negocio;

public interface IAccesoDatos : IDisposable
{
    IDataReader Lector { get; }
    void setearConsulta(string consulta);
    void setearProcedimiento(string sp);
    void ejecutarLectura();
    void ejecutarAccion();

    int ejecutarAccionScalar();

    void setearParametro(string nombre, object valor);

    void cerrarConexion();

}