using MyELearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyELearningProject.DAL.Context
{
    public class ELearningContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }  //Categories sql e yansıyacak olan tablonun ismi

        public DbSet<Instructor> Instuctors { get; set; }    

        public DbSet<Testimonial> Testimonials { get; set;}

        public DbSet<Student> Students { get; set; }    

        public DbSet<Course> Courses { get; set; }  

        public DbSet<CourseRegister> CoursesRegisters { get; set;}

        public DbSet<Feature> Features { get; set; }

        public DbSet<About> Abouts { get; set; }

        public DbSet<Form> Forms { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Process> Processes { get; set; }

        public DbSet<Master> Masters { get; set; }

    public DbSet<Video> Videos { get; set; }
 
    }
}