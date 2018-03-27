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
            builder.Register(context => new WebSocketServer(8091, "localhost")).As<IWebSocketServer>();
            builder.RegisterType<ConcurrentDictionary<IWebSocketConnection, ISocketClient>>().AsSelf().SingleInstance();
            builder.RegisterType<ConcurrentBag<SocketRoom>>().AsSelf().SingleInstance();
        }
    }
}
