using MimeKit;

namespace EPSS.Mail
{
	public class BodyText:BodyBase
	{
		public BodyText(string subject, string content):base(subject,new TextPart("plain")
			{
				Text = content

			}){}
	}
}