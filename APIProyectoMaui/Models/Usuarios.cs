using System.ComponentModel.DataAnnotations;

namespace APIProyectoMaui.Models
{
    public class Usuarios
    {
        [Key]
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Correo { get; set; }
        [Required]
        public string Contrasena { get; set; }

        //public List<Compra> Compras { get; set; }

    }
}

