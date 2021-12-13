using System;
using System.Threading.Tasks;
using DotNetCore.CAP;
using EventModels;

namespace Outbox.Cap.Consumer
{
    public class SharedAddedSubscriber : ICapSubscribe
    {
        // if use same "Group" name for multi subscribers (consumers) all of them connect to one queue (share queue)
        // so just one of them work on message (not all of consumers)
        [CapSubscribe("captest.user.useradded", Group = "user.useradded.shared")]
        public async Task Handle(UserAddedEvent user)
        {
            Console.WriteLine($"Shared Message - {user?.Username}");
        }
    }
}
