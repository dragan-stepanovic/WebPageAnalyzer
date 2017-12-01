using System.Security.Policy;

namespace WebPageAnalyzer
{
	public static class WebPageAnalyzer
	{
		public const char Separator = '|';

		public static Keywords Analyze(Url url)
		{ 
			return Analyze(new HtmlPage(url));
		}

		public static Keywords Analyze(HtmlPage htmlPage)
		{
			return htmlPage
				.IgnoreScripts()
				.StripTags()
				.RemovePunctuation()
				.ReplaceWhitespaceWith(Separator)
				.ParseKeywordsBy(Separator)
				.RemoveStopWords()
				.WithOccurenceMoreThan(2)
				.SortByOccurence()
				.GetDistinct()
				.LimitResultSizeTo(10);
		}
	}
}