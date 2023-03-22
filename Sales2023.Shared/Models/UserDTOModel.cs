using Microsoft.AspNetCore.Http;
using Sales2023.Shared.DTOs;
using System.ComponentModel.DataAnnotations;


namespace Sales2023.Shared.Models
{
    public class UserDTOModel:UserDTO
    {
        [Display(Name = "Foto")]
        public string? ImageId { get; set; }

        [Display(Name = "Foto")]
        public string ImageFullPath => string.IsNullOrEmpty(ImageId)
            ? "https://localhost:7181/images/nouser.png"
            : $"https://localhost:7181{ImageId.Substring(1)}";
        //? $"http://keypress.serveftp.net:99/ShoppingApi/Images/nouser.png"
        //: $"http://keypress.serveftp.net:99/ShoppingApi{ImageId.Substring(1)}";


        [Display(Name = "Foto")]
        public IFormFile? ImageFile { get; set; }
    }
}
