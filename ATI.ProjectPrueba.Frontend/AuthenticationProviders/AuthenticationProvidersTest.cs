using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace ATI.ProjectPrueba.Frontend.AuthenticationProviders
{
    public class AuthenticationProvidersTest : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {

            await Task.Delay(1500);
            var anonimous = new ClaimsIdentity();
            var user = new ClaimsIdentity(authenticationType: "test");
            var admin = new ClaimsIdentity(new List<Claim>
            {
                new Claim("FirstName", "Juan"),
                new Claim("LastName", "Perez"),
                new Claim(ClaimTypes.Name, "Perez@gmail.com"),
                new Claim(ClaimTypes.Role, "Admin"),
            },
               authenticationType: "test" );
            
            
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(admin)));
            
        }

    }
}
