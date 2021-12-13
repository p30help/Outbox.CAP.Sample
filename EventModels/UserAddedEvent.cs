
using System;

namespace EventModels
{
    public class UserAddedEvent
    {
        public Guid Id { get; set; }

        public string Username { get; set; }
    }
}