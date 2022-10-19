namespace Core.Interfaces;

public interface IEmailService
{
  Task SendEmail(string htmlEmailContent, string title, string to);
}