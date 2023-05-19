using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabbTwoADotNet.Models
{
    public class Subject
    {
        [Key]
        public int ID { get; set; }
        public string subjectName { get; set; }

        //Relationships
        public virtual ICollection<Course> Course { get; set; }
        public virtual ICollection<Teacher> Teacher { get; set; }
    }
}
