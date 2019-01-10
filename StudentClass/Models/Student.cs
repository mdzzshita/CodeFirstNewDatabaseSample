using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClass.Models
{
   public class Student
    {
       
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentSex { get; set; }
        public int RemoveId { get; set; }
        public virtual Remove Remove { get; set; }
        
    }
}
