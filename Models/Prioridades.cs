using System.ComponentModel.DataAnnotations;

namespace RegistroClientes.Models
{
    public class Prioridades
    {
       [Key] 
        public int PrioridadId {get; set;}
        [Required(ErrorMessage ="La descripcion es obligatorios")]
        public string? Descripcion {get; set;}
        [Required(ErrorMessage ="Los dias de compromiso son obligatorios")]
        public int DiasCompromiso {get; set;}
       
    }
}