using HtmlAgilityPack;

namespace WebPageAnalyzer
{
	public class HtmlPage
	{
		private readonly string _content;

		public HtmlPage(string content)
		{
			_content = content;
		}

		public PageContent StripTags()
		{
			var doc = new HtmlDocument();
			doc.LoadHtml(_content);
			return new PageContent(doc.DocumentNode.InnerText);
		}
	}
}