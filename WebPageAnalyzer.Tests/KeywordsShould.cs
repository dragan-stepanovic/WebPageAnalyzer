using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace WebPageAnalyzer.Tests
{
	public class KeywordsShould
	{
		[Fact]
		public void RemoveStopWords()
		{
			var keywords = Keywords.From(new List<string> { "My", "First", "Heading", "My", "first", "paragraph", "My", "first", "sentence" });
			keywords.RemoveStopWords().Should().Be(Keywords.From(new List<string> { "Heading", "paragraph", "sentence" }));
		}

		[Fact]
		public void GetUniqueKeywords()
		{ //design note: I usually don't extract common input data into separate method/class since leaving it in the test itself increases ability to relate cause and effect (input and output). 
		 //for tests I prefer readabilty over having some of duplication
			var keywords = KeywordsCollection()
				.Containing("paragraph", 2)
				.Containing("sentence", 1)
				.Containing("heading", 3)
				.Build();

			keywords.GetDistinct().Should().Be(Keywords.From(new List<string> { "heading", "paragraph", "sentence" }));
		}

		[Fact]
		public void SortInDescendingOrderByOccurence()
		{
			var keywords = KeywordsCollection()
				.Containing("paragraph", 2)
				.Containing("sentence", 1)
				.Containing("heading", 3)
				.Build();

			keywords.SortByOccurence().Should().Be(Keywords.From(new List<string> { "heading", "paragraph", "sentence" }));
		}

		[Fact]
		public void FilterThoseThatOccurMoreThanTwoTimes()
		{
			var keywords = KeywordsCollection()
				.Containing("heading", 3)
				.Containing("paragraph", 2)
				.Containing("sentence", 1)
				.Build();

			keywords.WithOccurenceMoreThan(2).Should().Be(Keywords.From(new List<string> { "heading", "heading", "heading" }));
		}

		[Fact]
		public void LimitSizeToTenResults()
		{
			var keywords = KeywordsCollection()
				.Containing("soccer", 6)
				.Containing("heading", 5)
				.Containing("paragraph", 4)
				.Containing("sentence", 3)
				.Containing("real", 3)
				.Containing("barca", 3)
				.Containing("java", 3)
				.Containing("scala", 3)
				.Containing("python", 3)
				.Containing("estimates", 3)
				.Containing("script", 3)
				.Containing("something", 3)
				.Build();

			keywords.LimitResultSizeTo(10).HasElementsCount(10).Should().BeTrue();
		}

		private static KeywordsBuilder KeywordsCollection()
		{
			return new KeywordsBuilder();
		}
	}
}