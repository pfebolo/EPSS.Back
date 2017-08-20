using MimeKit;

namespace EPSS.Mail
{
	public class BodyText
	{
		public string Subject { get; }
		public MimeEntity Body { get; }

		public BodyText(string subject, string content)
		{
			Subject = subject;
			Body = new TextPart("plain")
			{
				Text = content

			};

		}
	}
}