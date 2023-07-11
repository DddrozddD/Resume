using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Telephone { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }
        public string Country { get; set; }
        public int? resumeId { get; set; } 
        public Resume Resume { get; set; }

    }
}
