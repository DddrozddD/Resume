using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Experience
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Speciality { get; set; }
        public string NameOfCompany { get; set; }
        public string Description { get; set; }
        public int resumeId { get; set; }
        public Resume Resume { get; set; }
    }
}
