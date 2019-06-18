using System;
using EnvDTE;
using Microsoft.VisualStudio.Shell;

namespace Serenity.OpenID.VsIntegration.Commands
{
    public abstract class SereneProjectSingleSelectionCommand : MenuCommandHandler
    {
        protected SereneProjectSingleSelectionCommand(IServiceProvider serviceProvider, DTE dte) : 
            base(serviceProvider, dte)
        {
        }

        protected override void BeforeQueryStatus(OleMenuCommand command, SelectedItems selection)
        {
            if (!IsInSpecFlowProject(selection))
            {
                command.Visible = false;
                return;
            }

            if (selection.Count == 1)
            {
                command.Enabled = true;
            }
        }

        private bool IsInSpecFlowProject(SelectedItems selection)
        {
            for (int selectionIndex = 1; selectionIndex <= selection.Count; selectionIndex++)
                if (IsInSpecFlowProject(selection.Item(selectionIndex)))
                    return true;
            return false;
        }

        private bool IsInSpecFlowProject(SelectedItem selectedItem)
        {
            if (selectedItem.Project != null)
                return IsInSpecFlowProject(selectedItem.Project);
            if (selectedItem.ProjectItem != null)
                return IsInSpecFlowProject(selectedItem.ProjectItem.ContainingProject);
            return false;
        }

        private bool IsInSpecFlowProject(Project containingProject)
        {
            return true;
        }
    }
}