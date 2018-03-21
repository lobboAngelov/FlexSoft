using FlexSoft.Infrastructure.Entites.IdentityModels;

namespace FlexSoft.Infrastructure.Entites.ServiceModels
{
    public class AuthoriseResult : ServiceResult
    {
        public User User { get; set; }
    }
}
