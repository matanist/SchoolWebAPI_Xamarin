using System;
using System.Collections.Generic;

namespace SchoolDBData.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Number { get; set; }
        public string Phone { get; set; }
    }
}
