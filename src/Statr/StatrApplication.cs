using System;
using System.Collections.Generic;
using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Statr.Installers;

namespace Statr
{
    public abstract class StatrApplication : IDisposable
    {
        public IWindsorContainer Container { get; private set; }

        public void Initialize()
        {
            Container = new WindsorContainer("Config/Windsor.xml");

            var defaultInstallers = new IWindsorInstaller[]
            {
                new InfrastructureInstaller()
            };

            var installers = defaultInstallers.Concat(GetInstallers()).ToArray();

            Container.Install(installers);
        }

        protected abstract IEnumerable<IWindsorInstaller> GetInstallers();

        public void Dispose()
        {
            Container.Dispose();
        }
    }
}