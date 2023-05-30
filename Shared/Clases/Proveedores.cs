using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace BlazorApp_Act17.Shared.Clases
{
    public class Proveedores
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "La Id es Obligatorio")]
        public int Id { get; set; }


        [Required(ErrorMessage = "El Nombre es Obligatorio"), MaxLength(100)]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "La Dirección es Obligatorio"), MaxLength(100)]
        public string? Dirección { get; set; }

        [Required(ErrorMessage = "El Correo es Obligatorio"), MaxLength(30), EmailAddress]
        //[EmailAddress(ErrorMessage = "Correo Invalido")]
        public string? Correo { get; set; }

        [Required(ErrorMessage = "El número teléfonico es Obligatoria"), MaxLength(15), Phone]
       // [Phone(ErrorMessage = "Numero Invalido")]
        public string? Telefono { get; set; }

        //[ForeignKey("ProveedoresId")]
        public virtual ICollection<Productos>? Producto { get; set; }


    }
}
