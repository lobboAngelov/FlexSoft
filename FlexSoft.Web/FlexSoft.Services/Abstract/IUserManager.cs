using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexSoft.Infrastructure.Entites.ServiceModels;


namespace FlexSoft.Services.Abstract
{
    public interface IUserManager
    {
        AuthoriseResult Authorise(AuthoriseRequest request);
        RegisterResponse Register(RegisterRequest request);
    }

    class UserManager : IUserManager
    {
        public AuthoriseResult Authorise(AuthoriseRequest request)
        {
            throw new NotImplementedException();
        }

        public RegisterResponse Register(RegisterRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
