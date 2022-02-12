using StrategyPattern.Strategies;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace StrategyPattern.Strategy
{
    class EmailWorker : ISendWorker
    {
        private string msg;
        private string endEmail;
        public EmailWorker(string msg, string endEmail)
        {
            this.msg = msg;
            this.endEmail = endEmail;
        }

        public string Send()
        {
            try
            {
                // отправитель - устанавливаем адрес и отображаемое в письме имя
                MailAddress from = new MailAddress("MyAdress@gmail.com", "Vladimir");
                // кому отправляем
                MailAddress to = new MailAddress(endEmail);
                // создаем объект сообщения
                MailMessage m = new MailMessage(from, to);
                // тема письма
                m.Subject = "Strategy pattern";
                // текст письма
                m.Body = msg;
                // письмо представляет код html
                m.IsBodyHtml = true;
                // адрес smtp-сервера и порт, с которого будем отправлять письмо
                var getSmtp = new string("MyAdress@gmail.com".Remove(0, endEmail.LastIndexOf("@") +2).ToArray());
                SmtpClient smtp = new SmtpClient($"smtp.{getSmtp}", 587);
                // логин и пароль
                smtp.Credentials = new NetworkCredential("MyAdress@gmail.com", "MyPassword");
                smtp.EnableSsl = true;            
                smtp.Send(m);
                return $"The document has been sent to adress -{endEmail}";
            }
            catch (Exception ex)
            {
                return $"The document has not been send to adress -{endEmail}-{ex}";
            }
        }
    }
}
