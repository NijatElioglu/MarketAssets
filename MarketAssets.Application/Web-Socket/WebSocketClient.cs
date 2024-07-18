using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace MarketAssetService.Application.Web_Socket
{
    public class WebSocketClient
    {
        private readonly ClientWebSocket _client;
        private readonly Uri _uri;

        public WebSocketClient(string url)
        {
            _client = new ClientWebSocket();
            _uri = new Uri(url);
        }

        public async Task ConnectAsync()
        {
            await _client.ConnectAsync(_uri, CancellationToken.None);
        }

        public async Task<string> ReceiveMessageAsync()
        {
            var buffer = new byte[1024 * 4];
            var result = await _client.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            return Encoding.UTF8.GetString(buffer, 0, result.Count);
        }

        public async Task CloseAsync()
        {
            await _client.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closed by client", CancellationToken.None);
        }
    }
}
