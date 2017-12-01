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
		private readonly List<string> _queryParameters;
		private readonly Dictionary<string, int> _occurencesByTags = new Dictionary<string, int>();

		public Url(string url)
		{
			if (!url.StartsWith(HttpScheme))
				url = HttpScheme + url;

			_uri = new Uri(url);
			_host = _uri.Host;
			_queryParameters = _uri.Query.Remove(0, 1).Split('&').ToList();
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

		public void Add(string tag)
		{
			_occurencesByTags.Add(tag, _occurencesByTags[tag]++);
		}
	}
}