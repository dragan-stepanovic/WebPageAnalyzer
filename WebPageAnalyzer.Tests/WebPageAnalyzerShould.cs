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
			//design note: could refactor towards builder for input data for readability reasons. e.g. AHtmlPage().Containing("soccer", Times.Two).Containing("python", Times.Three).Build()
			//but in this particular case I think it would actually hinder the relation between input and expected result because of the stop words, punctuation etc.
			var htmlPage = new HtmlPage(@"<!DOCTYPE html>
<html>
<body>

<h1>My First Heading</h1> <p>My first paragraph.</p>

<p>My first heading.</p> <p>My first sentence.</p> <p>My first heading.</p> <p>My first sentence.</p>

<p>My first soccer.</p> <p>My first soccer.</p>  <p>My first soccer.</p>
<p>My first barca.</p>  <p>My first barca.</p>  <p>My first barca.</p>
<p>My first real.</p> <p>My first real.</p> <p>My first real.</p>
<p>My first code.</p> <p>My first code.</p> <p>My first code.</p>
<p>My first estimate.</p> <p>My first estimate.</p> <p>My first estimate.</p> <p>My first estimate.</p>
<p>My first scripted.</p> <p>My first scripted.</p> <p>My first scripted.</p>
<p>My first csharp.</p> <p>My first csharp.</p> <p>My first csharp.</p>
<p>My first java.</p> <p>My first java.</p> <p>My first java.</p> <p>My first java.</p>
<p>My first python.</p> <p>My first python.</p> <p>My first python.</p> <p>My first python.</p>
<p>My first scala.</p> <p>My first scala.</p> <p>My first scala.</p>

</body>
</html>
");

			WebPageAnalyzer
				.Analyze(htmlPage)
				.Should()
				.Be(Keywords.From(new List<string> { "estimate", "java", "python", "heading", "soccer", "barca", "real", "code", "scripted", "csharp" }));
		}

		//integration test
		[Fact]
		public void GetContentsOfWebPage()
		{
			var result = WebPageAnalyzer.Analyze(@"http://www.internet-guide.co.uk/static-html.html");
			result.Should().Be(Keywords.From(new List<string>
			{
				"web",
				"page",
				"static",
				"content",
				"html",
				"example",
				"dynamic"
			}));
		}
	}
}