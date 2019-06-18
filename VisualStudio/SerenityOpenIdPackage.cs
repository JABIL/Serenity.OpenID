using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using BoDi;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.Win32;
using Serenity.OpenID.VsIntegration.Commands;
using Task = System.Threading.Tasks.Task;

namespace Serenity.OpenID.VsIntegration
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration("#110", "#112", GuidList.ProductId)]
    [Guid(GuidList.PackageGuidString)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
    public sealed class SerenityOpenIdPackage : AsyncPackage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SerenityOpenIdPackage"/> class.
        /// </summary>
        public SerenityOpenIdPackage()
        {

        }

        
        public IObjectContainer Container { get; private set; }

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initialization code that rely on services provided by VisualStudio.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token to monitor for initialization cancellation, which can occur when VS is shutting down.</param>
        /// <param name="progress">A provider for progress updates.</param>
        /// <returns>A task representing the async work of package initialization, or an already completed task if there is none. Do not return null from this method.</returns>
        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            base.Initialize();

            Container = VsContainerBuilder.CreateContainer(this);

            await ReGenerateAllCommand.InitializeAsync(this);

            await base.InitializeAsync(cancellationToken, progress);
        }
    }
}
