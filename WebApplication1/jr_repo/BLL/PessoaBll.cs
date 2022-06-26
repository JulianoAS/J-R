using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jr_repo.DAL;
using System.Net.Mail;
using System.Net;

namespace jr_repo
{
   public class PessoaBll
    {
        public int Incluir(Pessoa pessoa)
        {                     
                PessoaDal _pessoa = new PessoaDal();
                return _pessoa.Incluir(pessoa);              
        }

        public bool EnviarMsg(Pessoa pessoa)
        {
            try 
            {
                MailMessage _mailMessage = new MailMessage();
                StringBuilder text = new StringBuilder();
                
                text.Append(pessoa.Nome);
                text.Append("</br>");
                text.Append(pessoa.Email);
                text.Append("</br>");
                text.Append(pessoa.Mensagem);


                _mailMessage.From = new MailAddress("", "");
                _mailMessage.To.Add("");
                //_mailMessage.Bcc.Add("");
                _mailMessage.Subject = "Orçamento";
                _mailMessage.IsBodyHtml = true;                
                _mailMessage.Body = text.ToString();


                SmtpClient _smtpClient = new SmtpClient("", 587);
                NetworkCredential credential = new NetworkCredential("", "");

                _smtpClient.UseDefaultCredentials = false;            
                _smtpClient.Credentials = credential;
                _smtpClient.EnableSsl =true;
                
                _smtpClient.Send(_mailMessage);               
                return true;

            }
            catch(SmtpException ex )
            {
               return false;
            }


        }

    }
}
