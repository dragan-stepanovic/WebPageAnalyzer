using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace WebPageAnalyzer.Tests
{
	public class KeywordsShould
	{
		//todo: refactor towards Builder pattern for test input data. E.g. Keywords().Having("My").Having("Heading").Build()
		[Fact]
		public void RemoveStopWords()
		{
			var keywords = new Keywords(new List<string> { "My", "First", "Heading", "My", "first", "paragraph", "My", "first", "sentence" });
			keywords.RemoveStopWords().Should().BeEquivalentTo(new Keywords(new List<string> { "Heading", "paragraph", "sentence" }));
		}

		[Fact]
		public void GetUniqueKeywords()
		{
			var keywords = new Keywords(new List<string> { "heading", "paragraph", "heading", "sentence", "heading", "paragraph" });
			keywords.GetDistinct().Should().BeEquivalentTo(new Keywords(new List<string> { "heading", "paragraph", "sentence" }));
		}

		[Fact]
		public void SortInDescendingOrderByOccurence()
		{
			var keywords = new Keywords(new List<string> { "heading", "paragraph", "heading", "sentence", "heading", "paragraph" });
			keywords.SortByOccurence().Should().BeEquivalentTo(new Keywords(new List<string> { "heading", "paragraph", "sentence" }));
		}

		[Fact]
		public void FilterThoseThatOccurMoreThanTwoTimes()
		{
			var keywords = new Keywords(new List<string> { "heading", "paragraph", "heading", "sentence", "heading", "paragraph" });
			keywords.FilterThoseThatOccurMoreThan(Times.Two).Should().BeEquivalentTo(new Keywords(new List<string> { "heading", "heading", "heading" }));
		}
	}
}