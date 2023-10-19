using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ELearningProject.DAL.Entities
{
    public class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageURL { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }

        [Compare("Password", ErrorMessage = "Şifreler uyumlu değil.")]
        public string ConfirmPassword { get; set; }

        public List<CourseRegister> CourseRegisters { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Process> Processes { get; set; }
    }
}