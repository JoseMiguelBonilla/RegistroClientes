using System.ComponentModel.DataAnnotations;


namespace RegistroClientes.Models
{
    public class Tickets
    {
        [Key]
        [Required(ErrorMessage = "El Id es requerido")]
        public int TicketsId {get; set;}
        [Required(ErrorMessage = "El Nombre del emisor es requerido")]

        public string? Nombre {get;set;}
        [Required(ErrorMessage = "El Mensaje es requerido")]

        public string? Mensaje {get;set;}
        
    }
}