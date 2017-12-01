using System;
using System.Collections.Generic;
using System.Linq;

namespace WebPageAnalyzer
{
	//design note: didn't find any utility C# library for comparing URLs while not taking into an account the order of query params, so wrote my own
	public class Url
	{
		private const string HttpScheme = "http://";
		private readonly Uri _uri;
		private readonly string _host;
		private readonly List<string> _queryParameters = new List<string>();
		private readonly Tags _tags = new Tags(new List<string>());

		public Url(string url)
		{
			if (!url.StartsWith(HttpScheme))
				url = HttpScheme + url;

			_uri = new Uri(url);
			_host = _uri.Host;
			if (_uri.Query != string.Empty)
				_queryParameters = _uri.Query.Remove(0, 1).Split('&').ToList();
		}

		public void Add(string tag)
		{
			_tags.Add(tag);
		}

		//design note: I was thining about adding TagRecommendationService, but currently it's too thin with functionality (only one statement), so decided to get recommended tags from Url domain object
		public IEnumerable<string> RecommendedTags()
		{
			return _tags.SortByOccurence();
		}

		private bool Equals(Url other)
		{
			return _host.Equals(other._host) &&
					_queryParameters.Count.Equals(other._queryParameters.Count) &&
					_queryParameters.All(other._queryParameters.Contains);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Url)obj);
		}

		public override int GetHashCode()
		{
			return _uri.GetHashCode();
		}
	}
}