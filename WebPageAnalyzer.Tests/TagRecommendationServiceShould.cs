using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace WebPageAnalyzer.Tests
{
	public class TagRecommendationServiceShould
	{
		[Fact]
		public void RecommendTagsFromOtherUsers()
		{
			var url = AUrl("www.b92.net/laprimera").WithTag("soccer", 4).WithTag("real", 2).Build();
			var recommendedTags = new TagRecommendationService().RecommendTagsFor(new Url("www.b92.net/laprimera"));
			recommendedTags.Should().Be(new Tags(new List<string> { "soccer", "real" }));
		}

		private UrlBuilder AUrl(string urlString)
		{
			return new UrlBuilder(urlString);
		}
	}
}