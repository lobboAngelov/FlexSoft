
using System.Data.Entity;
using FlexSoft.Infrastructure.Entites;

namespace FlexSoft.Infrastructure
{
    
    public class FlexSoftDbContext : System.Data.Entity.DbContext
    {
        public FlexSoftDbContext() : base("FlexSoftDb")
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}
