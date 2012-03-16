using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualStudio.TemplateWizard;
using EnvDTE;
using System.IO;

namespace GHWizard
{
  /// <summary>
  /// See: http://msdn.microsoft.com/en-us/library/ms185301.aspx
  /// </summary>
  public class CollectInformationWizard : IWizard
  {
    // This method is called before opening any item that 
    // has the OpenInEditor attribute.
    public void BeforeOpeningFile(ProjectItem projectItem)
    {
    }

    // This method is only called for item templates,
    // not for project templates.
    public void ProjectItemFinishedGenerating(ProjectItem
        projectItem)
    {
    }

    // This method is called after the project is created.
    public void RunFinished()
    {
    }

    public void RunStarted(object automationObject,
        Dictionary<string, string> replacementsDictionary,
        WizardRunKind runKind, object[] customParams)
    {
      bool shouldAdd;
      try
      {
        UserInputForm inputForm = new UserInputForm(replacementsDictionary);
        replacementsDictionary["$targetframeworkversion$"] = "3.5";
        shouldAdd = inputForm.ShowDialog() == DialogResult.OK;
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString());
        throw new WizardCancelledException("An error occurred.", ex);
      }

      if (!shouldAdd)
        throw new WizardBackoutException("User cancelled the wizard.");
    }

    public void ProjectFinishedGenerating(Project project)
    {
    }

    // This method is only called for item templates,
    // not for project templates.
    public bool ShouldAddProjectItem(string filePath)
    {
      return true;
    }
  }
}