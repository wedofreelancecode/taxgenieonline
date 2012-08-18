using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace TaxGenieOnline
{
    public partial class pwdrecovery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void PasswordRecovery1_SendingMail(object sender, MailMessageEventArgs e)
        {
            try
            {
                MailMessage oMail = new MailMessage();
                oMail.From = new MailAddress("taxgenieonline@gmail.com");
                oMail.To.Add(new MailAddress(PasswordRecovery1.UserName));

                SmtpClient client = new SmtpClient();
                client.EnableSsl = true;
                client.Send(oMail);

                oMail = null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
