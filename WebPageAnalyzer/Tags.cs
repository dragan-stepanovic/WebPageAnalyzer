using System.Collections.Generic;
using System.Linq;

namespace WebPageAnalyzer
{
	public class Tags
	{
		private readonly Dictionary<string, int> _occurencesByTags = new Dictionary<string, int>();

		public Tags(List<string> tags)
		{
			tags.ForEach(tag => _occurencesByTags.Add(tag, 0));
		}

		public void Add(string tag)
		{
			if (_occurencesByTags.ContainsKey(tag))
				_occurencesByTags[tag]++;
			else
				_occurencesByTags.Add(tag, 0);
		}

		public IEnumerable<string> SortByOccurence()
		{
			return _occurencesByTags
				.OrderByDescending(pair => pair.Value)
				.Select(kvp => kvp.Key)
				.ToList();
		}
	}
}