using System.Net.Http;
using System.Threading.Tasks;

namespace WiktionaryWords.WiktionaryEndpoint
{
    public class Example
    {
        public static async Task<bool> IsConnectionEstablished()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("http://example.com/");
            return response.IsSuccessStatusCode;
        }
    }
}
