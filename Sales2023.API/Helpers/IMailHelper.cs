using Sales2023.Shared.Responses;

namespace Sales2023.API.Helpers
{
    public interface IMailHelper
    {
        Response SendMail(string toName, string toEmail, string subject, string body);
    }

}
