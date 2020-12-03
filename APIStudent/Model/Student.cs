using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIStudent.Model
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public string Course { get; set; }
        public string Stream { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
    }
}
