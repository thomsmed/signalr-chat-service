using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub<IChatClient>, IChatHub
    {
        public async Task SendMessageToCaller(string message) {
            await Clients.Caller.ReceiveMessageFromSelf(message);
        }

        public async Task SendMessageToUser(string connectionId, string message) {
            await Clients.Client(connectionId).ReceiveMessageFromUser(Context.ConnectionId, message);
        }

        public async Task SendMessageToGroup(string group, string message) {
            await Clients.OthersInGroup(group).ReceiveMessageFromGroup(group, Context.ConnectionId, message);
        }

        public async Task SendMessageToAll(string message)
        {
            await Clients.Others.ReceiveMessageFromUser(Context.ConnectionId, message);
        }

        public async Task JoinGroup(string group) {
            await Groups.AddToGroupAsync(Context.ConnectionId, group);
            await Clients.OthersInGroup(group).UserJoinedGroup(group, Context.ConnectionId);
        }

        public async Task LeaveGroup(string group) {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, group);
            await Clients.OthersInGroup(group).UserLeftGroup(group, Context.ConnectionId);
        }

        public override async Task OnConnectedAsync() {
            await Clients.Others.UserConnected(Context.ConnectionId);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception) {
            await Clients.Others.UserDisconnected(Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }
    }
}