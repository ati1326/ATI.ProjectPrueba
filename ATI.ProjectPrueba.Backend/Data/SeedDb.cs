using ATI.ProjectPrueba.Backend.UnitsOfWork.Interfaces;
using ATI.ProjectPrueba.Classlibrary.Entities;
using ATI.ProjectPrueba.Classlibrary.Enums;

namespace ATI.ProjectPrueba.Backend.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUsersUnitOfWork _usersUnitOfWork;

        public SeedDb(DataContext context, IUsersUnitOfWork usersUnitOfWork)
        {
            _context = context;
            _usersUnitOfWork = usersUnitOfWork;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCountriesAsync();
            //await CheckCategoriesAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1010", "Juan", "Zuluaga", "zulu@yopmail.com", "322 311 4620", "Calle Luna Calle Sol", UserType.Admin);

        }

        private async Task CheckRolesAsync()
        {
            await _usersUnitOfWork.CheckRoleAsync(UserType.Admin.ToString());
            await _usersUnitOfWork.CheckRoleAsync(UserType.User.ToString());

        }

            private async Task<User> CheckUserAsync(string document, string firstName, string lastName, string email, string phone, string address, 
                UserType userType)
        {
            var user = await _usersUnitOfWork.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    //City = _context.Cities.FirstOrDefault(),
                    UserType = userType,
                };

                await _usersUnitOfWork.AddUserAsync(user, "123456");
                await _usersUnitOfWork.AddUserToRoleAsync(user, userType.ToString());
            }

            return user;
        }


        private async Task CheckCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new Country
                {
                    Name = "Colombia",
                    States = [
                          new State()
                          {
                             Name = "Antioquia",
                             Cities = [
                                new() { Name = "Medellín" },
                                new() { Name = "Itagüí" },
                                new() { Name = "Envigado" },
                                new() { Name = "Bello" },
                                new() { Name = "Rionegro" },
                             ]
                          },
                         new State()
                         {
                            Name = "Bogotá",
                            Cities = [
                                new() { Name = "Usaquen" },
                                new() { Name = "Champinero" },
                                new() { Name = "Santa fe" },
                                new() { Name = "Useme" },
                                new() { Name = "Bosa" },
                            ]
                         },
                      ]
                });

                _context.Countries.Add(new Country
                {
                    Name = "Estados Unidos",
                    States = [

                       new State()
                       {
                           Name = "Florida",
                           Cities = [
                                new() { Name = "Orlando" },
                                new() { Name = "Miami" },
                                new() { Name = "Tampa" },
                                new() { Name = "Fort Lauderdale" },
                                new() { Name = "Key West" },
                           ]
                       },
                       new State()
                       {
                            Name = "Texas",
                            Cities = [
                                new() { Name = "Houston" },
                                new() { Name = "San Antonio" },
                                new() { Name = "Dallas" },
                                new() { Name = "Austin" },
                                new() { Name = "El Paso" },

                            ]
                       },
                    ]
                });
            }

            await _context.SaveChangesAsync();
        }


        //private async Task CheckCategoriesAsync()
        //{
        //    if (!_context.Categories.Any())
        //    {
        //        _context.Categories.Add(new Category { Name = "Calzado" });
        //        _context.Categories.Add(new Category { Name = "Tecnología" });
        //    }

        //    await _context.SaveChangesAsync();
        //}

    }
}
