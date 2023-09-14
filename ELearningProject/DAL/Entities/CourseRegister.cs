using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearningProject.DAL.Entities
{
    public class CourseRegister
    {
        public int CourseRegisterID { get; set; }

        public int StudentID { get; set; }
        public Student Student { get; set; }
        
        public int CourseID { get; set; }
        public Course Course { get; set; }

        [Column("Date")]
        public DateTime RegisterDate { get; set; }
    }
}