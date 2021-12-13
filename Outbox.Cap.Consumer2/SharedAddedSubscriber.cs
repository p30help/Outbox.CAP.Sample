using System;
using System.Threading.Tasks;
using DotNetCore.CAP;
using EventModels;

namespace Outbox.Cap.Consumer2
{
    public class SharedAddedSubscriber : ICapSubscribe
    {
        [CapSubscribe("captest.user.useradded", Group = "user.useradded.shared")]
        public async Task Handle(UserAddedEvent user)
        {
            Console.WriteLine($"Shared Message - {user?.Username}");
        }
    }
}
