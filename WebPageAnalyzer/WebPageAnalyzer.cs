using HtmlAgilityPack;

namespace WebPageAnalyzer
{
	public static class WebPageAnalyzer
	{
		public const char Separator = '|';

		public static Keywords Analyze(string url)
		{
			return Analyze(new HtmlPage(new HtmlWeb().Load(url).ParsedText));
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