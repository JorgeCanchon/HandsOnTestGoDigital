using Autofac;
using HandsOnTestGoDigital.Core.UseCases.Movies;

namespace HandsOnTestGoDigital.Core
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MovieInteractor>().As<IMovieInteractor>().SingleInstance();
        }
    }
}
