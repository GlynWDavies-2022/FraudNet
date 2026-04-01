namespace FraudNet.API.Services;

public class LocalMailService(IConfiguration configuration) : IMailService
{
    private string _mailTo = configuration["MailSettings:mailToAddress"] ?? throw new ArgumentNullException("MailSettings:mailToAddress");
    private string _mailFrom = configuration["MailSettings:mailToAddress"] ?? throw new ArgumentNullException("MailSettings:mailToAddress");

    public void Send(string subject, string message)
    {
        Console.WriteLine($"Mail from {_mailFrom} to {_mailTo}, with {nameof(LocalMailService)}");
        Console.WriteLine($"Subject: {subject}");
        Console.WriteLine($"Message: {message}");
    }
}
