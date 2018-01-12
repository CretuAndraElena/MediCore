using System;
using System.Net;
using System.Net.Mail;

namespace Utils
{
    public class MailUtils
    {
        private readonly string _fromEmail;
        public string Subject { get; set; }
        public string Body { get; set; }
        public string ToEmail { get; set; }
        private readonly SmtpClient _smtpClient;
        private readonly string _password = "medicore123";

        public MailUtils(string toEmail, string subject, string body)
        {
            Subject = subject;
            Body = body;
            ToEmail = toEmail;
            _fromEmail = "wesaveyou.medicore@gmail.com";
            _smtpClient = new SmtpClient("smtp.gmail.com", 587);
        }

        public void Send()
        {
            var mailMessage = new MailMessage(_fromEmail, ToEmail, Subject, Body);
            _smtpClient.EnableSsl = true;
            _smtpClient.UseDefaultCredentials = false;
            _smtpClient.Credentials = new NetworkCredential(_fromEmail, _password);
            _smtpClient.Send(mailMessage);
        }
    }
}
