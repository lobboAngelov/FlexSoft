using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FlexSoft.Infrastructure.Entites.IdentityModels
{
    public class UserRole : IdentityRole<Guid, UserRoleMembership>
    {
        
    }
}