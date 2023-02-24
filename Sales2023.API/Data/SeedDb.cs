using Sales.Shared.Entities;
using Sales2023.Shared.Entities;

namespace Sales2023.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCountriesAsync();
            await CheckCategoriesAsync();
        }

        private async Task CheckCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new Country
                {
                    Name = "Argentina",
                    States = new List<State>()
                    {
                    new State()
                        {
                            Name = "Córdoba",
                            Cities = new List<City>() {
                                new City() { Name = "Córdoba" },
                                new City() { Name = "Río Cuarto" },
                                new City() { Name = "Villa María" },
                                new City() { Name = "Carlos Paz" },
                                new City() { Name = "San Francisco" },
                            }
                        },
                    new State()
                        {
                            Name = "Santa Fe",
                            Cities = new List<City>() {
                                new City() { Name = "Rosario" },
                                new City() { Name = "Santa Fe" },
                                new City() { Name = "Venado Tuerto" },
                                new City() { Name = "Rafaela" },
                        }
                    },
                }
              });
                _context.Countries.Add(new Country
                {
                    Name = "Estados Unidos",
                    States = new List<State>()
                    {
                    new State()
                        {
                            Name = "California",
                            Cities = new List<City>() {
                                new City() { Name = "Los Angeles" },
                                new City() { Name = "San Francisco" },
                            }
                        },
                    new State()
                        {
                            Name = "Texas",
                            Cities = new List<City>() {
                                new City() { Name = "Houston" },
                                new City() { Name = "Dallas" },
                                new City() { Name = "San Antonio" },
                        }
                    },
                      new State()
                        {
                            Name = "Florida",
                            Cities = new List<City>() {
                                new City() { Name = "Orlando" },
                                new City() { Name = "Miami" },
                                new City() { Name = "Tampa" },
                                new City() { Name = "Fort Lauderdale" },
                                new City() { Name = "Key West" },
                        }
                },
                }
                });
                _context.Countries.Add(new Country { Name = "Brasil" });
                _context.Countries.Add(new Country { Name = "Colombia" });
                _context.Countries.Add(new Country { Name = "Uruguay" });
            }

            await _context.SaveChangesAsync();
        }

        private async Task CheckCategoriesAsync()
        {
            if (!_context.Categories.Any())
            {
                _context.Categories.Add(new Category { Name = "Tecnología" });
                _context.Categories.Add(new Category { Name = "Juegos" });
                _context.Categories.Add(new Category { Name = "Deportes" });
                _context.Categories.Add(new Category { Name = "Indumentaria" });
            }

            await _context.SaveChangesAsync();
        }
    }
}