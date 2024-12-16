using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template_Mothod_Pattern
{
    public abstract class ReportGenerator
    {
        public void GenerateReport()
        {
            DataCollection();
            DataProcessing();
            FormattingAReport();
            ExportReport();
        }
        public abstract void DataCollection();
        public abstract void DataProcessing();
        public abstract void FormattingAReport();
        public abstract void ExportReport();
    }
    public class StudentReportGenerator : ReportGenerator
    {
        public override void DataCollection()
        {
            Console.WriteLine("Собранны двнные по студентам");
        }
        public override void DataProcessing()
        {
            Console.WriteLine("Обработаны данные по студентам");
        }
        public override void FormattingAReport()
        {
            Console.WriteLine("Отформатирован отчет о студентах");
        }
        public override void ExportReport()
        {
            Console.WriteLine("Экспортирован отчет о студентах");
        }
    }
    public class CourseReportGenerator : ReportGenerator
    {
        public override void DataCollection()
        {
            Console.WriteLine("Собранны данные о курсах");
        }
        public override void DataProcessing()
        {
            Console.WriteLine("Обработаны данные о курсах");
        }
        public override void FormattingAReport()
        {
            Console.WriteLine("Отформатирован отчет о курсах");
        }
        public override void ExportReport()
        {
            Console.WriteLine("Экспортирован отчет о курсах");
        }
    }
}
