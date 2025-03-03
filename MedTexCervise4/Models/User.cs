using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedTexCervise2.Models
{
    public class User
    {
        public int Id { get; set; } = 0;
        public FIO FIO { get; set; } = new FIO("", "", "");
        public string Login { get; set; } = "";
        public string Password { get; set; } = "";
        public Role Role { get; set; } = Role.Worker;
        public override string ToString()
        {
            return $"{Id}: {FIO.ToString()} - {Role}";
        }
    }
}
