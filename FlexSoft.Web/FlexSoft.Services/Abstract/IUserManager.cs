using System.Threading.Tasks;
using FlexSoft.Infrastructure.Entites;
using FlexSoft.Infrastructure.Entites.IdentityModels;
using FlexSoft.Infrastructure.Entites.ServiceModels;
using FlexSoft.Infrastructure.Entites.WebModels;

namespace FlexSoft.Services.Abstract
{
    public interface IUserManager
    {
        Task<AuthoriseResult> Authorise(string username, string password);
        Task<ServiceResult> Register(RegisterInfo registerInfo);
        Task<User> GetUser(int userId);
    }
}
