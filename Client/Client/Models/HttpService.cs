using System.Net.Http;
using System.Threading.Tasks;

namespace Client.Models
{
    class HttpService
    {
        public async Task<byte[]> GetAsync(string url)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            return await response.Content.ReadAsByteArrayAsync();
        }
    }
}
