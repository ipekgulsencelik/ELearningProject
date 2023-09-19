﻿using System.Collections.Generic;
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

        public List<Course> Courses { get; set; }
    }
}