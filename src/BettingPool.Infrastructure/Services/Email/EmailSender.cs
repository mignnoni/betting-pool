using BettingPool.Application.Users.Abstractions;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Options;

namespace BettingPool.Infrastructure.Services.Email;

public class EmailSender(
    IOptions<EmailSenderOptions> options) : IEmailSender
{
    private readonly EmailSenderOptions _options = options.Value;

    public async Task PasswordReseted(string name, string email, CancellationToken cancellationToken = default)
    {
        var client = new SmtpClient
        {
            EnableSsl = true,
            Port = 587,
            Host = "smtp.gmail.com",
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(_options.FromEmail, _options.ApiKey),
            DeliveryMethod = SmtpDeliveryMethod.Network
        };

        var message = new MailMessage();

        message.From = new MailAddress(_options.FromEmail, _options.FromName);
        message.Subject = "Sua senha foi alterada com sucesso";
        message.To.Add(new MailAddress(email, name));

        var htmlContent = $"<string>Olá {name}, sua senha foi redefinida com sucesso.</strong>";

        message.IsBodyHtml = true;
        message.Body = htmlContent;

        await client.SendMailAsync(message, cancellationToken);
    }

    public async Task SendTokenToResetPassword(string name, string email, string token, CancellationToken cancellationToken = default)
    {
        var client = new SmtpClient();

        client.EnableSsl = true;
        client.Port = 587;
        client.Host = "smtp.gmail.com";
        client.UseDefaultCredentials = false;
        client.Credentials = new NetworkCredential(_options.FromEmail, _options.ApiKey);
        client.DeliveryMethod = SmtpDeliveryMethod.Network;

        var message = new MailMessage();

        message.From = new MailAddress(_options.FromEmail, _options.FromName);
        message.To.Add(new MailAddress(email, name));
        message.Subject = "Recupere a sua senha";

        var link = $"http://localhost:5173/redefinir-senha?token={token}";

        var htmlContent = GenerateHtmlContent(name, link);

        message.IsBodyHtml = true;
        message.Body = htmlContent;

        await client.SendMailAsync(message, cancellationToken);
    }

    private static string GenerateHtmlContent(string name, string link)
    {
        return $@"
            <html lang='en'>
            <head>
                <meta charset='UTF-8'>
                <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                <title>Documento</title>
                <style>
                    body {{
                        margin: 0;
                        padding: 0;
                        background-color: #ffffff; /* Fundo branco */
                    }}
                    .container {{
                        max-width: 600px; /* Largura máxima de 600px */
                        margin: 0 auto; /* Centraliza o conteúdo */
                        padding: 20px; /* Adiciona um espaçamento interno */
                    }}
                    .titulo {{
                        color: #333333; /* Cor do texto */
                        font-size: 24px; /* Tamanho da fonte */
                        font-weight: bold; /* Negrito */
                    }}
                    .botao {{
                        display: inline-block;
                        padding: 10px 20px;
                        background-color: #007bff; /* Cor do botão */
                        color: #ffffff; /* Cor do texto do botão */
                        text-decoration: none; /* Remove sublinhado */
                        border-radius: 5px; /* Cantos arredondados */
                        margin-top: 20px; /* Espaçamento superior */
                    }}
                    /* Adicione mais estilos conforme necessário */
                </style>
            </head>
            <body>
                <div class='container'>
                    <h1 class='titulo'>Olá, {name}!</h1>
                    <p>Para redefinir a sua senha, clique no link abaixo.</p>
                    <a href='{link}' class='botao'>Redefinir senha</a>
                </div>
            </body>
            </html>";
    }

}
