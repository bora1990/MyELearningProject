using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyELearningProject.DAL.Entities
{
    public class Form
    {
        [Key]
        
        public int FormID { get; set; }

        public string Name { get; set; }
        [EmailAddress]
        public string Mail { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }
    
    }
}