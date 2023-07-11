using System.Runtime.CompilerServices;

namespace ASP_Resume.Models
{
    public class RegisterViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPass { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Telephone { get; set; }
        public string Town { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }
    }
}
