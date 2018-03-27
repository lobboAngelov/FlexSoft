using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using FlexSoft.Infrastructure;

namespace FlexSoft.Communications.Server
{
    public class Program
    {
        public static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new CommunicationModule());

            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var trainingServerCommunicationLayer = scope.Resolve<ITrainingServerCommunicationLayer>();
                trainingServerCommunicationLayer.StartServerClientSocket();

                await Task.Delay(-1);
            }
        }
    }
}
