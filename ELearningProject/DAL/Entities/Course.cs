using System.Collections.Generic;

namespace ELearningProject.DAL.Entities
{
    public class Course
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public decimal Duration { get; set; }
        public string ImageURL { get; set; }

        public bool IsHome { get; set; }
        public bool IsPopular { get; set; } 
        public bool Status { get; set; }

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public int InstructorID { get; set; }
        public virtual Instructor Instructor { get; set; }

        public List<CourseRegister> CourseRegisters { get; set; }
    }
}