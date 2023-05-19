using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabbTwoADotNet.Models
{
    public class Course
    {
        [Key]
        public int ID { get; set; }
        public string CourseName { get; set; }

        //Relationships
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Course> Courses { get;set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
