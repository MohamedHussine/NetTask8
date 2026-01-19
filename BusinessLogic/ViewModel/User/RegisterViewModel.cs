using System;
using System.Collections.Generic;
using System.Text;

namespace BuisnessLogic.VeiwModel.User
{
    public class RegisterViewModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Role { get; set; } // Student / Instructor
    }
}
