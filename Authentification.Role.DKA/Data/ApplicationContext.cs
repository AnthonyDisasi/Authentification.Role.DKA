﻿using Authentification.Role.DKA.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentification.Role.DKA.Data
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {

    }
}