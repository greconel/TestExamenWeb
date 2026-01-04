using System.ComponentModel.DataAnnotations;

namespace TestExamenWeb.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        public DateTime SubmissionDate { get; set; }

        [Required(ErrorMessage = "Theory Score is required")]
        [Range(0, 20, ErrorMessage = "Theory Score must be between 0 and 20")]
        public decimal? TheoryScore { get; set; }
        public decimal PracticalScore { get; set; }
        public decimal PresentationScore { get; set; }
        public decimal TotalGrade { get; set; }

        
    }
}
