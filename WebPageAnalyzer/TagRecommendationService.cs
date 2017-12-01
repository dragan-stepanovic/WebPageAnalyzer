using System.Collections.Generic;

namespace WebPageAnalyzer
{
	public class TagRecommendationService
	{
		public Tags RecommendTagsFor(Url url)
		{
			return new Tags(new List<string>());
		}
	}
}