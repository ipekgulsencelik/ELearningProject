﻿namespace ELearningProject.DAL.Entities
{
    public class ContactInfo
    {
        public int ContactInfoID { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
    }
}