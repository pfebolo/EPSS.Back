using MimeKit;

namespace EPSS.Mail
{
	public class BodyBase
	{
		public string Subject { get; }
		public MimeEntity Body { get; }

		public BodyBase(string subject, TextPart content)
		{
			Subject = subject;
			Body = content;
		}
	}
}

