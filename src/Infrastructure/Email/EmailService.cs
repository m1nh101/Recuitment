using Core.Interfaces;
using Mailjet.Client;
using Mailjet.Client.Resources;
using Mailjet.Client.TransactionalEmails;

namespace Infrastructure.Email;

public class EmailService : IEmailService
{
  private readonly IMailjetClient _client;
	private readonly MailjetRequest _request;
	private const string _sender = "minh.xcode@gmail.com";


  public EmailService(IMailjetClient client)
	{
		_client = client;
		_request = new MailjetRequest()
		{
			Resource = Send.Resource
		};
	}

	public Task SendEmail(string htmlEmailContent, string title, string to)
	{
    var email = new TransactionalEmailBuilder()
      .WithFrom(new SendContact(_sender))
      .WithSubject(title)
      .WithHtmlPart(htmlEmailContent)
      .WithTo(new SendContact(to))
      .Build();

		Task.Run(async () =>
		{
			_ = await _client.SendTransactionalEmailAsync(email);
		});

		return Task.CompletedTask;
  }
}