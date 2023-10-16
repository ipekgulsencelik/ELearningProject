namespace ELearningProject.DAL.Entities
{
    public class Video
    {
        public int VideoID { get; set; }
        public int LessonNumber { get; set; }
        public string VideoURL { get; set; }

        public int CourseID { get; set; }
        public Course Course { get; set; }       
    }
}