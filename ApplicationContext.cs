using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedTexCervise2.Models;
using System.Windows.Media.Media3D;
using System.Collections.ObjectModel;

namespace MedTexCervise2
{
    public class ApplicationContext
    {
        private ObservableCollection<Models.Shape> _shapes = new ObservableCollection<Models.Shape>()
        {
            new Shape()
            {
                FIO = new FIO("Иванов", "Дмитрий", "Игоревич"),
                description = "Сломана водяная помпа",
                DateAdd = new DateTime(2023, 10, 1),
                DateDelivery = new DateTime(2023, 10, 5),
                modelOb = ModelOb.AB,
                phone = "79123456789",
                tupeOb = TupeOb.Рентген,
                TypeShapeStatus = TypeShapeStatus.New_shape
            },
            new Shape()
            {
                FIO = new FIO("Петров", "Алексей", "Сергеевич"),
                description = "Проблемы с шумом",
                DateAdd = new DateTime(2023, 9, 25),
                DateDelivery = new DateTime(2023, 9, 30),
                modelOb = ModelOb.AB,
                phone = "79234567890",
                tupeOb = TupeOb.Узи,
                TypeShapeStatus = TypeShapeStatus.Completed
            },
            new Shape()
            {
                FIO = new FIO("Сидоров", "Иван", "Александрович"),
                description = "Замена деталей",
                DateAdd = new DateTime(2023, 10, 2),
                DateDelivery = new DateTime(2023, 10, 3),
                modelOb = ModelOb.AB,
                phone = "79345678901",
                tupeOb = TupeOb.Рентген,
                TypeShapeStatus = TypeShapeStatus.Process_repair
            },
            new Shape()
            {
                FIO = new FIO("Козлов", "Михаил", "Владимирович"),
                description = "Ремонт детали",
                DateAdd = new DateTime(2023, 9, 28),
                DateDelivery = new DateTime(2023, 10, 4),
                modelOb = ModelOb.AB,
                phone = "79456789012",
                tupeOb = TupeOb.Узи,
                TypeShapeStatus = TypeShapeStatus.New_shape
            },
            new Shape()
            {
                FIO = new FIO("Смирнов", "Андрей", "Дмитриевич"),
                description = "Замена деталей",
                DateAdd = new DateTime(2023, 10, 1),
                DateDelivery = new DateTime(2023, 10, 6),
                modelOb = ModelOb.AB,
                phone = "79567890123",
                tupeOb = TupeOb.Рентген,
                TypeShapeStatus = TypeShapeStatus.Process_repair
            },
            new Shape()
            {
                FIO = new FIO("Васильев", "Сергей", "Анатольевич"),
                description = "Ремонт материнской платы",
                DateAdd = new DateTime(2023, 9, 29),
                DateDelivery = new DateTime(2023, 10, 5),
                modelOb = ModelOb.BC,
                phone = "79678901234",
                tupeOb = TupeOb.Узи,
                TypeShapeStatus = TypeShapeStatus.Completed
            },
            new Shape()
            {
                FIO = new FIO("Морозов", "Николай", "Иванович"),
                description = "Замена блока питания",
                DateAdd = new DateTime(2023, 10, 3),
                DateDelivery = new DateTime(2023, 10, 7),
                modelOb = ModelOb.AB,
                phone = "79789012345",
                tupeOb = TupeOb.Узи,
                TypeShapeStatus = TypeShapeStatus.New_shape
            },
            new Shape()
            {
                FIO = new FIO("Кузнецов", "Павел", "Викторович"),
                description = "Ремонт высоковольтных кабелей",
                DateAdd = new DateTime(2023, 9, 30),
                DateDelivery = new DateTime(2023, 10, 8),
                modelOb = ModelOb.AB,
                phone = "79890123456",
                tupeOb = TupeOb.Рентген,
                TypeShapeStatus = TypeShapeStatus.Process_repair
            },
            new Shape()
            {
                FIO = new FIO("Лебедев", "Александр", "Николаевич"),
                description = "Ремонт ультразвукового оборудования",
                DateAdd = new DateTime(2023, 10, 4),
                DateDelivery = new DateTime(2023, 10, 9),
                modelOb = ModelOb.BC,
                phone = "79901234567",
                tupeOb = TupeOb.Узи,
                TypeShapeStatus = TypeShapeStatus.Completed
            },
            new Shape()
            {
                FIO = new FIO("Новиков", "Денис", "Олегович"),
                description = "Ремонт рентгеновской трубки",
                DateAdd = new DateTime(2023, 10, 5),
                DateDelivery = new DateTime(2023, 10, 10),
                modelOb = ModelOb.AB,
                phone = "79012345678",
                tupeOb = TupeOb.Рентген,
                TypeShapeStatus = TypeShapeStatus.New_shape
            },
            new Shape()
            {
                FIO = new FIO("Федоров", "Евгений", "Васильевич"),
                description = "Замена высоковольтных кабелей",
                DateAdd = new DateTime(2023, 10, 6),
                DateDelivery = new DateTime(2023, 10, 11),
                modelOb = ModelOb.AB,
                phone = "79123456789",
                tupeOb = TupeOb.Рентген,
                TypeShapeStatus = TypeShapeStatus.Process_repair
            },
            new Shape()
            {
                FIO = new FIO("Белов", "Артем", "Сергеевич"),
                description = "Ремонт жесткого диска",
                DateAdd = new DateTime(2023, 10, 7),
                DateDelivery = new DateTime(2023, 10, 12),
                modelOb = ModelOb.BC,
                phone = "79234567890",
                tupeOb = TupeOb.Узи,
                TypeShapeStatus = TypeShapeStatus.Completed
            },
        };
        private static ObservableCollection<User> _users = new ObservableCollection<User>()
        {
            new User(){Id = 1, FIO = new FIO("Зубенко", "Михаил", "Петрович"), Login="", Password="", Role = Role.Worker},
            new User(){Id = 2, FIO = new FIO("Зубенко", "Владимир", "Петрович"), Login="", Password="", Role = Role.Worker},
            new User(){Id = 3, FIO = new FIO("Зубаков", "Петр", "Петрович"), Login="", Password="", Role = Role.Worker}
        };
        //private static ObservableCollection<Role> _roles = new ObservableCollection<Role>()
        //{
        //    new Role() { Id = 0, Value = "Admin"},
        //    new Role() { Id = 1, Value = "User"},
        //    new Role() { Id = 2, Value = "Mechanic"}
        //};
        public ObservableCollection<Models.Shape> Shapes
        {
            get
            {
                return _shapes;
            }
            set
            {
                _shapes = value;
            }

        }
        public ObservableCollection<User> Users
        {
            get
            {
                return _users;
            }
            set
            {
                _users = value;
            }

        }
        //public ObservableCollection<Role> Roles
        //{
        //    get
        //    {
        //        return _roles;
        //    }
        //    set
        //    {
        //        _roles = value;
        //    }

        //}
    }
}
