using GTracker.Domain.Core.Commands;

namespace GTracker.Domain.Commands.User
{
    public abstract class UserCommand : Command
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public string Login { get; protected set; }
        public string Password { get; protected set; }
        public bool Active { get; protected set; }
    }
}