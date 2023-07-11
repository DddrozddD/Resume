using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Education
    {
        public int Id { get; set; }
        public string NameOfUniversaty { get; set; }
        public string Speciality { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public int resumeId { get; set; }
        public Resume Resume { get; set; }
    }
}
