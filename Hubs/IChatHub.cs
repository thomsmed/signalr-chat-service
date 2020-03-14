using System.Threading.Tasks;

namespace SignalRChat.Hubs {
    public interface IChatHub
    {
        Task SendMessageToCaller(string message);

        Task SendMessageToUser(string connectionId, string message);

        Task SendMessageToGroup(string group, string message);

        Task SendMessageToAll(string message);

        Task JoinGroup(string group);

        Task LeaveGroup(string group);
    }
}