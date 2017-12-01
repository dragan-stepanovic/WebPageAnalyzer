namespace WebPageAnalyzer
{
	public static class WebPageAnalyzer
	{
		public const char Separator = '|';

		public static Keywords Analyze(HtmlPage htmlPage)
		{
			return htmlPage.StripTags()
				.RemovePunctuation()
				.ReplaceWhitespaceWith(Separator)
				.ParseKeywordsBy(Separator)
				.RemoveStopWords()
				.GetDistinct()
				.SortByOccurence();
		}
	}
}