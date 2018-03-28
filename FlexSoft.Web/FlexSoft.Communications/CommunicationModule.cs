using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Fleck;
using FlexSoft.Infrastructure;

namespace FlexSoft.Communications
{
    public class CommunicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Repository>().AsImplementedInterfaces();
            builder.Register(context => new WebSocketServer("ws://0.0.0.0:6060")).As<IWebSocketServer>();
            builder.RegisterType<ConcurrentDictionary<IWebSocketConnection, ISocketClient>>().AsSelf().SingleInstance();
            builder.RegisterType<ConcurrentBag<SocketRoom>>().AsSelf().SingleInstance();
            builder.RegisterType<FlexSoftCommunicationsLayer>().As<ITrainingServerCommunicationLayer>()
                .SingleInstance();
        }
    }
}
