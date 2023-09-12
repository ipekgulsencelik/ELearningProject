﻿using ELearningProject.DAL.Entities;
using System.Data.Entity;

namespace ELearningProject.DAL.Context
{
    public class ELearningContext : DbContext
    { 
        public DbSet<Category> Categories { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
    }
}