namespace WebPageAnalyzer.Tests
{
	internal class UrlBuilder
	{
		private readonly Url _url;

		public UrlBuilder(string urlString)
		{
			_url = new Url(urlString);
		}

		public UrlBuilder WithTag(string tag, int numberOfOccurences)
		{
			for (var i = 0; i < numberOfOccurences; i++)
				_url.Add(tag);

			return this;
		}

		public Url Build()
		{
			return _url;
		}
	}
}