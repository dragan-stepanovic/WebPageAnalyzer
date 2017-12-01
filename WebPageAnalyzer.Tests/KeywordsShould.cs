using System.Collections.Generic;
using System.Linq;
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
			keywords.WithOccurenceMoreThan(2).Should().BeEquivalentTo(new Keywords(new List<string> { "heading", "heading", "heading" }));
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

			//var keywords = new Keywords(new List<string> { "heading", "paragraph", "heading", "sentence", "heading", "paragraph", "soccer", "soccer", });
			keywords.LimitResultSizeTo(10).Count().Should().Be(10);
		}

		private KeywordsBuilder KeywordsCollection()
		{
			return new KeywordsBuilder();
		}
	}

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
			return new Keywords(_keywords);
		}
	}
}