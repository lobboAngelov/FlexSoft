using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FlexSoft.Infrastructure.Entites.IdentityModels
{
    public class User : IdentityUser<Guid,UserLogin, UserRoleMembership, UserClaim>
    {

    }
}
