using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ELearningProject.DAL.Entities
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string ImageURL { get; set; }
        public bool IsHome { get; set; }
        public bool Status { get; set; }

        public List<Course> Courses { get; set; }
    }
}