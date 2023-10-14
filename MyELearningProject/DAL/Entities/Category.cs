using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyELearningProject.DAL.Entities
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public string CategoryPhoto { get; set; }

        public int CourseCountinCategory { get; set; }

        public List<Course> Courses { get; set; } //1 kategori 1 den fazla kurs

    }
}