using FluentAssertions;
using Xunit;

namespace WebPageAnalyzer.Tests
{
	public class PageContentShould
	{
		[Fact]
		public void RemovePunctuation()
		{
			const string keywords = "My !First Heading? My first paragraph. My first sentence.";
			new PageContent(keywords).RemovePunctuation().Should().Be(new PageContent("My First Heading My first paragraph My first sentence"));
		}

		[Fact]
		public void ReplaceWhitespaceWithASeparator()
		{
			var pageContent =
				new PageContent(
					"\r\n\r\n\r\n\r\nMy First Heading\r\n\r\nMy first paragraph.\r\n\r\n\r\n\r\nMy first sentence.\r\n\r\n\r\n\r\n");

			pageContent.ReplaceWhitespaceWith(WebPageAnalyzer.Separator).Should().Be(new PageContent("My|First|Heading|My|first|paragraph.|My|first|sentence."));
		}
	}
}