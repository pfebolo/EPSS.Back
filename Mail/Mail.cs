
using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;
using System;
using EPSS.Repositories;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using EPSS.Settings;

namespace EPSS.Mail
{
	public class MailEasy
	{
		private SMTPSettings _SMTPSettings;
		private SmtpClient smtpClient = new SmtpClient();

		public MailEasy(SMTPSettings smtpSettings)
		{
			_SMTPSettings = smtpSettings;
			//Preparación para Secure Socket Layer
			// accept all SSL certificates (in case the server supports STARTTLS)
			smtpClient.ServerCertificateValidationCallback += (
					object sender,
					X509Certificate cert,
					X509Chain chain,
					SslPolicyErrors sslPolicyErrors) =>
			{ Console.WriteLine(cert.Subject); return true; };
		}
		public void Conectar()
		{
			_SMTPSettings.Connect(smtpClient); // Error 5.5.1 Authentication  
		}

		public bool EstaConectado
		{
			get { return smtpClient.IsConnected; }
		}

		public void DesConectar()
		{
			smtpClient.Disconnect(true);
		}


		private void send(MailboxAddress contactFrom, MailboxAddress contactTo, MimeMessage Message)
		{
			Message.From.Add(contactFrom);
			Message.To.Add(contactTo);
			smtpClient.Send(Message);
		}

		public void send(MailboxAddress contactFrom, MailboxAddress contactTo, BodyText body)
		{
			var mimeMessage = new MimeMessage();
			mimeMessage.Subject = body.Subject;
			mimeMessage.Body = body.Body;

			send(contactFrom,contactTo,mimeMessage);
		}

		public void send(MailboxAddress contactFrom, MailboxAddress contactTo, BodyHtml body)
		{
			var mimeMessage = new MimeMessage();
			mimeMessage.Subject = body.Subject;
			mimeMessage.Body = body.Body;

			send(contactFrom,contactTo,mimeMessage);
		}
	}
}
