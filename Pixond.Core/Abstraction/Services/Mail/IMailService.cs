namespace Pixond.Core.Abstraction.Services.Mail
{
    public interface IMailService
    {
        bool SendMail(string fromUsername, string toAddress, string subject, string body);
    }
}
