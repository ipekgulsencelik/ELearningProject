namespace ELearningProject.DAL.Entities
{
    public class Review
    {
        public int ReviewID { get; set; }
        public int ReviewScore { get; set; }

        public int CourseID { get; set; }
        public Course Course { get; set; }
        
        public int StudentID { get; set; }
        public Student Student { get; set; }
    }
}