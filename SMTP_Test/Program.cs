
using System;
using System.Net;
using System.Net.Mail;

namespace SMTP_Test
{
    internal class Program
    {
        static string fromMail = "sahibsemizade340@gmail.com";
        static string appPassword = "ebjv gmps rcya izwg";

        static void Main(string[] args)
        {
            Console.Write("Ad: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("E-mail: ");
            string toMail = Console.ReadLine() ?? "";

            Console.Write("Şifrə: ");
            string password = Console.ReadLine() ?? "";

            Random random = new Random();
            string code = random.Next(100000, 1000000).ToString();

            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(fromMail);
                mail.To.Add(toMail);
                mail.Subject = "Tesdiq kodu";
                mail.Body = $"Salam {name}, tesdiq kodunuz: {code}";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials =
                    new NetworkCredential(fromMail, appPassword);

                smtp.Send(mail);
                Console.WriteLine("Kod e-maile gonderildi!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Xeta: " + ex.Message);
                return;
            }

            DateTime limit = DateTime.Now.AddMinutes(3);

            for (int i = 0; i < 3; i++)
            {
                if (DateTime.Now >= limit)
                {
                    Console.WriteLine("Kodun vaxtı bitdi!");
                    return;
                }

                Console.Write("Tesdiq kodu: ");
                string entered = Console.ReadLine() ?? "";

                if (DateTime.Now >= limit)
                {
                    Console.WriteLine("Kodun vaxtı bitdi!");
                    return;
                }

                if (entered == code)
                {
                    Console.WriteLine("Qeydiyyat uğurla tamamlandı!");
                    return;
                }

               
            }

            Console.WriteLine("Cehd limiti bitdi!");
        }
    }
}
