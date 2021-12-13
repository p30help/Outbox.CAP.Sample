using System;
using System.Threading.Tasks;
using DotNetCore.CAP;
using EventModels;

namespace Outbox.Cap.Consumer
{
    public class UserAddedSubscriber : ICapSubscribe
    {
        public static int Count { get; set; }

        [CapSubscribe("captest.user.useradded")]
        public async Task HandleInConsole(UserAddedEvent user)
        {
            Count++;

            Console.WriteLine($"AAA - Count : {Count} - {user?.Username}");
        }
    }
}
