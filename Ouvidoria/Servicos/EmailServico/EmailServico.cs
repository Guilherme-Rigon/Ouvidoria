﻿using Microsoft.Extensions.Options;
using Ouvidoria.Servicos.EmailServico.Config;
using Ouvidoria.Servicos.EmailServico.Interfaces;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Ouvidoria.Servicos.EmailServico
{
    public class EmailServico : IEmailServico
    {
        private readonly EmailConfig _emailConfig;
        public EmailServico(IOptions<EmailConfig> emailConfig)
        {
            _emailConfig = emailConfig.Value;
        }
        public async Task<bool> EnviarEmailAsync(string email, string assunto, string mensagem,
            string emailCc = null, Anexo anexo = null)
        {
            try
            {
                string toEmail = email;

                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(_emailConfig.Email, "Ouvidoria UGB")
                };

                mail.To.Add(new MailAddress(toEmail));
                if(emailCc != null)
                {
                    mail.CC.Add(new MailAddress(emailCc));
                }

                mail.Subject = "[OUVIDORIA] - " + assunto;
                mail.Body = mensagem;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                if(anexo != null) 
                {
                    mail.Attachments.Add(new Attachment(anexo.Caminho, anexo.ContentType));
                }

                using (SmtpClient smtp = new SmtpClient(_emailConfig.Servidor, _emailConfig.Porta))
                {
                    smtp.Credentials = new NetworkCredential(_emailConfig.Email, _emailConfig.Senha);
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(mail);
                }

                return true;
            }
            catch(Exception e)
            {
                throw e;
                return false;
            }
        }
    }
}
