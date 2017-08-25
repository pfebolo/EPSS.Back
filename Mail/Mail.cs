
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

		/// <summary>
		/// Enviar el e-mail propiamente dicho
		/// </summary>
		/// <param name="contactFrom">Remitente (nombre y direccion de e-mail)</param>
		/// <param name="contactTo">Receptor (nombre y direccion de e-mail).</param>
		/// <param name="contactBcc">Contacto 'oculto' a quien también se le envía el mail (nombre y direccion de e-mail).</param>
		/// <param name="Message">Cuerpo de e-mail (tipo y texto)</param>
		private void send(MailboxAddress contactFrom, MailboxAddress contactTo, MailboxAddress contactBCC, MimeMessage Message)
		{
			Message.From.Add(contactFrom);
			Message.To.Add(contactTo);
			if (contactBCC != null)
				Message.Bcc.Add(contactBCC);
			smtpClient.Send(Message);
		}

		private MimeMessage createMessage(BodyBase body)
		{
			var Message = new MimeMessage();
			Message.Subject = body.Subject;
			Message.Body = body.Body;  
			return Message;
		}

		public void send(MailboxAddress contactFrom, MailboxAddress contactTo, BodyText body)
		{
			send(contactFrom, contactTo, null, body);
		}

		public void send(MailboxAddress contactFrom, MailboxAddress contactTo, MailboxAddress contactBCC, BodyText body)
		{
			send(contactFrom, contactTo, contactBCC, createMessage(body));
		}
		public void send(MailboxAddress contactFrom, MailboxAddress contactTo, BodyHtml body)
		{
			send(contactFrom, contactTo, null, createMessage(body));
		}
		public void send(MailboxAddress contactFrom, MailboxAddress contactTo, MailboxAddress contactBCC, BodyHtml body)
		{
			send(contactFrom, contactTo, contactBCC, createMessage(body));
		}



	}
}
