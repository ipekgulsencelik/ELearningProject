using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ELearningProject.DAL.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Şifreler uyumlu değil.")]
        public string ConfirmPassword { get; set; }

        public string FullName { get; set; }
        public string Phone { get; set; }
        public string ImageURL { get; set; }

        public List<Review> Reviews { get; set; }
        public List<Course> Courses { get; set; }
    }
}