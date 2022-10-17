using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1091606.Models
{
    public class Project
    {
        public List<TableStudents1091606> Student { get; set; }
        public List<TableTeachers1091606> Teacher { get; set; }
        public List<TableClasss1091606> Class { get; set; }
        public List<TableCarts1091606> Cart { get; set; }
    }
}