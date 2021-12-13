using System;
using System.Threading.Tasks;
using DotNetCore.CAP;
using EventModels;

namespace Outbox.Cap.Consumer2
{
    public class OtherMachineAddedSubscriber : ICapSubscribe
    {
        public static int Count { get; set; }

        [CapSubscribe("captest.user.useradded")]
        public async Task HandleInOtherMachine(UserAddedEvent user)
        {
            Console.WriteLine($"BBB - Count : {Count} - {user?.Username}");

            //throw new Exception("Errrrrrror");
        }
    }
}
