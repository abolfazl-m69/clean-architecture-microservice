using HumanResource.Framework.Core;
using System;
using Autofac;
using Autofac.Builder;
using HumanResource.Framework.Core.Events;
using HumanResource.Framework.Core.Events.UserInfo;
using HumanResource.Framework.Core.Utilities;
using Microsoft.AspNetCore.Http;
using HumanResource.Framework.Application.Claims;
using HumanResource.Framework.Core.Events.ConsumerRequestContext;
using HumanResource.Framework.Common.Service.File;

namespace HumanResource.Framework.Ioc.Config
{
    public class GeneralBootstrapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SystemClock>().As<IClock>().SingleInstance();
            builder.RegisterType<EfUnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<ClaimHelper>().As<IClaimHelper>().InstancePerLifetimeScope();
            //builder.RegisterType<MessageClaimHelper>().As<IClaimHelper>().InstancePerLifetimeScope();
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();
            builder.RegisterType<EventLookup>().As<IEventLookup>().InstancePerLifetimeScope();
            builder.RegisterType<RequestContext>().As<IRequestContext>().InstancePerLifetimeScope();
            builder.RegisterType<EventAggregator>().As<IEventPublisher>().As<IEventListener>().InstancePerLifetimeScope()
                .OnRelease<EventAggregator, ConcreteReflectionActivatorData, SingleRegistrationStyle>(
                    (Action<EventAggregator>)(x => { }));
            builder.RegisterType<FileHelper>().As<IFileHelper>().InstancePerDependency();
        }
    }
}