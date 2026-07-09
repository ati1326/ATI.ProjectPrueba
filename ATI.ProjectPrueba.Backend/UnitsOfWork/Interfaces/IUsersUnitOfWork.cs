using ATI.ProjectPrueba.Classlibrary.DTOs;
using ATI.ProjectPrueba.Classlibrary.Entities;
using Microsoft.AspNetCore.Identity;

namespace ATI.ProjectPrueba.Backend.UnitsOfWork.Interfaces
{
    public interface IUsersUnitOfWork
    {
        Task<User> GetUserAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string rolename);

        Task<SignInResult> LoginAsync(LoginDTO model);

        Task LogoutAsync();

    }
}
