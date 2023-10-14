using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyELearningProject.DAL.Entities
{
    public class Address
    {
        public int AddressID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string AddressPartial { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }

    }
}