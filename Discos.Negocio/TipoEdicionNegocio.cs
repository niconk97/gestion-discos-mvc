using Discos.Dominio;

namespace Discos.Negocio;

public class TipoEdicionNegocio
{
    private readonly IAccesoDatos accesoDatos;

    public TipoEdicionNegocio(IAccesoDatos accesoDatos)
    {
        this.accesoDatos = accesoDatos;
    }

    public List<TipoEdicion> listar()
    {
        List<TipoEdicion> lista = new List<TipoEdicion>();

        try
        {
            accesoDatos.setearConsulta("Select Id, Descripcion From TIPOSEDICION");
            accesoDatos.ejecutarLectura();

            while (accesoDatos.Lector.Read())
            {
                TipoEdicion aux = new TipoEdicion
                {
                    Id = Convert.ToInt32(accesoDatos.Lector["Id"]),
                    Descripcion = Convert.ToString(accesoDatos.Lector["Descripcion"]) ?? string.Empty
                };

                lista.Add(aux);
            }

            return lista;
        }
        catch
        {
            throw;
        }
        finally
        {
            accesoDatos.Dispose();
        }
    }
}