using System.ComponentModel.DataAnnotations;

namespace TestExamenWeb.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        
        public string? StudentName { get; set; }

        public List<Project>? Projects { get; set; }
    }
}
