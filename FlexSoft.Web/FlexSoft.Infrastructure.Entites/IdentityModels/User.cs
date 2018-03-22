using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FlexSoft.Infrastructure.Entites.IdentityModels
{
    public class User : IdentityUser<Guid,UserLogin, UserRoleMembership, UserClaim>
    {
        [MaxLength(100)]
        public string Name { get; set; }
        
        public int RfidCardNumber { get; set; }
    }
}
