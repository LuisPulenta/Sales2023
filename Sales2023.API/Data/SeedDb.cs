using Microsoft.EntityFrameworkCore;
using Sales2023.API.Helpers;
using Sales2023.API.Services;
using Sales2023.Shared.Entities;
using Sales2023.Shared.Enums;
using Sales2023.Shared.Responses;

namespace Sales2023.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IApiService _apiService;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IApiService apiService, IUserHelper userHelper)
        {
            _context = context;
            _apiService = apiService;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCountriesAsync();
            await CheckCategoriesAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1010", "Luis", "Nùñez", "luis@yopmail.com", "156 814 963", "Espora 2052", UserType.Admin);
        }

        private async Task<User> CheckUserAsync(string document, string firstName, string lastName, string email, string phone, string address, UserType userType)
        {
            var user = await _userHelper.GetUserAsync(email);
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
                    City = _context.Cities.FirstOrDefault(),
                    UserType = userType,
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }

            return user;
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }


        private async Task CheckCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                Response responseCountries = await _apiService.GetListAsync<CountryResponse>("/v1", "/countries");
                if (responseCountries.IsSuccess)
                {
                    List<CountryResponse> countries = (List<CountryResponse>)responseCountries.Result!;
                    foreach (CountryResponse countryResponse in countries)
                    {
                        Country country = await _context.Countries!.FirstOrDefaultAsync(c => c.Name == countryResponse.Name!)!;
                        if (country == null)
                        {
                            country = new() { Name = countryResponse.Name!, States = new List<State>() };
                            Response responseStates = await _apiService.GetListAsync<StateResponse>("/v1", $"/countries/{countryResponse.Iso2}/states");
                            if (responseStates.IsSuccess)
                            {
                                List<StateResponse> states = (List<StateResponse>)responseStates.Result!;
                                foreach (StateResponse stateResponse in states!)
                                {
                                    State state = country.States!.FirstOrDefault(s => s.Name == stateResponse.Name!)!;
                                    if (state == null)
                                    {
                                        state = new() { Name = stateResponse.Name!, Cities = new List<City>() };
                                        Response responseCities = await _apiService.GetListAsync<CityResponse>("/v1", $"/countries/{countryResponse.Iso2}/states/{stateResponse.Iso2}/cities");
                                        if (responseCities.IsSuccess)
                                        {
                                            List<CityResponse> cities = (List<CityResponse>)responseCities.Result!;
                                            foreach (CityResponse cityResponse in cities)
                                            {
                                                if (cityResponse.Name == "Mosfellsbær" || cityResponse.Name == "Șăulița")
                                                {
                                                    continue;
                                                }
                                                City city = state.Cities!.FirstOrDefault(c => c.Name == cityResponse.Name!)!;
                                                if (city == null)
                                                {
                                                    state.Cities.Add(new City() { Name = cityResponse.Name! });
                                                }
                                            }
                                        }
                                        if (state.CitiesNumber > 0)
                                        {
                                            country.States.Add(state);
                                        }
                                    }
                                }
                            }
                            if (country.StatesNumber > 0)
                            {
                                _context.Countries.Add(country);
                                await _context.SaveChangesAsync();
                            }
                        }
                    }
                }
            }
        }

        private async Task CheckCategoriesAsync()
        {
            if (!_context.Categories.Any())
            {
                _context.Categories.Add(new Category { Name = "Tecnología" });
                _context.Categories.Add(new Category { Name = "Deportes" });
                _context.Categories.Add(new Category { Name = "Juguetes" });
                _context.Categories.Add(new Category { Name = "Carnicería" });
                _context.Categories.Add(new Category { Name = "Verdulería" });
                _context.Categories.Add(new Category { Name = "Panadería" });
                _context.Categories.Add(new Category { Name = "Frutas" });
                _context.Categories.Add(new Category { Name = "Fiambres y Quesos" });
                _context.Categories.Add(new Category { Name = "Pescadería" });
                _context.Categories.Add(new Category { Name = "Bebidas" });
                _context.Categories.Add(new Category { Name = "Golosinas" });
                _context.Categories.Add(new Category { Name = "Galletas y galletitas" });
                _context.Categories.Add(new Category { Name = "Perfumería" });
                _context.Categories.Add(new Category { Name = "Bazar" });
                _context.Categories.Add(new Category { Name = "Librería" });
                _context.Categories.Add(new Category { Name = "Jardín" });
                _context.Categories.Add(new Category { Name = "Herramientas" });
                _context.Categories.Add(new Category { Name = "Embutidos" });
                _context.Categories.Add(new Category { Name = "Zapatería" });
                _context.Categories.Add(new Category { Name = "Informática" });
                _context.Categories.Add(new Category { Name = "Celulares" });
                _context.Categories.Add(new Category { Name = "Maquillaje" });
                _context.Categories.Add(new Category { Name = "Belleza" });
            }
            await _context.SaveChangesAsync();
        }


    }
}
