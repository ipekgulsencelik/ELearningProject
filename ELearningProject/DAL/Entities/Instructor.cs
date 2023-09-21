using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ELearningProject.DAL.Entities
{
    public class Instructor
    {
        public int InstructorID { get; set; }
        public string Name { get; set; }

        [StringLength(30)]
        public string Surname { get; set; }

        public string ImageURL { get; set; }
        public string Title { get; set; }
        public string CoverImage { get; set; }

        public string SocialMedia1 { get; set; }
        public string SocialMedia2 { get; set; }
        public string SocialMedia3 { get; set; }

        public bool IsHome { get; set; }
        public bool Status { get; set; }

        public List<Course> Courses { get; set; }
    }
}