using Microsoft.AspNetCore.SignalR;

namespace UserManagementApp.Hubs
{
    public class OnlineUsersCount:Hub
    {
        public static int OnlineUsersCounter = 0;

        public void SendUsersCounter()
        {
            Clients.All.SendAsync("GetUsersCounter", OnlineUsersCounter.ToString());
        }

        public override Task OnConnectedAsync()
        {
            OnlineUsersCounter++;
            SendUsersCounter();
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            OnlineUsersCounter--;
            SendUsersCounter();
            return base.OnDisconnectedAsync(exception);
        }
    }
}
