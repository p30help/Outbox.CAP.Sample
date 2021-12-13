using Consul;
using DotNetCore.CAP;
using System.Threading.Tasks;
using EventModels;

namespace Outbox.CAP.Sample
{
    public class UserAddedSubscriber : ICapSubscribe
    {
        public static int Count { get; set; }

        [CapSubscribe("captest.user.useradded")]
        public async Task Handle(UserAddedEvent user)
        {
            Count++;
        }
    }
}
