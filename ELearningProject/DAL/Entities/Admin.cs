using System.ComponentModel.DataAnnotations;

namespace ELearningProject.DAL.Entities
{
    public class Admin
    {
        public int AdminID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageURL { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Şifreler uyumlu değil.")]
        public string ConfirmPassword { get; set; }
    }
}