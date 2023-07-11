using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Speciality
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int resumeId { get; set; }
        public Resume Resume { get; set; }
    }
}
