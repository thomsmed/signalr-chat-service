using System.Threading.Tasks;
using SignalRChat.Model;

namespace SignalRChat.Hubs {
    public interface IChatHub
    {
        Task SendMessageToCaller(MessageDto message);

        Task SendMessageToUser(MessageDto message);

        Task SendMessageToGroup(MessageDto message);

        Task SendMessageToAll(MessageDto message);

        Task JoinGroup(GroupDto group);

        Task LeaveGroup(GroupDto group);
    }
}