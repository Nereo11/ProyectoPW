using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorApp_Act17.Shared.Clases
{
    public class Productos
    {

        [Required(ErrorMessage = "La Id es Obligatorio")]
        public int Id { get; set; }


        [Required(ErrorMessage = "El Nombre es Obligatorio"), MaxLength(100)]
        public string? Nombre{ get; set; }

        [Required(ErrorMessage = "La cantidad es Obligatorio")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El Proveedor no puede ser vació")]
        public int? ProveedoresId { get; set; }
        public virtual Proveedores? Proveedores { get; set; }

        [JsonIgnore]
        public virtual ICollection<Ventas>? Ventas { get; set; }




    }
}
