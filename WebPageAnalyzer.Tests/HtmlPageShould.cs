using FluentAssertions;
using Xunit;

namespace WebPageAnalyzer.Tests
{
	public class HtmlPageShould
	{
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
			htmlPage
				.StripTags()
				.Should()
				.Be(new PageContent("\r\n\r\n\r\n\r\nMy First Heading\r\n\r\nMy first paragraph.\r\n\r\n\r\n\r\n"));
		}
	}
}