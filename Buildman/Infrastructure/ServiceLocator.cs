using Buildman.Jenkins.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Buildman.Infrastructure.ServiceLocator
{
    public static class ServiceLocator
    {
        private static Dictionary<object, object> _services;

        public static void Initialize()
        {
            _services = new Dictionary<object, object>();

            _services.Add(typeof(IJenkinsManager), new JenkinsManager() );

        }

        public static T GetService<T>()
        {
            try
            {
                return (T) _services[typeof(T)];
            }
            catch (Exception)
            {

                throw new Exception("The requested service is not registered");
            }
        }
    }
}