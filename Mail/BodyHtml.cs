using MimeKit;

namespace EPSS.Mail
{
	public class BodyHtml:BodyBase
	{
		public BodyHtml(string subject, string content):base(subject,new TextPart("html")
			{
				Text = content

			}){}
	}
}

