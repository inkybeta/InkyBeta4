using System.Reflection;
using System.Runtime.InteropServices;
using System.Web.Mvc;
using InkyBeta;
using InkyBeta.Core;
using InkyBeta.Data.DataContext;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using WebActivator;

[assembly: PostApplicationStartMethod(typeof(SimpleInjectorInitializer), "Initialize")]

namespace InkyBeta
{
	public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            // Did you know the container can diagnose your configuration? Go to: https://bit.ly/YE8OJj.
            var container = new Container();
            
            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            
            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {
            // For instance:
            // container.Register<IUserRepository, SqlUserRepository>();

			WebRequestLifestyle lifestyle = new WebRequestLifestyle(true);

			container.Register(() => new UserContext(), lifestyle);
			container.Register(() => new UserStore<User>(container.GetInstance<UserContext>()), lifestyle);
			container.Register(() => new UserManager<User>(container.GetInstance<UserStore<User>>()), lifestyle);
        }
    }
}