using System.Threading.Tasks;
using SignalRChat.Model;

namespace SignalRChat.Hubs {
    public interface IChatClient
    {
        Task ReceiveMessageFromSelf(MessageDto message);

        Task ReceiveMessageFromUser(MessageDto message);

        Task ReceiveMessageFromGroup(MessageDto message);

        Task UserJoinedGroup(GroupDto group);

        Task UserLeftGroup(GroupDto group);

        Task UserConnected(UserDto user);

        Task UserDisconnected(UserDto user);
    }
}