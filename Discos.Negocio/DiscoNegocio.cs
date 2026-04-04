namespace Discos.Negocio;
using System;
using System.Data;
using Discos.Dominio;

public class DiscoNegocio
{
    private readonly IAccesoDatos accesoDatos;

    public DiscoNegocio(IAccesoDatos accesoDatos)
    {
        this.accesoDatos = accesoDatos;
    }

    public List<Disco> listar()
    {
        List<Disco> lista = new List<Disco>();

        try
        {               
            accesoDatos.setearConsulta("select D.Id, Titulo, FechaLanzamiento, CantidadCanciones, " +
                "UrlImagenTapa,IdEstilo, E.Descripcion Estilo, IdTipoEdicion, " +
                "TE.Descripcion TipoEdicion " +
                "From DISCOS D " +
                "inner join ESTILOS E On D.IdEstilo = E.Id " +
                "inner join TIPOSEDICION TE on D.IdTipoEdicion = TE.Id");

            accesoDatos.ejecutarLectura();

            while (accesoDatos.Lector.Read())
            {
                Disco aux = new Disco();
                aux.Id = Convert.ToInt32(accesoDatos.Lector["Id"]);
                aux.Titulo = Convert.ToString(accesoDatos.Lector["Titulo"]) ?? string.Empty;
                aux.FechaLanzamiento = accesoDatos.Lector["FechaLanzamiento"] is DBNull
                    ? DateTime.MinValue // esto es para evitar errores si el campo es null en la base de datos, el dato queda como 01/01/0001
                    : Convert.ToDateTime(accesoDatos.Lector["FechaLanzamiento"]);
                aux.CantidadCanciones = Convert.ToInt32(accesoDatos.Lector["CantidadCanciones"]);
                if (!(accesoDatos.Lector["UrlImagenTapa"] is DBNull))
                    aux.UrlTapa = Convert.ToString(accesoDatos.Lector["UrlImagenTapa"]) ?? string.Empty;

                aux.TipoEdicion = new TipoEdicion();
                aux.TipoEdicion.Id = Convert.ToInt32(accesoDatos.Lector["IdTipoEdicion"]);
                aux.TipoEdicion.Descripcion = Convert.ToString(accesoDatos.Lector["TipoEdicion"]) ?? string.Empty;
                aux.Estilo = new Estilo();
                aux.Estilo.Id = Convert.ToInt32(accesoDatos.Lector["IdEstilo"]);
                aux.Estilo.Descripcion = Convert.ToString(accesoDatos.Lector["Estilo"]) ?? string.Empty;

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
    
    public void agregar(Disco nuevo)
    {
        try
        {
            accesoDatos.setearConsulta("Insert into DISCOS " +
                "(Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, IdEstilo, IdTipoEdicion)" +
                "values(@titulo, @fechaLanzamiento, @cantidadCanciones, @urlImagenTapa, @idEstilo, @idTipoEdicion)");
            accesoDatos.setearParametro("@titulo", nuevo.Titulo);
            accesoDatos.setearParametro("@fechaLanzamiento", nuevo.FechaLanzamiento);
            accesoDatos.setearParametro("@cantidadCanciones", nuevo.CantidadCanciones);
            accesoDatos.setearParametro("@urlImagenTapa", nuevo.UrlTapa);
            accesoDatos.setearParametro("@idEstilo", nuevo.Estilo.Id);
            accesoDatos.setearParametro("@idTipoEdicion", nuevo.TipoEdicion.Id);
            accesoDatos.ejecutarAccion();
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


    public void modificar(Disco disco)
    {
        try
        {
            accesoDatos.setearConsulta("update DISCOS set Titulo = @titulo, FechaLanzamiento = @fechaLanzamiento, " +
                "CantidadCanciones = @cantidadCanciones, UrlImagenTapa = @urlImagen, " +
                "IdEstilo = @idEstilo, IdTipoEdicion = @idTipoEdicion Where Id = @id");
            accesoDatos.setearParametro("@titulo", disco.Titulo);
            accesoDatos.setearParametro("@fechaLanzamiento", disco.FechaLanzamiento);
            accesoDatos.setearParametro("@cantidadCanciones", disco.CantidadCanciones);
            accesoDatos.setearParametro("@urlImagen", disco.UrlTapa);
            accesoDatos.setearParametro("@idEstilo", disco.Estilo.Id);
            accesoDatos.setearParametro("@idTipoEdicion", disco.TipoEdicion.Id);
            accesoDatos.setearParametro("@id", disco.Id);

            accesoDatos.ejecutarAccion();
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

    public void eliminar(int id)
    {
        try
        {
            accesoDatos.setearConsulta("delete from DISCOS where id = @id");
            accesoDatos.setearParametro("@id", id);
            accesoDatos.ejecutarAccion();
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