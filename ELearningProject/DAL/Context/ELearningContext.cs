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
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseRegister> CourseRegisters { get; set; }
        public DbSet<Carousel> Carousels { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Video> Videos { get; set; }
    }
}