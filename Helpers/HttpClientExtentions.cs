using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using V7.BaseApplication.Utilies.Control;
using V7.BaseApplication.Utilies.Convertion;

namespace V7.BaseApplication.Utilies.Helpers
{
    public static class HttpClientExtentions
    {
        public async static Task<TResponse> GetTResponseFromApiAsync<TRequest, TResponse>(this HttpClient client, string url, TRequest request)
        {
            var content = new StringContent(request.ToJson());
            content.Headers.Remove("Content-type");
            content.Headers.TryAddWithoutValidation("Content-type", "application/json");

            var result = await client.PostAsync(url, content);
            var stringResult = await result.Content.ReadAsStringAsync();
            if (result.IsSuccessStatusCode)
            {
                return stringResult.FromJson<TResponse>();
            }
            else
            {
                throw new Exception($"{result.ReasonPhrase} {stringResult}");
            }
        }
        public static async Task<TResponse> GetFromApiAsync<TResponse>(this HttpClient client, string url, NameValueCollection request = null)
        {
            string requestUrl = GetRequestUrl(url, request);
            var responseMessage = await client.GetAsync(requestUrl);
            if (responseMessage.IsSuccessStatusCode)
            {
                var stringResult = await responseMessage.Content.ReadAsStringAsync();
                return (stringResult).FromJson<TResponse>();
            }
            throw new Exception(responseMessage.ReasonPhrase);
        }

        private static string GetRequestUrl(string url, NameValueCollection request)
        {
            var queryString = "";
            if (request != null && request.AllKeys.Any())
            {
                queryString = request.ConvertToQueryString();
            }
            return url + (queryString.IsNullOrEmpty() ? "" : $"?{queryString}");
        }
    }
}
