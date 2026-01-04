using System.ComponentModel.DataAnnotations;

namespace TestExamenWeb.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        [StringLength(120)]
        public string? StudentName { get; set; }

        public List<Project>? Projects { get; set; }
    }
}
