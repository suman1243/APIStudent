using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIStudent.Model
{
    public class StudentContext:DbContext
    {
        public StudentContext(DbContextOptions<StudentContext>options):base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}
