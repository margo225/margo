using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedTexCervise2.Models
{
    /*public class EnumType
    {
    }*/
    public enum ModelOb
    {
        AB,
        BC
    }
    public enum TupeOb
    {
        Рентген,
        Узи
    }
    public enum TypeShapeStatus
    { 
        New_shape,
        Process_repair,
        Completed
    }
    public enum Role
    {
        User,
        Admin,
        Worker
    }
}
