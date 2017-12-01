namespace WebPageAnalyzer
{
	public class WebPageAnalyzer
	{
		public const char Separator = '|';

		public Keywords Analyze(HtmlPage htmlPage)
		{
			return htmlPage.StripTags()
				.RemovePunctuation()
				.ReplaceWhitespaceWith(Separator)
				.ParseKeywordsBy(Separator)
				.RemoveStopWords()
				.FlattenKeywords();
		}
	}
}