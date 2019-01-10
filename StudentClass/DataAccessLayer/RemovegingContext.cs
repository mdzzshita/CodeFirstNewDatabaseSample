using StudentClass.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClass.DataAccessLayer
{
    class RemovegingContext: DbContext
    {
        public DbSet<Remove> Removes { get; set; }
        public DbSet<Student> Students { get; set; }

    }
}
