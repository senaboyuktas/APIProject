using HotelProject.WebUI.Models.Mail;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace HotelProject.WebUI.Controllers
{
    public class AdminMailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AdminMailViewModel model)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Hotelier", "sevvalsenabuyuktas@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("Kullanıcı", model.RecevierEmail);
            mimeMessage.To.Add(mailboxAddressTo);

            mimeMessage.Subject = model.Subject;

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = model.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("sevvalsenabuyuktas@gmail.com", "şifreyi buraya yaz");
            client.Send(mimeMessage);
            client.Disconnect(true);

            //Gönderilen Mailin Veri Tabanına Kaydedilmesi.

            return RedirectToAction("Sendbox", "AdminContact");
        }
    }
}
