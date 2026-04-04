using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Discos.Dominio;

public class Disco
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El título es obligatorio.")]
    [DisplayName("Título")]
    public string Titulo { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "La fecha de lanzamiento es obligatoria.")]
    [DisplayName("Fecha de Lanzamiento")]
    public DateTime FechaLanzamiento { get; set; }

    [Required(ErrorMessage = "La cantidad de canciones es obligatoria.")]
    [DisplayName("Cantidad de Canciones")]
    public int CantidadCanciones { get; set; }

    [DisplayName("Tapa del Disco")]
    public string? UrlTapa { get; set; } = string.Empty;

    [Required(ErrorMessage = "El estilo es obligatorio.")]
    public Estilo Estilo { get; set; } = new();

    [Required(ErrorMessage = "El tipo de edición es obligatorio.")]
    [DisplayName("Tipo de Edición")]
    public TipoEdicion TipoEdicion { get; set; } = new();
}