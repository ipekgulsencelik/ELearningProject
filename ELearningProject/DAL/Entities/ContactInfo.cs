namespace ELearningProject.DAL.Entities
{
    public class ContactInfo
    {
        public int ContactInfoID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string SocialMedia1 { get; set; }
        public string SocialMedia2 { get; set; }
        public string SocialMedia3 { get; set; }
        public string SocialMedia4 { get; set; }
        public bool Status { get; set; }
    }
}