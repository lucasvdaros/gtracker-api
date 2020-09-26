using System;
using GTracker.Domain.Core.Models;

namespace GTracker.Domain.EntityModel
{
    public class User : Entity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}