using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Enums;

namespace WpfApp2.Models
{
    public class Book
    {
        [Key]
        public string Artikl { get; set; }
        public string Name { get; set; }
        public string Janr { get; set; }
        public string Description { get; set; }
        public DateOnly DateOnly { get; set; }
        public Status status { get; set; }
        [ForeignKey(nameof(User))]
        public string? UserId { get; set; }
        public User? User { get; set; }
    }
}
