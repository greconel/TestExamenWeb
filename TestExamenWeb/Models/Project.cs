namespace TestExamenWeb.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        public DateTime SubmissionDate { get; set; }
        public decimal TheoryScore { get; set; }
        public decimal PracticalScore { get; set; }
        public decimal PresentationScore { get; set; }
        public decimal TotalGrade { get; set; }

        
    }
}
