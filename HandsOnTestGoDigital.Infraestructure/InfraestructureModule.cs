using Autofac;
using HandsOnTestGoDigital.Core.Interfaces.Repositories;

namespace HandsOnTestGoDigital.Infraestructure
{
    public class InfraestructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<IRepositoryWrapper>().As<IRepositoryWrapper>().InstancePerLifetimeScope();
        }
    }
}
