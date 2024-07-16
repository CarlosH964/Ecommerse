using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerse.Models
{
    public class Ventas
    {
        [Key]
        public int VentaDId { get; set; }

        [ForeignKey("Items")]
        public int ItemsId { get; set; }
        public Items Items { get; set; }

        [ForeignKey("Prev")]
        public int IdPrev { get; set; }
        public PreV Prev { get; set; }

        public int Total { get; set; }

    }
}
