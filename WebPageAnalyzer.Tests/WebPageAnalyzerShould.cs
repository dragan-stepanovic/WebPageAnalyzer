﻿using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace WebPageAnalyzer.Tests
{
	public class WebPageAnalyzerShould
	{
		[Fact]
		public void ReturnKeywordsThatOccurMoreThanTwoTimesAndShouldBeSortedInDescendingOrder()
		{
			var htmlPage = new HtmlPage(@"<!DOCTYPE html>
<html>
<body>

<h1>My First Heading</h1>

<p>My first paragraph.</p>

<p>My first heading.</p>

</body>
</html>
");

			new WebPageAnalyzer().Analyze(htmlPage).Should().BeEquivalentTo(new List<string> { "first", "heading" });
		}

		[Fact]
		public void StripHtmlTags()
		{
			const string content = @"<!DOCTYPE html>
<html>
<body>

<h1>My First Heading</h1>

<p>My first paragraph.</p>

</body>
</html>
";
			var htmlPage = new HtmlPage(content);
			htmlPage.StripTags().Should().Be(new PageContent("\r\n\r\n\r\n\r\nMy First Heading\r\n\r\nMy first paragraph.\r\n\r\n\r\n\r\n"));
		}

		[Fact]
		public void RemovePunctuation()
		{
			const string keywords = "My !First Heading? My first paragraph. My first sentence.";
			new PageContent(keywords).RemovePunctuation().Should().Be("My First Heading My first paragraph My first sentence");
		}

		[Fact]
		public void ReplaceWhitespaceWithASeparator()
		{
			var pageContent =
				new PageContent(
					"\r\n\r\n\r\n\r\nMy First Heading\r\n\r\nMy first paragraph.\r\n\r\n\r\n\r\nMy first sentence.\r\n\r\n\r\n\r\n");

			const string separator = "|";
			pageContent.ReplaceWhitespaceWith(separator).Should().Be("My|First|Heading|My|first|paragraph.|My|first|sentence.");
		}

		[Fact]
		public void RemoveStopWords()
		{
			var keywords = new Keywords(new List<string> { "My", "First", "Heading", "My", "first", "paragraph", "My", "first", "sentence" });
			keywords.RemoveStopWords().Should().Be(new Keywords(new List<string> { "Heading", "paragraph", "sentence" }));
		}
	}
}