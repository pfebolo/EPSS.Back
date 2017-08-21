using MimeKit;

namespace EPSS.Mail
{
	public class BodyHtml
	{
		public string Subject { get; }
		public MimeEntity Body { get; }

		public BodyHtml(string subject, string content)
		{
			Subject = subject;
			Body = new TextPart("html")
			{
				Text = content

			};

		}
	}
}

