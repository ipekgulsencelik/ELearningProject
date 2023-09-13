using ELearningProject.DAL.Entities;
using System.Data.Entity;

namespace ELearningProject.DAL.Context
{
    public class ELearningContext : DbContext
    { 
        public DbSet<Category> Categories { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<AboutItem> AboutItems { get; set; }
        public DbSet<ContactInfo> ContactInfos{ get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
    }
}