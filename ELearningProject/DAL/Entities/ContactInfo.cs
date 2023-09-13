using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ELearningProject.DAL.Entities
{
    public class ContactInfo
    {
        public int ContactInfoID { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }        
    }
}