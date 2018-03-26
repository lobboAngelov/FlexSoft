using System;
using System.Linq;
using System.Threading.Tasks;
using FlexSoft.Infrastructure;
using FlexSoft.Infrastructure.Entites;
using FlexSoft.Infrastructure.Entites.IdentityModels;
using FlexSoft.Infrastructure.Entites.ServiceModels;
using FlexSoft.Infrastructure.Entites.WebModels;
using FlexSoft.Services.Abstract;
using Microsoft.AspNet.Identity;

namespace FlexSoft.Services
{
    public class UserManager : UserManager<User,Guid>, IUserManager
    {
        private readonly IRepository _repository;

        public UserManager(UserStore userStore, IRepository repository) : base(userStore)
        {
            _repository = repository;
        }

        public async Task<AuthoriseResult> Authorise(string username, string password)
        {
            var result = new AuthoriseResult();

            var user = await FindAsync(username, password);

            if (user == null)
            {
                result.Errors.Add("Invalid credentials");
            }
            else
            {
                result.User = user;
            }

            return result;
        }

        public async Task<ServiceResult> Register(RegisterInfo request)
        {
            var result = new ServiceResult();

            if (request.Password != request.PasswordRepeat)
            {
                result.Errors.Add("Passwords do not match");
            }

            var passwordValidated = await PasswordValidator.ValidateAsync(request.Password);
            if (!passwordValidated.Succeeded)
            {
                result.Errors.Add("Password validation failed");
            }

            if (_repository.GetAll<User>().Any(u => u.UserName == request.Email))
            {
                result.Errors.Add("User with that email already exists");
            }

            var user = new User
            {
                UserName = request.Email
            };

            var userValidationResult = await UserValidator.ValidateAsync(user);
            if (userValidationResult.Succeeded)
            {
                await CreateAsync(user, request.Password);
            }

            return result;
        }

        public async Task<User> GetUser(int rfId)
        {
            return await Task.FromResult(_repository.GetAll<User>().FirstOrDefault(x=> x.RfidCardNumber == rfId));
        }
    }
}