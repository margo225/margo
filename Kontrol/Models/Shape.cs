using Kontrol.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontrol.Models
{
    public class Shape
    {
        [Key]
        public string Articl {  get; set; }
        public string ShortDescription { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateOnly DateRegistration { get; set; }
        public Status Status { get; set; }
        public string? UserLogin { get; set; }
        public User? User { get; set; }
    }
}
