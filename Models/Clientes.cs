using System.ComponentModel.DataAnnotations;

namespace RegistroClientes.Models
{
    public class Cliente
    {
        [Key] 
        public int ClienteId {get; set;}
        [Required(ErrorMessage ="Los nombres son obligatorios")]
        public string Nombres {get; set;}
        [Required(ErrorMessage ="Los medio de contacto son obligatorios")]
        public long Telefono {get; set;}
        [Required(ErrorMessage ="Los medio de contacto son obligatorios")]
        public long Celular {get; set;}
         [Required(ErrorMessage ="El RNC es obligatorio")]
        public long RNC {get; set;}
        [Required(ErrorMessage ="El Email es obligatorio")]
        public string Email {get; set;}

        [Required(ErrorMessage ="La direccion es obligatoria")]
        public string Direccion {get; set;}
        
    }
}