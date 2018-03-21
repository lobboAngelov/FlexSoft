using System;
using FlexSoft.Infrastructure.Entites;
using FlexSoft.Infrastructure.Entites.IdentityModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FlexSoft.Infrastructure
{
    public class UserStore : UserStore<User, UserRole, Guid, UserLogin, UserRoleMembership, UserClaim>
    {
        public UserStore(FlexSoftDbContext dbContext) : base(dbContext)
        {

        }
    }
}
