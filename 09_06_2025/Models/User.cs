using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V2.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateOnly DateOnlyRegistration { get; set; }
        public string FIO { get; set; }
        public string PhoneNumber { get; set; }
        public List<Inventory> Inventory { get; set; }
        public override string ToString()
        {
            return $"Login - {Login}, FIO - {FIO}";
        }
    }
}
