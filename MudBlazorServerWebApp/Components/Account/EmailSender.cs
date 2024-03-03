using System;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using MudBlazorServerWebApp.Data;
using Microsoft.Extensions.Configuration;



namespace MudBlazorServerWebApp.Components.Account;


public class EmailSender(ILogger<EmailSender> logger, IConfiguration configuration) : IEmailSender<ApplicationUser>
{
    private readonly ILogger logger = logger;
    private readonly IConfiguration conf = configuration;


    public Task SendConfirmationLinkAsync(ApplicationUser user, string email,
        string confirmationLink) => SendEmailAsync(email, "Confirm your email",
        $"Please confirm your account by clicking the link below\n{confirmationLink}");

    //  This is somewhat missleading because it is used when a user is registered by an Admin
    //  The admin cant choose a password, that is generated automaticly and the user gets to reset / choose a password by clicking the link.
    public Task SendPasswordResetLinkAsync(ApplicationUser user, string email,
        string resetLink) => SendEmailAsync(email, "No Reply",
        $"Welcome as a registered user, click the link to choose a password\n\n{resetLink}");

    public Task SendPasswordResetCodeAsync(ApplicationUser user, string email,
        string resetCode) => SendEmailAsync(email, "Reset your password",
        $"Please reset your password using the following code: {resetCode}");



    public async Task SendEmailAsync(string toEmail, string subject, string message)
    {
        await Execute(subject, message, toEmail);
    }

    public async Task Execute(string subject, string message, string toEmail)
    {
        string? emailAuthServer = conf.GetValue<string>("EmailAuth:MailServer");
        string? emailAuthLogin = conf.GetValue<string>("EmailAuth:UserName");
        string? emailAuthPassword = conf.GetValue<string>("EmailAuth:Password");
        var msg = new MimeMessage();

        msg.From.Add(new MailboxAddress("No Reply", "info@voine.se"));
        msg.To.Add(new MailboxAddress(toEmail, toEmail));
        msg.Subject = subject;

        msg.Body = new TextPart("plain") { Text = message };

        using (var client = new SmtpClient())
        {
            client.Connect(emailAuthServer, 8889, false);
            client.Authenticate(emailAuthLogin, emailAuthPassword);
            
            
            await client.SendAsync(msg);            
            client.Disconnect(true);
        }       
    }
}