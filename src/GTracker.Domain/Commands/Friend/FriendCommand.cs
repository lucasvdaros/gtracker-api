using GTracker.Domain.Core.Commands;

namespace GTracker.Domain.Commands.Friend
{
    public abstract class FriendCommand : Command
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public string Email { get; protected set; }
        public string Phone { get; protected set; }
    }
}