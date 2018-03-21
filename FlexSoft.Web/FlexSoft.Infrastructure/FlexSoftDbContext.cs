﻿using System;
using System.Data.Entity;
using FlexSoft.Infrastructure.Entites;
using FlexSoft.Infrastructure.Entites.IdentityModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FlexSoft.Infrastructure
{
    
    public class FlexSoftDbContext : IdentityDbContext<User, UserRole, Guid, UserLogin, UserRoleMembership, UserClaim>
    {
        public FlexSoftDbContext() : base("FlexSoftDb")
        {
            
        }
        
    }
}
