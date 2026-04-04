using Discos.Dominio;

namespace Discos.Negocio;

public class EstiloNegocio
{
    private readonly IAccesoDatos accesoDatos;

    public EstiloNegocio(IAccesoDatos accesoDatos)
    {
        this.accesoDatos = accesoDatos;
    }

    public List<Estilo> listar()
    {
        List<Estilo> lista = new List<Estilo>();

        try
        {
            accesoDatos.setearConsulta("Select Id, Descripcion From ESTILOS");
            accesoDatos.ejecutarLectura();

            while (accesoDatos.Lector.Read())
            {
                Estilo aux = new Estilo
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