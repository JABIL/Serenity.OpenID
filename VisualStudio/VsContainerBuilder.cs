using BoDi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serenity.OpenID.VsIntegration
{
   public static class VsContainerBuilder
    {
        internal static DefaultDependencyProvider DefaultDependencyProvider = new DefaultDependencyProvider();

        public static IObjectContainer CreateContainer(SerenityOpenIdPackage package)
        {
            var container = new ObjectContainer();

            container.RegisterInstanceAs(package);
            container.RegisterInstanceAs<IServiceProvider>(package);

            RegisterDefaults(container);

            BiDiContainerProvider.Init(container); //TODO: avoid static field

            return container;
        }

        private static void RegisterDefaults(IObjectContainer container)
        {
            DefaultDependencyProvider.RegisterDefaults(container);
        }
    }
}