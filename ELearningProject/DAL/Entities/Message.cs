namespace ELearningProject.DAL.Entities
{
    public class Message
    {
        public int MessageID { get; set; }
        public string NameSurname { get; set; }
        public string EMail { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }
    }
}