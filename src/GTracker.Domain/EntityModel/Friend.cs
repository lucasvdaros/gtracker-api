using GTracker.Domain.Core.Models;

namespace GTracker.Domain.EntityModel
{
    public class Friend : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}