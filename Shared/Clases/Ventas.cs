using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorApp_Act17.Shared.Clases
{
    public class Ventas
    {
        [Required(ErrorMessage = "La Id es Obligatorio")]
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public int Cantidad_Vendida { get; set; }

        public int Precio_Venta { get; set; }

        [JsonIgnore]
        public virtual ICollection <Productos>? Productos { get; set; }

        [NotMapped]
        public List<int>? ProductosIds { get; set; }

    }
}
