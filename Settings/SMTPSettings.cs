using MailKit.Net.Smtp;
using MailKit.Security;


namespace EPSS.Settings
{
	public class SMTPSettings
	{
		public string URI { get; set;}
		public int Port { get; set;} = 25;
		public string User { get; set;} = null;
		public string Password { get; set;} = null;
		public SecureSocketOptions SecureOptions { get; set; } = SecureSocketOptions.Auto;
		public void Connect(SmtpClient smtpClient)
		{
			smtpClient.Connect(URI, Port, SecureOptions);
			if (User != null)
				smtpClient.Authenticate(User, Password);
		}
	}
}