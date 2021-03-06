﻿using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace WebPageAnalyzer.Tests
{
	public class UrlShould
	{
		[Fact]
		public void MatchesEquivalentUrlsByStrings()
		{
			var url1 = new Url("www.example.com/?foo=bar&hello=world");
			var url2 = new Url("http://www.example.com/?hello=world&foo=bar");
			var url3 = new Url("http://www.example.com/?foo=bar&hello=world");

			url1.Equals(url2).Should().BeTrue();
			url1.Equals(url3).Should().BeTrue();
			url2.Equals(url3).Should().BeTrue();
		}

		[Fact]
		public void RecommendTagsWithMostOccurence()
		{
			var url = AUrl("www.b92.net/laprimera")
				.WithTag("real", 2)
				.WithTag("soccer", 4)
				.WithTag("spain", 3)
				.Build();

			var recommendedTags = url.RecommendedTags();

			recommendedTags.Should().BeEquivalentTo(new List<string> { "soccer", "spain", "real" });
		}

		private static UrlBuilder AUrl(string urlString)
		{
			return new UrlBuilder(urlString);
		}
	}
}