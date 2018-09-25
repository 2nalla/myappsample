using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NgStudentGradesSpa1.Models
{
    public class SGradesModel
    {
        [Key]
        public string StudentCode { get; set; }
        public string StudentName { get; set; }
        public int Math { get; set; }
        public int Science { get; set; }
        public int English { get; set; }
        public int Total { get; set; }
        public int Average { get; set; }
        public string Grade { get; set; }
    }
}