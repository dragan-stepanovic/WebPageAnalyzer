using System.Collections.Generic;
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

<p>My first sentence.</p>

</body>
</html>
");

			WebPageAnalyzer.Analyze(htmlPage).Should().BeEquivalentTo(new Keywords(new List<string> { "heading", "paragraph", "sentence" }));
		}
	}
}