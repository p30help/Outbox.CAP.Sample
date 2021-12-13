using DotNetCore.CAP.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Outbox.Cap.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new ServiceCollection();

            container.AddLogging(x => x.AddConsole());
            container.AddCap(x =>
            {
                // If you are using ADO.NET, choose to add configuration you needed：
                x.UseSqlServer(@"Server=.\MSSQLSERVER17;Database=CapTest;Trusted_Connection=True;");

                // CAP support RabbitMQ,Kafka,AzureService as the MQ, choose to add configuration you needed：
                x.UseRabbitMQ("localhost");
            });

            container.AddSingleton<UserAddedSubscriber>();

            container.AddSingleton<SharedAddedSubscriber>();

            var sp = container.BuildServiceProvider();

            var bootstrap = sp.GetService<IBootstrapper>();
            bootstrap.BootstrapAsync();

            Console.WriteLine("Ready to get events!");

            Console.ReadLine();

            
        }
    }
}
