using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Resume
    {
        public int Id { get; set; }
        public string userId { get; set; }
        public User User { get; set; }
        public IReadOnlyCollection<Speciality> Specialities { get; set; }
        public string? LinkOnRep { get; set; }
        public string? About { get; set; }
        public IReadOnlyCollection<Skill> Skills { get; set; }
        public IReadOnlyCollection<Education> Educations { get; set; }
        public IReadOnlyCollection<Experience> Experiences { get; set; }
    }
}
