using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalRChat.Model;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub<IChatClient>, IChatHub
    {
        public async Task SendMessageToCaller(MessageDto message) {
            await Clients.Caller.ReceiveMessageFromSelf(message);
        }

        public async Task SendMessageToUser(MessageDto message) {
            message.Sender = Context.ConnectionId;
            await Clients.Client(message.Receiver).ReceiveMessageFromUser(message);
        }

        public async Task SendMessageToGroup(MessageDto message) {
            message.Sender = Context.ConnectionId;
            await Clients.OthersInGroup(message.Group).ReceiveMessageFromGroup(message);
        }

        public async Task SendMessageToAll(MessageDto message)
        {
            message.Sender = Context.ConnectionId;
            await Clients.Others.ReceiveMessageFromUser(message);
        }

        public async Task JoinGroup(GroupDto group) {
            group.Participant = Context.ConnectionId;
            await Groups.AddToGroupAsync(Context.ConnectionId, group.Id);
            await Clients.OthersInGroup(group.Id).UserJoinedGroup(group);
        }

        public async Task LeaveGroup(GroupDto group) {
            group.Participant = Context.ConnectionId;
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, group.Id);
            await Clients.OthersInGroup(group.Id).UserLeftGroup(group);
        }

        public override async Task OnConnectedAsync() {
            var user = new UserDto(){ Id = Context.ConnectionId };
            await Clients.Others.UserConnected(user);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception) {
            var user = new UserDto(){ Id = Context.ConnectionId };
            await Clients.Others.UserDisconnected(user);
            await base.OnDisconnectedAsync(exception);
        }
    }
}