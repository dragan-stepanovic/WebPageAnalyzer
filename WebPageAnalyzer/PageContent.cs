using System.Linq;
using System.Text.RegularExpressions;

namespace WebPageAnalyzer
{
	public class PageContent
	{
		private readonly string _content;

		public PageContent(string content)
		{
			_content = content;
		}

		public PageContent ReplaceWhitespaceWith(char separator)
		{
			return new PageContent(Regex.Replace(_content.Trim(), @"\s+", separator.ToString()));
		}

		public PageContent RemovePunctuation()
		{
			return new PageContent(new string(_content.Where(c => !char.IsPunctuation(c)).ToArray()));
		}

		protected bool Equals(PageContent other)
		{
			return string.Equals(_content, other._content);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((PageContent)obj);
		}

		public override int GetHashCode()
		{
			return _content.GetHashCode();
		}

		public Keywords ParseKeywordsBy(char separator)
		{
			return new Keywords(_content.Split(separator));
		}
	}
}