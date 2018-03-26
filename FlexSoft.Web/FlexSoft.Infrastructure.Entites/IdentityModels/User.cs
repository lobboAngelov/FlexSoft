using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FlexSoft.Infrastructure.Entites.IdentityModels
{
    public class User : IdentityUser<Guid,UserLogin, UserRoleMembership, UserClaim>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override Guid Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
        
        public int RfidCardNumber { get; set; }
    }
}
