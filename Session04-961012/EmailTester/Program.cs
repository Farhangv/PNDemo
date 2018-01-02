using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailTester
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Credentials:
                var credentialUserName = "noreply@parsneginit.com";
                var sentFrom = "noreply@parsneginit.com";
                var pwd = "PARS2014negin";

                // Configure the client:
                System.Net.Mail.SmtpClient client =
                    new System.Net.Mail.SmtpClient("mail.parsneginit.com");

                client.Port = 587;
                client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;

                // Creatte the credentials:
                System.Net.NetworkCredential credentials =
                    new System.Net.NetworkCredential(credentialUserName, pwd);

                client.EnableSsl = false;
                client.Credentials = credentials;

                // Create the message:
                var mail =
                    new System.Net.Mail.MailMessage(sentFrom, "farhangv@live.com");

                mail.Subject = "TEST";
                mail.Body = "TEST";

                // Send:
                client.Send(mail);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
