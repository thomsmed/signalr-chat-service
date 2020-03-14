using System.Threading.Tasks;

namespace SignalRChat.Hubs {
    public interface IChatClient
    {
        Task ReceiveMessageFromSelf(string message);

        Task ReceiveMessageFromUser(string connectionId, string message);

        Task ReceiveMessageFromGroup(string group, string connectionId, string message);

        Task UserJoinedGroup(string group, string connectionId);

        Task UserLeftGroup(string group, string connectionId);

        Task UserConnected(string connectionId);

        Task UserDisconnected(string connectionId);
    }
}