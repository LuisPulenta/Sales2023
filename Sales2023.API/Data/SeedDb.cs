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
        private readonly IFileStorage _fileStorage;

        public SeedDb(DataContext context, IApiService apiService, IUserHelper userHelper, IFileStorage fileStorage)
        {
            _context = context;
            _apiService = apiService;
            _userHelper = userHelper;
            _fileStorage = fileStorage;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCountriesAsync();
            await CheckCategoriesAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1001", "Luis", "Núñez", "luis@yopmail.com", "156 814 963", "Espora 2052", "luis.jpg", UserType.Admin);
            await CheckUserAsync("1002", "Gabriel", "Batistuta", "batistuta@yopmail.com", "111 111 002", "Reconquista","batistuta.jpg", UserType.User);
            await CheckUserAsync("1003", "Daniel", "Martinez", "daniel@yopmail.com", "111 111 003", "Mendiolaza", "daniel.jpg", UserType.User);
            await CheckUserAsync("1004", "Roger", "Federer", "federer@yopmail.com", "111 111 004", "Suiza", "federer.jpg", UserType.User);
            await CheckUserAsync("1005", "Mario", "Kempes", "kempes@yopmail.com", "111 111 005", "Bell Ville", "kempes.jpg", UserType.User);
            await CheckUserAsync("1006", "Lucas", "Martinez", "lucas@yopmail.com", "111 111 006", "Mendiolaza", "lucas.jpg", UserType.User);
            await CheckUserAsync("1007", "Diego", "Maradona", "maradona@yopmail.com", "111 111 007", "Villa Fiorito", "maradona.jpg", UserType.User);
            await CheckUserAsync("1008", "Marina", "Martinez", "marina@yopmail.com", "111 111 008", "Valencia", "marina.jpg", UserType.User);
            await CheckUserAsync("1009", "Lionel", "Messi", "messi@yopmail.com", "111 111 009", "París", "messi.jpg", UserType.User);
            await CheckUserAsync("1010", "Rafael", "Nadal", "nadal@yopmail.com", "111 111 010", "Madrid", "nadal.jpg", UserType.User);
            await CheckUserAsync("1011", "Pablo", "Lacuadri", "pablo@yopmail.com", "111 111 011", "Villa Santa Ana", "pablo.jpg", UserType.Admin);
            await CheckProductsAsync();
        }

        private async Task CheckProductsAsync()
        {
            if (!_context.Products.Any())
            {
                await AddProductAsync("Aguardiente", 1800M, 40F, new List<string>() { "Bebidas" }, new List<string>() { "aguardiente.jpg" });
                await AddProductAsync("Cerveza", 1810M, 60F, new List<string>() { "Bebidas" }, new List<string>() { "cerveza.jpg" });
                await AddProductAsync("Coca Cola", 880M, 57F, new List<string>() { "Bebidas" }, new List<string>() { "cocacola.jpg" });
                await AddProductAsync("Fanta", 870M, 17F, new List<string>() { "Bebidas" }, new List<string>() { "fanta.jpg" });
                await AddProductAsync("Pepsi", 1000M, 87F, new List<string>() { "Bebidas" }, new List<string>() { "pepsi.jpg" });
                await AddProductAsync("Ron añejo", 2000M, 53F, new List<string>() { "Bebidas" }, new List<string>() { "ronaniejo.jpg" });
                await AddProductAsync("Sprite", 1890M, 62F, new List<string>() { "Bebidas" }, new List<string>() { "sprite.jpg" });
                await AddProductAsync("Tequila", 860M, 63F, new List<string>() { "Bebidas" }, new List<string>() { "tequila.jpg" });
                await AddProductAsync("Vino espumoso brut royal", 620M, 64F, new List<string>() { "Bebidas" }, new List<string>() { "vinoespumosobrutroyal.jpg" });
                await AddProductAsync("Vino espumoso demisec", 1310M, 14F, new List<string>() { "Bebidas" }, new List<string>() { "vinoespumosodemisec.jpg" });
                await AddProductAsync("Vino tinto", 880M, 10F, new List<string>() { "Bebidas" }, new List<string>() { "vinotinto.jpg" });
                await AddProductAsync("Vino tinto malbec", 750M, 65F, new List<string>() { "Bebidas" }, new List<string>() { "vinotintomalbec.jpg" });
                await AddProductAsync("Vodka", 1520M, 22F, new List<string>() { "Bebidas" }, new List<string>() { "vodka.jpg" });
                await AddProductAsync("Whisky", 1150M, 62F, new List<string>() { "Bebidas" }, new List<string>() { "whisky.jpg" });
                await AddProductAsync("Maquina de afeitar", 1450M, 19F, new List<string>() { "Belleza" }, new List<string>() { "maquinadeafeitar.jpg" });
                await AddProductAsync("Balon de futbol FIFA 2014", 2310M, 54F, new List<string>() { "Deportes" }, new List<string>() { "balondefutbolfifa2014.jpg" });
                await AddProductAsync("Caminadora", 1620M, 55F, new List<string>() { "Deportes" }, new List<string>() { "caminadora.jpg" });
                await AddProductAsync("Camiseta de Talleres", 1540M, 91F, new List<string>() { "Deportes", "Indumentaria" }, new List<string>() { "camisetatalleres.jpg" });
                await AddProductAsync("Casco zoom bk", 1240M, 87F, new List<string>() { "Deportes" }, new List<string>() { "cascozoombk.jpg" });
                await AddProductAsync("Colchonetas", 2460M, 60F, new List<string>() { "Deportes" }, new List<string>() { "colchonetas.jpg" });
                await AddProductAsync("Mancuernas", 2560M, 40F, new List<string>() { "Deportes" }, new List<string>() { "mancuernas.jpg" });
                await AddProductAsync("Patines zoom chasis aluminio", 3560M, 32F, new List<string>() { "Deportes" }, new List<string>() { "patineszoomchasisaluminio.jpg" });
                await AddProductAsync("Patineta", 4880M, 84F, new List<string>() { "Deportes" }, new List<string>() { "patineta.jpg" });
                await AddProductAsync("Raquetas", 2430M, 69F, new List<string>() { "Deportes" }, new List<string>() { "raquetas.jpg" });
                await AddProductAsync("Silbato profesional", 3170M, 14F, new List<string>() { "Deportes" }, new List<string>() { "silbatoprofesional.jpg" });
                await AddProductAsync("Bananas brasileras", 240M, 59F, new List<string>() { "Frutas" }, new List<string>() { "bananasbrasileras.jpg" });
                await AddProductAsync("Ciruela", 380M, 24F, new List<string>() { "Frutas" }, new List<string>() { "ciruela.jpg" });
                await AddProductAsync("Mandarinas", 330M, 74F, new List<string>() { "Frutas" }, new List<string>() { "mandarinas.jpg" });
                await AddProductAsync("Mango", 480M, 21F, new List<string>() { "Frutas" }, new List<string>() { "mango.jpg" });
                await AddProductAsync("Manzana", 330M, 67F, new List<string>() { "Frutas" }, new List<string>() { "manzana.jpg" });
                await AddProductAsync("Maracuyá", 300M, 14F, new List<string>() { "Frutas" }, new List<string>() { "maracuya.jpg" });
                await AddProductAsync("Melocotón", 100M, 55F, new List<string>() { "Frutas" }, new List<string>() { "melocoton.jpg" });
                await AddProductAsync("Melón", 250M, 63F, new List<string>() { "Frutas" }, new List<string>() { "melon.jpg" });
                await AddProductAsync("Papaya", 420M, 84F, new List<string>() { "Frutas" }, new List<string>() { "papaya.jpg" });
                await AddProductAsync("Peras", 260M, 40F, new List<string>() { "Frutas" }, new List<string>() { "peras.jpg" });
                await AddProductAsync("Plátano", 230M, 42F, new List<string>() { "Frutas" }, new List<string>() { "platano.jpg" });
                await AddProductAsync("Pomelo", 320M, 13F, new List<string>() { "Frutas" }, new List<string>() { "pomelo.jpg" });
                await AddProductAsync("Sandía", 410M, 33F, new List<string>() { "Frutas" }, new List<string>() { "sandia.jpg" });
                await AddProductAsync("Tamarindo", 160M, 74F, new List<string>() { "Frutas" }, new List<string>() { "tamarindo.jpg" });
                await AddProductAsync("Uva", 280M, 98F, new List<string>() { "Frutas" }, new List<string>() { "uva.jpg" });
                await AddProductAsync("Arandela", 40M, 19F, new List<string>() { "Herramientas" }, new List<string>() { "arandela.jpg" });
                await AddProductAsync("Bicicleta de Ironman", 5210M, 45F, new List<string>() { "Juguetes" }, new List<string>() { "bicicletadeironman.jpg" });
                await AddProductAsync("Bicicleta de niño", 3520M, 89F, new List<string>() { "Juguetes" }, new List<string>() { "bicicletadeninio.jpg" });
                await AddProductAsync("Bicicleta de ruta", 2550M, 60F, new List<string>() { "Juguetes" }, new List<string>() { "bicicletaderuta.jpg" });
                await AddProductAsync("Bicicleta estática", 7420M, 53F, new List<string>() { "Juguetes" }, new List<string>() { "bicicletaestatica.jpg" });
                await AddProductAsync("Flotador en forma de delfín", 2520M, 19F, new List<string>() { "Juguetes" }, new List<string>() { "flotadorenformadedelfin.jpg" });
                await AddProductAsync("Juego de mesa", 2670M, 66F, new List<string>() { "Juguetes" }, new List<string>() { "juegodemesa.jpg" });
                await AddProductAsync("Mesa de ping pong", 2340M, 43F, new List<string>() { "Juguetes" }, new List<string>() { "mesadepingpong.jpg" });
                await AddProductAsync("Monopatín", 3340M, 74F, new List<string>() { "Juguetes" }, new List<string>() { "monopatin.jpg" });
                await AddProductAsync("Pelota de playa", 9340M, 31F, new List<string>() { "Juguetes" }, new List<string>() { "pelota de playa.jpg" });
                await AddProductAsync("Teatro en casa", 7990M, 66F, new List<string>() { "Juguetes" }, new List<string>() { "teatroencasa.jpg" });
                await AddProductAsync("Triciclo", 8240M, 71F, new List<string>() { "Juguetes" }, new List<string>() { "triciclo.jpg.jpg" });
                await AddProductAsync("Trompo", 2500M, 54F, new List<string>() { "Juguetes" }, new List<string>() { "trompo.jpg" });
                await AddProductAsync("Applepencil", 86170M, 55F, new List<string>() { "Tecnología", "Apple", "Informática" }, new List<string>() { "applepencil.jpg", "applepencil2.jpg" });
                await AddProductAsync("Baffless", 46080M, 43F, new List<string>() { "Tecnología" }, new List<string>() { "baffless.jpg" });
                await AddProductAsync("Bluray", 36270M, 80F, new List<string>() { "Tecnología" }, new List<string>() { "bluray.jpg" });
                await AddProductAsync("Cámara digital Panasonic", 77310M, 44F, new List<string>() { "Tecnología", "Informática" }, new List<string>() { "camaradigitalpanasonic.jpg" });
                await AddProductAsync("Impresora Canon", 85190M, 74F, new List<string>() { "Tecnología", "Informática" }, new List<string>() { "impresoracanon.jpg" });
                await AddProductAsync("Ipad", 17850M, 15F, new List<string>() { "Tecnología", "Apple", "Informática" }, new List<string>() { "ipad.jpg", "ipad2.jpg", "ipad3.jpg" });
                await AddProductAsync("Iphone5", 18710M, 37F, new List<string>() { "Tecnología", "Apple", "Informática" }, new List<string>() { "iphone5.jpg" });
                await AddProductAsync("IphoneX", 28670M, 16F, new List<string>() { "Tecnología", "Apple", "Informática" }, new List<string>() { "iphoneX.jpg", "iphoneX2.jpg", "iphoneX3.jpg", "iphoneX4.jpg" });
                await AddProductAsync("Laptop Acer", 58070M, 53F, new List<string>() { "Tecnología", "Informática" }, new List<string>() { "laptopacer.jpg" });
                await AddProductAsync("Laptop Dell", 7380M, 82F, new List<string>() { "Tecnología", "Informática" }, new List<string>() { "laptopdell.jpg" });
                await AddProductAsync("Macbook Air", 5150M, 94F, new List<string>() { "Tecnología", "Apple", "Informática" }, new List<string>() { "macbookair.jpg" });
                await AddProductAsync("Microondas", 8440M, 85F, new List<string>() { "Tecnología" }, new List<string>() { "microondas.jpg" });
                await AddProductAsync("Notebook", 87460M, 74F, new List<string>() { "Tecnología", "Informática" }, new List<string>() { "notebook.jpg", "notebook2.jpg", "notebook3.jpg", "notebook4.jpg", "notebook5.jpg" });
                await AddProductAsync("Portátil touch Hewlett Packard", 69160M, 70F, new List<string>() { "Tecnología", "Informática" }, new List<string>() { "portatiltouchhewlettpackard.jpg" });
                await AddProductAsync("Samsung Galaxy S5", 4790M, 33F, new List<string>() { "Tecnología" }, new List<string>() { "samsunggalaxys5.jpg" });
                await AddProductAsync("Tablet Intel 7", 65940M, 82F, new List<string>() { "Tecnología", "Informática" }, new List<string>() { "tabletintel7.jpg" });
                await AddProductAsync("Televisión de 42 pulgadas", 4070M, 64F, new List<string>() { "Tecnología" }, new List<string>() { "televisionde42pulgadas.jpg" });
                await AddProductAsync("Televisión Sony Bravia", 83880M, 77F, new List<string>() { "Tecnología" }, new List<string>() { "televisionsonybravia.jpg" });
                await AddProductAsync("Tv led Samsung", 71870M, 97F, new List<string>() { "Tecnología" }, new List<string>() { "tvledsamsung.jpg" });
                await AddProductAsync("Xbox 360", 77150M, 13F, new List<string>() { "Tecnología", "Juguetes" }, new List<string>() { "xbox360.jpg" });
                await AddProductAsync("Ajo", 440M, 40F, new List<string>() { "Verdulería" }, new List<string>() { "ajo.jpg" });
                await AddProductAsync("Apio", 120M, 10F, new List<string>() { "Verdulería" }, new List<string>() { "apio.jpg" });
                await AddProductAsync("Arveja", 300M, 10F, new List<string>() { "Verdulería" }, new List<string>() { "arveja.jpg" });
                await AddProductAsync("Brocoli", 330M, 65F, new List<string>() { "Verdulería" }, new List<string>() { "brocoli.jpg" });
                await AddProductAsync("Calabacin", 200M, 58F, new List<string>() { "Verdulería" }, new List<string>() { "calabacin.jpg" });
                await AddProductAsync("Calabaza", 230M, 26F, new List<string>() { "Verdulería" }, new List<string>() { "calabaza.jpg" });
                await AddProductAsync("Cebolla", 320M, 54F, new List<string>() { "Verdulería" }, new List<string>() { "cebolla.jpg" });
                await AddProductAsync("Col", 280M, 23F, new List<string>() { "Verdulería" }, new List<string>() { "col.jpg" });
                await AddProductAsync("Esparragos", 370M, 72F, new List<string>() { "Verdulería" }, new List<string>() { "esparragos.jpg" });
                await AddProductAsync("Espinaca", 340M, 59F, new List<string>() { "Verdulería" }, new List<string>() { "espinaca.jpg" });
                await AddProductAsync("Frijoles", 390M, 26F, new List<string>() { "Verdulería" }, new List<string>() { "frijoles.jpg" });
                await AddProductAsync("Guayaba", 420M, 56F, new List<string>() { "Verdulería" }, new List<string>() { "guayaba.jpg" });
                await AddProductAsync("Guisantes", 430M, 15F, new List<string>() { "Verdulería" }, new List<string>() { "guisantes.jpg" });
                await AddProductAsync("Habas", 500M, 40F, new List<string>() { "Verdulería" }, new List<string>() { "habas.jpg" });
                await AddProductAsync("Lechuga", 170M, 23F, new List<string>() { "Verdulería" }, new List<string>() { "lechuga.jpg" });
                await AddProductAsync("Nabos", 470M, 88F, new List<string>() { "Verdulería" }, new List<string>() { "nabos.jpg" });
                await AddProductAsync("Pepinos", 380M, 64F, new List<string>() { "Verdulería" }, new List<string>() { "pepinos.jpg" });
                await AddProductAsync("Pimientos", 180M, 51F, new List<string>() { "Verdulería" }, new List<string>() { "pimientos.jpg" });
                await AddProductAsync("Remolacha", 290M, 56F, new List<string>() { "Verdulería" }, new List<string>() { "remolacha.jpg" });
                await AddProductAsync("Repollo", 190M, 12F, new List<string>() { "Verdulería" }, new List<string>() { "repollo.jpg" });
                await AddProductAsync("Tomate", 170M, 91F, new List<string>() { "Verdulería" }, new List<string>() { "tomate.jpg" });
                await AddProductAsync("Zanahoria", 220M, 43F, new List<string>() { "Verdulería" }, new List<string>() { "zanahoria.jpg" });

                await _context.SaveChangesAsync();
            }
        }

        private async Task AddProductAsync(string name, decimal price, float stock, List<string> categories, List<string> images)
        {
            Product product = new()
            {
                Description = name,
                Name = name,
                Price = price,
                Stock = stock,
                ProductCategories = new List<ProductCategory>(),
                ProductImages = new List<ProductImage>()
            };

            foreach (var categoryName in categories)
            {
                var category = await _context.Categories.FirstOrDefaultAsync(c => c.Name == categoryName);
                if (category != null)
                {
                    product.ProductCategories.Add(new ProductCategory { Category = category });
                }
            }

            foreach (string? image in images)
            {
                var filePath = $"{Environment.CurrentDirectory}\\Images\\products\\{image}";
                var fileBytes = File.ReadAllBytes(filePath);
                var imagePath = await _fileStorage.SaveFileAsync(fileBytes, "jpg", "products");
                product.ProductImages.Add(new ProductImage { Image = imagePath });
            }

            _context.Products.Add(product);
        }


        private async Task<User> CheckUserAsync(string document, string firstName, string lastName, string email, string phone, string address, string image,UserType userType)
        {
            var user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                var city = await _context.Cities.FirstOrDefaultAsync(x => x.Name == "Córdoba");
                if (city == null)
                {
                    city = await _context.Cities.FirstOrDefaultAsync();
                }

                var filePath = $"{Environment.CurrentDirectory}\\Images\\users\\{image}";
                var fileBytes = File.ReadAllBytes(filePath);
                var imagePath = await _fileStorage.SaveFileAsync(fileBytes, "jpg", "users");


                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    City = city,
                    UserType = userType,
                    Photo = imagePath,
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());

                var token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                await _userHelper.ConfirmEmailAsync(user, token);


                //await _userHelper.AddUserAsync(user, "123456");
                //await _userHelper.AddUserToRoleAsync(user, userType.ToString());
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
                _context.Categories.Add(new Category { Name = "Apple" });
                _context.Categories.Add(new Category { Name = "Indumentaria" });
            }
            await _context.SaveChangesAsync();
        }
    }
}
