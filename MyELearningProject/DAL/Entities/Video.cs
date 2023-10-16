using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyELearningProject.DAL.Entities
{
    public class Video
    {
        public int VideoID { get; set; }

        public string Url { get; set; }

        public int CourseID { get; set; }

        public virtual Course Course { get; set; }

    }
}