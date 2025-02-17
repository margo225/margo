using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedTexCervise2.Models
{
    public class FIO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public FIO(string Fname, string Lname, string patronymic)
        {
            FirstName = Fname;
            LastName = Lname;
            Patronymic = patronymic;
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName} {Patronymic}";
        }
    }
}
