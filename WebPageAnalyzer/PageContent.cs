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

		public string ReplaceWhitespaceWith(string separator)
		{
			return Regex.Replace(_content.Trim(), @"\s+", separator);
		}

		public string RemovePunctuation()
		{
			return new string(_content.Where(c => !char.IsPunctuation(c)).ToArray());
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
			return Equals((PageContent) obj);
		}

		public override int GetHashCode()
		{
			return _content.GetHashCode();
		}
	}
}