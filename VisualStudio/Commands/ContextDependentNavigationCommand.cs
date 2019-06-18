using System;
using EnvDTE;

namespace Serenity.OpenID.VsIntegration.Commands
{
    public class ContextDependentNavigationCommand : MenuCommandHandler
    {
        public ContextDependentNavigationCommand(IServiceProvider serviceProvider, DTE dte, object goToStepsCommand, object goToStepDefinitionCommand) : base(serviceProvider, dte)
        {
        }

       

    }
}
