using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace GHWizard
{
  public partial class UserInputForm : Form
  {
    Dictionary<string, string> _replacements;

    public UserInputForm(Dictionary<string, string> replacements)
    {
      _replacements = replacements;
      InitializeComponent();

      if (_replacements != null)
      {
        //Title
        this.Text = string.Format(this.Text, _replacements["$safeprojectname$"]);

        addondisplayname.Text = _replacements["$safeprojectname$"];
        componentClassName.Text = _replacements["$safeprojectname$"] + "Component";

        componentVisualName.Text = _replacements["$safeprojectname$"];

        string path, exeName;
        
        bool ok32 = RhinoFinder.FindRhino5_32bit(out path, out exeName);
        rhino32path.Text = Path.Combine(path, exeName);
        rhino32.Checked = ok32;

        string path32 = path;
        bool ok64 = RhinoFinder.FindRhino5_64bit(out path, out exeName);
        rhino64path.Text = Path.Combine(path, exeName);
        rhino64.Checked = ok64;

        bool ghOk = GrasshopperFinder.FindGrasshopper(out path, out exeName);
        if (ghOk)
          grasshopperPath.Text = Path.Combine(path, exeName);
        else
        {
          rhinocommonPath.Text = "Please select a path to Grasshopper.dll to continue.";
          rhinocommonPath.ForeColor = Color.Red;
        }

        if (File.Exists(Path.Combine(path, "rhinocommon.dll")))
          rhinocommonPath.Text = Path.Combine(path, "rhinocommon.dll");
        else if (File.Exists(Path.Combine(path32, "rhinocommon.dll")))
          rhinocommonPath.Text = Path.Combine(path32, "rhinocommon.dll");
        else
        {
          rhinocommonPath.Text = "Please select a path to RhinoCommon.dll to continue.";
          rhinocommonPath.ForeColor = Color.Red;
        }

        EnableOrDisableContinue();

        if (!Environment.Is64BitOperatingSystem)
        {
          rhino64.Enabled = false;
          rhino64browse.Visible = false;
          rhino64path.Enabled = false;
          rhino64path.Text = "This operating system is 32-bit.";
        }
      }

      Font f = new Font(rhinocommonPath.Font.FontFamily,
        rhinocommonPath.Font.Size * 0.78f, rhinocommonPath.Font.Style, rhinocommonPath.Font.Unit, rhinocommonPath.Font.GdiCharSet);
      grasshopperPath.Font = f;
      rhinocommonPath.Font = f;
      rhino32path.Font = f;
      rhino64path.Font = f;
      eitheronetext.Font = f;
    }

    protected UserInputForm() : this(null)
    {
      if (!DesignMode)
        throw new NotSupportedException("This constructor is only for design.");
    }

    private void finishButton_Click(object sender, EventArgs e)
    {
    }

    protected override void OnClosing(CancelEventArgs e)
    {
      FinalVariableSetup();
      base.OnClosing(e);
    }

    private void EnableOrDisableContinue()
    {
      bool either32or64isChecked = rhino32.Checked || rhino64.Checked;

      eitheronetext.Visible = !either32or64isChecked;

      finish.Enabled =
        IsTextBoxAllRight(addondisplayname) && IsTextBoxAllRight(componentClassName) &&
        either32or64isChecked &&
        (rhino32.Checked ? File.Exists(rhino32path.Text) : true) &&
        (rhino64.Checked ? File.Exists(rhino64path.Text) : true) &&
        File.Exists(rhinocommonPath.Text) &&
        File.Exists(grasshopperPath.Text);
    }

    private bool IsTextBoxAllRight(TextBox tb)
    {
      return !string.IsNullOrEmpty(tb.Text);
    }

    private void eithertextbox_TextChanged(object sender, EventArgs e)
    {
      TextBox realSender = sender as TextBox;

      if (realSender != null)
      {
        string text = realSender.Text;

        const string pattern = "^[^A-Za-z]+|[^A-Za-z0-9]+"; //finds bad chars at beginning or around
        if (Regex.IsMatch(text, pattern))
        {
          text = Regex.Replace(text, pattern, string.Empty);
          realSender.Text = text;
        }
      }

      if (componentClassName.Text == _replacements["$safeprojectname$"])
        componentClassName.Text = _replacements["$safeprojectname$"] + "Component";

      EnableOrDisableContinue();
    }

    private void rhino32_CheckedChanged(object sender, EventArgs e)
    {
      EnableDisablePath(rhino32, rhino32path, rhino32browse);
    }

    private void rhino64_CheckedChanged(object sender, EventArgs e)
    {
      EnableDisablePath(rhino64, rhino64path, rhino64browse);
    }

    private void EnableDisablePath(CheckBox rhino, Label path, Button browse)
    {
      if (rhino.Checked && !File.Exists(path.Text))
      {
        browse.PerformClick();
        if (!File.Exists(path.Text))
          rhino.Checked = false;
      }

      path.Visible = rhino.Checked;
      EnableOrDisableContinue();
    }

    private void rhino32browse_Click(object sender, EventArgs e)
    {
      string startAt = File.Exists(rhino32path.Text) ? rhino32path.Text :
        Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);

      string location;
      if (GetLocation("Rhino 5 32-bit executable", "Rhino4.exe", startAt, out location))
      {
        rhino32path.Text = location;
        rhino32.Checked = true;
        EnableOrDisableContinue();
      }
    }

    private void rhino64browse_Click(object sender, EventArgs e)
    {
      string startAt = File.Exists(rhino64path.Text) ? rhino64path.Text : Get64BitPath();

      string location;
      if (GetLocation("Rhino 5 64-bit executable", "Rhino.exe", startAt, out location))
      {
        rhino64path.Text = location;
        rhino64.Checked = true;
        EnableOrDisableContinue();
      }
    }

    private static string Get64BitPath()
    {
      string path = string.Empty;
      try
      {
        if (Environment.Is64BitProcess)
          path = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
        else
          path = Environment.GetEnvironmentVariable("ProgramW6432");
      }
      catch { }
      return path;
    }

    private void browseRhinocommon_Click(object sender, EventArgs e)
    {
      string startAt = File.Exists(rhinocommonPath.Text) ? rhinocommonPath.Text :
        Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

      string location;
      if (GetLocation("RhinoCommon library", "RhinoCommon.dll", startAt, out location))
      {
        rhinocommonPath.Text = location;
        rhinocommonPath.ForeColor = SystemColors.ControlDark;
        EnableOrDisableContinue();
      }
    }

    private void browseGrasshopper_Click(object sender, EventArgs e)
    {
      string startAt = File.Exists(grasshopperPath.Text) ? grasshopperPath.Text :
        Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

      string location;
      if (GetLocation("Grasshopper library", "Grasshopper.dll", startAt, out location))
      {
        grasshopperPath.Text = location;
        grasshopperPath.ForeColor = SystemColors.ControlDark;
        EnableOrDisableContinue();
      }
    }

    private static bool GetLocation(string userName, string fileName, string startAt, out string location)
    {
      using (var ofd = new OpenFileDialog())
      {
        ofd.Title = string.Format("Find {0}", userName);
        if (Directory.Exists(startAt))
          ofd.InitialDirectory = startAt;
        else if(File.Exists(startAt))
          ofd.InitialDirectory = Path.GetDirectoryName(startAt);
        ofd.Filter = string.Format("{0} ({1})|{1}",
          userName, fileName);
        if (ofd.ShowDialog() == DialogResult.OK)
        {
          location = ofd.FileName;
          return true;
        }
      }
      location = string.Empty;
      return false;
    }

    private void FinalVariableSetup()
    {
      _replacements["$infoclassname$"] = _replacements["$safeprojectname$"] + "Info";
      _replacements["$infovisualname$"] = addondisplayname.Text;

      _replacements["$componentclassname$"] = componentClassName.Text;

      _replacements["$componentvisualname$"] = componentVisualName.Text;

      _replacements["$componentnickname$"] =
        string.IsNullOrWhiteSpace(componentnickname.Text) ?
        Abbreviate(componentVisualName.Text, 3) : componentnickname.Text;

      _replacements["$sampleIn$"] = commandsample.Checked ? "1" : "0";

      _replacements["$componentcategory$"] = componentCategory.Text;
      _replacements["$componentsubcategory$"] = componentSubcategory.Text;
      _replacements["$componentdescription$"] = componentDescription.Text;

      _replacements["$grasshopperURL$"] = grasshopperPath.Text;
      _replacements["$ghioURL$"] = Path.Combine(Path.GetDirectoryName(grasshopperPath.Text), "GH_IO.dll");
      _replacements["$rhinocommonURL$"] = rhinocommonPath.Text;

      _replacements["$rhino5_32_checked$"] = rhino32.Checked ? "1" : "0";
      _replacements["$rhino5_32_URL$"] = rhino32path.Text;

      _replacements["$rhino5_64_checked$"] = rhino64.Checked ? "1" : "0";
      _replacements["$rhino5_64_URL$"] = rhino64path.Text;
    }

    private static string Abbreviate(string txt, int length)
    {
      if (string.IsNullOrEmpty(txt)) return string.Empty;
      return txt.Substring(0, Math.Min(length, txt.Length - 1));
    }

    private void commandsample_CheckedChanged(object sender, EventArgs e)
    {
      if (commandsample.Checked)
      {
        SuspendLayout();
        if (componentVisualName.Text == "Name")
          componentVisualName.Text = "Archimedean spiral";
        componentnickname.Text = "ASpi";
        if (componentCategory.Text == "Category")
          componentCategory.Text = "Curve";
        if (componentSubcategory.Text == "Subcategory")
          componentSubcategory.Text = "Primitive";
        componentDescription.Text = "Construct an Archimedean, or arithmetic, spiral given its radii and number of turns.";
        componentDescription.Enabled = false;
        ResumeLayout(true);
      }
      else
      {
        componentDescription.Enabled = true;
      }
    }
  }
}
