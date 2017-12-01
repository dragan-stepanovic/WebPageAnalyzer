using System.Collections.Generic;

namespace WebPageAnalyzer.Tests
{
	internal class KeywordsBuilder
	{
		private readonly List<string> _keywords = new List<string>();

		public KeywordsBuilder Containing(string keyword, int times)
		{
			for (var i = 0; i < times; i++)
				_keywords.Add(keyword);

			return this;
		}

		public Keywords Build()
		{
			return Keywords.From(_keywords);
		}
	}
}