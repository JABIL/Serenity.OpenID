using System;
using System.ComponentModel.Design;
using System.Globalization;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Serenity.OpenID.VsIntegration.Commands
{
    internal sealed class ReGenerateAllCommand : SereneProjectSingleSelectionCommand
    {
        public const int CommandId = 0x0104;
        public static readonly Guid CommandSet = new Guid("563de300-9c6a-4eeb-b2ff-126fc3114379");
        private readonly AsyncPackage package;

        private ReGenerateAllCommand(IServiceProvider serviceProvider,
            DTE dte)
          : base(serviceProvider, dte)
        {
        }

        public static ReGenerateAllCommand Instance
        {
            get;
            private set;
        }

        private Microsoft.VisualStudio.Shell.IAsyncServiceProvider ServiceProvider
        {
            get
            {
                return this.package;
            }
        }

        private void Execute(object sender, EventArgs e)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            string message = string.Format(CultureInfo.CurrentCulture, "Inside {0}.MenuItemCallback()", this.GetType().FullName);
            string title = "ReGenerateAllCommand";

            // Show a message box to prove we were here
            VsShellUtilities.ShowMessageBox(
                this.package,
                message,
                title,
                OLEMSGICON.OLEMSGICON_INFO,
                OLEMSGBUTTON.OLEMSGBUTTON_OK,
                OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
        }

        internal static async System.Threading.Tasks.Task InitializeAsync(SerenityOpenIdPackage package)
        {
            OleMenuCommandService menuCommandService = await package.GetServiceAsync(typeof(IMenuCommandService)) as OleMenuCommandService;
           
            if (menuCommandService != null)
            {
                foreach (var menuCommandHandler in package.Container.Resolve<IDictionary<OpenIDCmdSet, MenuCommandHandler>>())
                {
                    menuCommandHandler.Value.RegisterTo(menuCommandService, menuCommandHandler.Key);
                }
            }

            Instance = package.Container.Resolve<ReGenerateAllCommand>();
        }
    }
}
