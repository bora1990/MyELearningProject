using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyELearningProject.DAL.Entities
{
    public class Communication
    {
        public int CommunicationID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }
    }
}