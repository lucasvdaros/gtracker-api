using GTracker.Domain.Core.Models;

namespace GTracker.Domain.EntityModel
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Login { get; set; }        
        public string Password { get; set; }
        public bool Active { get; set; }
    }
}