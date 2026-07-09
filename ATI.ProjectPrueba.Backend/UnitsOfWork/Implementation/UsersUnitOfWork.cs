using ATI.ProjectPrueba.Backend.Repositories.Implementation;
using ATI.ProjectPrueba.Backend.Repositories.Interfaces;
using ATI.ProjectPrueba.Backend.UnitsOfWork.Interfaces;
using ATI.ProjectPrueba.Classlibrary.DTOs;
using ATI.ProjectPrueba.Classlibrary.Entities;
using Microsoft.AspNetCore.Identity;

namespace ATI.ProjectPrueba.Backend.UnitsOfWork.Implementation
{
    public class UsersUnitOfWork : IUsersUnitOfWork
    {
        private readonly IUserRepository _userRepository;

        public UsersUnitOfWork(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<IdentityResult> AddUserAsync(User user, string password) => await
            _userRepository.AddUserAsync(user, password);
     
        public async Task AddUserToRoleAsync(User user, string roleName) => await
        _userRepository.AddUserToRoleAsync(user, roleName);


        public async Task CheckRoleAsync(string roleName) =>  await _userRepository.CheckRoleAsync(roleName);


        public async Task<User> GetUserAsync(string email) => await _userRepository.GetUserAsync(email);
       
        public async Task<bool> IsUserInRoleAsync(User user, string rolename) => await
            _userRepository.IsUserInRoleAsync(user, rolename);

        public async Task<SignInResult> LoginAsync(LoginDTO model) => await _userRepository.LoginAsync(model);

        public async Task LogoutAsync() => await _userRepository.LogoutAsync();


    }
}
