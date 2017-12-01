using System.Linq;
using System.Security.Policy;
using HtmlAgilityPack;

namespace WebPageAnalyzer
{
	public class HtmlPage
	{
		private readonly HtmlDocument _html;

		public HtmlPage(string htmlContent)
		{
			_html = new HtmlDocument();
			_html.LoadHtml(htmlContent);
		}

		public HtmlPage(Url url) : this(new HtmlWeb().Load(url.Value).ParsedText)
		{
		}

		public HtmlPage IgnoreScripts()
		{
			_html.DocumentNode.Descendants()
				.Where(n => n.Name == "script" || n.Name == "style")
				.ToList()
				.ForEach(n => n.Remove());
			return new HtmlPage(_html.ParsedText);
		}

		public PageContent StripTags()
		{
			return new PageContent(_html.DocumentNode.InnerText);
		}
	}
}