using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabbTwoADotNet.Models
{
    public class Student
    {
        [Key]
        public int ID { get; set; }
        public string StudentName { get; set;}
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int TeacherId { get; set; }
        public virtual ICollection<Teacher> Teacher { get; set; }
        
    }
}
