using System.Threading.Tasks;

using System.Net.Http;
using System.Text.Json;

namespace Foodopedia.Core.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task<T> ParseAsAsync<T>(this HttpResponseMessage response)
        {
            string content = await response.AsJsonString();
            return JsonSerializer.Deserialize<T>(content);
        }

        public static async Task<string> AsJsonString(this HttpResponseMessage response)
        {
            return await response.Content?.ReadAsStringAsync();
        }
    }
}