using System;
using System.Threading.Tasks;
using Convey.HTTP;

namespace Trill.Saga.Clients
{
    internal sealed class AdApiHttpClient : IAdApiClient
    {
        private readonly IHttpClient _client;
        private readonly string _url;

        public AdApiHttpClient(IHttpClient client, HttpClientOptions options)
        {
            _client = client;
            _url = options.Services["ads"];
        }
        
        public async Task<bool> PayAsync(Guid adId)
        {
            var response = await _client.PutAsync($"{_url}/ads/{adId}/pay", new
            {
                adId
            });

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> PublishAsync(Guid adId)
        {
            var response = await _client.PutAsync($"{_url}/ads/{adId}/publish", new
            {
                adId
            });

            return response.IsSuccessStatusCode;
        }
    }
}