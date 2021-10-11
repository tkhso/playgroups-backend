using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HMMJ.Data
{
    public class User : IdentityUser<int>
    {
        // Ctor
        public User()
        {

        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserRole UserRole { get; set; }

        [NotMapped]
        public bool IsCreate => this.Id == 0;

        [NotMapped]
        public string Password { get; set; }

        [NotMapped]
        public string FullName => $"{this.FirstName} {this.LastName}".Trim();
    }
}
