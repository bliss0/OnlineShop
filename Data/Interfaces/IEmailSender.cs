using OnlineShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace OnlineShop.Data.Interfaces
{
    interface IEmailSender
    {
        protected static async Task SendEmailAsync(string EmailAdressTo,IEnumerable<ShopCartItems> cartItems)
        {
            MailAddress from = new MailAddress("andrej.kozhan00@mail.ru", "Andrey");
            MailAddress to = new MailAddress(EmailAdressTo);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Подтверждение заказа";
            m.IsBodyHtml = true;
            m.Body = $"<h2>Вами был оформлен заказ:  </h2>\n" +
                "<ul>\n";
            foreach(var item in cartItems)
                m.Body+=$"<li>Автомобиль {item.car.name} цена: {item.price}</li>\n";
            m.Body += "</ul>\n";
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
            smtp.Credentials = new NetworkCredential("andrej.kozhan00@mail.ru", "HAGYJWiuccGUX2BLnmth");
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(m);
        }
    }
}
