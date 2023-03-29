using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RPM_Programming_Excercise.Common.Extensions
{
    public static class HtppClientExtensions
    {
		public static async Task<HttpResponseMessage> GetWithQueryStringAsync(this HttpClient client, string uri, Dictionary<string, string> queryStringParams)
		{
			var url = QueryHelpers.AddQueryString(uri, queryStringParams);

			return await client.GetAsync(url);
		}
	}
}
