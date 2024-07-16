    using System.ComponentModel.DataAnnotations;

    namespace Ecommerse.Models
    {
        public class Items
        {
            [Key]
            public int IdItems { get; set; }
            public int ObjectId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Customer { get; set; }
            public float Price { get; set; }
            public int Stock { get; set; }
            public string Img { get; set; }

        }
    }