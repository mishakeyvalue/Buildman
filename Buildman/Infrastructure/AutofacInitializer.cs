using System.Web.Http;
using Buildman.Jenkins.Managers;
using SimpleInjector;
using System.Web.Http.Dependencies;

public static class SimpleInjectorInitializer
{
    public static void Initialize()
    {
        var container = new Container();
        builder.RegisterServices();
        var container = builder.Build();
        DependencyResolver.SetResolver
    }

    private static void RegisterServices(this ContainerBuilder builder)
    {

        builder.Register<IJenkinsManager>((context) => new JenkinsManager() );
    }
}