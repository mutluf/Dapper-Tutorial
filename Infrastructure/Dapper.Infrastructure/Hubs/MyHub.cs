
using Microsoft.AspNetCore.SignalR;

namespace DapperAPI.API.Hubs
{
    public class MyHub:Hub
    {
        public async Task SendMessageAsync(string message)
        {
            await Clients.All.SendAsync("RecieveMessage",message);
        }
    }
}
