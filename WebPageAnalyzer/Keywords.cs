using System.Collections.Generic;
using System.Linq;

namespace WebPageAnalyzer
{
	public class Keywords
	{
		private readonly IEnumerable<string> _keywords;

		public Keywords(IEnumerable<string> keywords)
		{
			_keywords = keywords.Select(keyword => keyword.ToLower());
		}

		public Keywords RemoveStopWords()
		{
			//todo: keyword.IsNotAStopWord()
			var result = new Keywords(_keywords.Where(keyword => !StopList.Contains(keyword)));
			return result;
		}

		protected bool Equals(Keywords other)
		{
			return _keywords.SequenceEqual(other._keywords);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Keywords)obj);
		}

		public override int GetHashCode()
		{
			return _keywords.GetHashCode();
		}
	}
}