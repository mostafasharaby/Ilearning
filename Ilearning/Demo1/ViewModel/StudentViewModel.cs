using Demo1.Models;

namespace Demo1.ViewModel
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string TranieeName { get; set; }
        public string CourseName { get; set; }
        public string Image { get; set; }


        public string Color { get; set; }
        public int CourseDegree { get; set; }
        public int TranieeDegree { get; set; }

        public List<CrsResult> CrsResult { get; set; } = new List<CrsResult>();


    }
}
