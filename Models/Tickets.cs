using System.ComponentModel.DataAnnotations;


namespace RegistroClientes.Models
{
    public class Tickets
    {
        [Key] 
        public int TicketId {get; set;}
        [Required(ErrorMessage ="La fecha es obligatorios")]
        public int Fecha {get;set;}
        [Required(ErrorMessage ="Los Id del cliente son obligatorios")]
        public int ClienteId {get; set;}
        [Required(ErrorMessage ="Los Id del sistema son  obligatorios")]
        public int SistemaId {get; set;}
         [Required(ErrorMessage ="Los Id del la prioridad son  obligatorios")]
        public int PrioridadId {get; set;}
        [Required(ErrorMessage ="La descripcion de por quien fue es obligatorios")]
        public string? SolicitadoPor {get; set;}
        [Required(ErrorMessage ="El Asunto es obligatorio")]
        public string? Asunto {get; set;}

        [Required(ErrorMessage ="La Descripcion es obligatoria")]
        public string? Descripcion {get; set;}
        
    }
}