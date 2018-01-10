
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;

namespace Helpers
{
    public class MailHelper
    {

        private readonly string _fromEmail;
        public string Subject { get; set; }
        public string Body { get; set; }
        public string ToEmail { get; set; }
        private readonly SmtpClient SmtpClient;
        private readonly string _password = "medicore123";

        public MailHelper(string toEmail,string subject, string body)
        {
            Subject = subject;
            Body = body;
            ToEmail = toEmail;
            _fromEmail = "wesaveyou.medicore@gmail.com";
            SmtpClient = new SmtpClient("smtp.gmail.com", 587);
        }

        public void Send()
        {
            var mailMessage = new MailMessage(_fromEmail, ToEmail, Subject, Body);
            SmtpClient.EnableSsl = true;
            SmtpClient.UseDefaultCredentials = false;
            SmtpClient.Credentials = new NetworkCredential(_fromEmail, _password);
            SmtpClient.Send(mailMessage);
        }
    }
}
