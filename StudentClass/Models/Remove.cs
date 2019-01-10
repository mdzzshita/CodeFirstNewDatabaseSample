using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClass.Models
{
    public class Remove
    {
        
        public int RemoveId { get; set; }
        public string RemoveName { get; set; }
        public virtual List<Student> Students { get; set; }

    }
}
