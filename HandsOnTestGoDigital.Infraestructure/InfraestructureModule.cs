using Autofac;
using HandsOnTestGoDigital.Core.Interfaces.Repositories;
using HandsOnTestGoDigital.Infraestructure.Data.APIMovie;

namespace HandsOnTestGoDigital.Infraestructure
{
    public class InfraestructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RepositoryWrapper>().As<IRepositoryWrapper>().InstancePerLifetimeScope();
        }
    }
}
