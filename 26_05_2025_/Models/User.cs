using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Models
{
    public class User
    {
        [Key]
        public string Login { get; set; }
        public string Password { get; set; }
        public DateOnly Registration {  get; set; }
        public string FIO { get; set; }
        public string Phone {  get; set; }
        public override string ToString()
        {
            return $"{FIO}";
        }
    }
}
