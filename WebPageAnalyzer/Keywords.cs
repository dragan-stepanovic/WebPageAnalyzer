using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WebPageAnalyzer
{
	public class Keywords : IEnumerable<string>
	{
		private readonly IEnumerable<string> _keywords;

		//todo: Keywords.From
		public Keywords(IEnumerable<string> keywords)
		{
			_keywords = keywords.Select(keyword => keyword.ToLower());
		}

		public Keywords RemoveStopWords()
		{
			//todo: keyword.IsNotAStopWord()
			return new Keywords(_keywords.Where(keyword => !StopList.Contains(keyword)));
		}

		public Keywords GetDistinct()
		{
			return new Keywords(_keywords.Distinct());
		}

		public Keywords SortByOccurence()
		{
			return new Keywords(_keywords
				.GroupBy(keyword => keyword)
				.OrderByDescending(group => group.Count())
				.Select(group => group.Key));
		}

		public Keywords FilterThoseThatOccurMoreThan(int times)
		{
			return new Keywords(_keywords.Where(keyword => _keywords.Count(k => k.Equals(keyword)) > times));
		}

		protected bool Equals(Keywords other)
		{
			return _keywords.SequenceEqual(other._keywords);
		}

		public IEnumerator<string> GetEnumerator()
		{
			return _keywords.GetEnumerator();
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

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}