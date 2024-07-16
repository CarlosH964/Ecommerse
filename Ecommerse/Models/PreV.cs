using Ecommerse.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerse.Models
{
    public class PreV
    {
        [Key]
        public int PrevId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public DateTime Fecha { get; set; }
        public User User { get; set; }

    }
}
