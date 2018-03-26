using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using FlexSoft.Infrastructure;

namespace FlexSoft.Communications
{
    public class CommunicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Repository>().AsImplementedInterfaces();
            
        }
    }
}
