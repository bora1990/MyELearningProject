using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace MyELearningProject.DAL.Entities
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Icon { get; set; }

        public string Address { get; set; }

        [Phone(ErrorMessage ="Lütfen bir telefon numarası giriniz")]
        public string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Geçersiz Email Adresi")]
        public string Email { get; set; }

        public string Location { get; set; }
           
    }
}