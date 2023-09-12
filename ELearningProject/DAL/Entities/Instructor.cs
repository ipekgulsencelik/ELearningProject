﻿using System.ComponentModel.DataAnnotations;

namespace ELearningProject.DAL.Entities
{
    public class Instructor
    {
        public int InstructorID { get; set; }
        public string Name { get; set; }

        [StringLength(30)]
        public string Surname { get; set; }

        public string ImageURL { get; set; }
    }
}