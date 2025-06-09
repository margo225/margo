using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V2.Enums;

namespace V2.Models
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; }
        public string Artikl { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateOnly DateOnly { get; set; }
        public Status Status { get; set; }
        public int? IdUser { get; set; }
        public User? User { get; set; }
    }
}
