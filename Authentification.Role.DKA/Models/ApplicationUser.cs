using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Authentification.Role.DKA.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() { }

        public ApplicationUser(string userName) : base(userName) {   }

        [PersonalData]
        [MaxLength(50)]
        public string FullName { get; set; }

        [PersonalData]
        public DateTime? Birthday { get; set; }
    }

    public class ApplicationRole : IdentityRole
    {

    }
}
