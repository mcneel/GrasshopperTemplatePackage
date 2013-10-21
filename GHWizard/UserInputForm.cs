using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace GHWizard
{
  public partial class UserInputForm : Form
  {
    readonly Dictionary<string, string> m_replacements;

    public UserInputForm(Dictionary<string, string> replacements)
    {
      m_replacements = replacements;
      InitializeComponent();

      if (m_replacements != null)
      {
        //Title
        this.Text = string.Format(this.Text, m_replacements["$safeprojectname$"]);

        addondisplayname.Text = m_replacements["$safeprojectname$"];
        componentClassName.Text = m_replacements["$safeprojectname$"] + "Component";

        componentVisualName.Text = m_replacements["$safeprojectname$"];

        string path, exe_name;
        
        bool ok32 = RhinoFinder.FindRhino5_32bit(out path, out exe_name);
        rhino32path.Text = Path.Combine(path, exe_name);
        rhino32.Checked = ok32;

        string path32 = path;
        bool ok64 = RhinoFinder.FindRhino5_64bit(out path, out exe_name);
        rhino64path.Text = Path.Combine(path, exe_name);
        rhino64.Checked = ok64;

        bool gh_ok = GrasshopperFinder.FindGrasshopper(out path, out exe_name);
        if (gh_ok)
          grasshopperPath.Text = Path.Combine(path, exe_name);
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

    protected override void OnClosing(CancelEventArgs e)
    {
      FinalVariableSetup();
      base.OnClosing(e);
    }

    private void EnableOrDisableContinue()
    {
      bool either_checked = rhino32.Checked || rhino64.Checked;

      eitheronetext.Visible = !either_checked;

      finish.Enabled =
        IsTextBoxAllRight(addondisplayname) && IsTextBoxAllRight(componentClassName) &&
        either_checked &&
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
      TextBox real_sender = sender as TextBox;

      if (real_sender != null)
      {
        string text = real_sender.Text;

        const string pattern = "^[^A-Za-z]+|[^A-Za-z0-9]+"; //finds bad chars at beginning or around
        if (Regex.IsMatch(text, pattern))
        {
          text = Regex.Replace(text, pattern, string.Empty);
          real_sender.Text = text;
        }
      }

      if (componentClassName.Text == m_replacements["$safeprojectname$"])
        componentClassName.Text = m_replacements["$safeprojectname$"] + "Component";

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
      string start_at = File.Exists(rhino32path.Text) ? rhino32path.Text :
        Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);

      string location;
      if (GetLocation("Rhino 5 32-bit executable", "Rhino4.exe", start_at, out location))
      {
        rhino32path.Text = location;
        rhino32.Checked = true;
        EnableOrDisableContinue();
      }
    }

    private void rhino64browse_Click(object sender, EventArgs e)
    {
      string start_at = File.Exists(rhino64path.Text) ? rhino64path.Text : Get64BitPath();

      string location;
      if (GetLocation("Rhino 5 64-bit executable", "Rhino.exe", start_at, out location))
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
        path = Environment.Is64BitProcess ? Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)
          : Environment.GetEnvironmentVariable("ProgramW6432");
      }
      catch { }
      return path;
    }

    private void browseRhinocommon_Click(object sender, EventArgs e)
    {
      string start_at = File.Exists(rhinocommonPath.Text) ? rhinocommonPath.Text :
        Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

      string location;
      if (GetLocation("RhinoCommon library", "RhinoCommon.dll", start_at, out location))
      {
        rhinocommonPath.Text = location;
        rhinocommonPath.ForeColor = SystemColors.ControlDark;
        EnableOrDisableContinue();
      }
    }

    private void browseGrasshopper_Click(object sender, EventArgs e)
    {
      string start_at = File.Exists(grasshopperPath.Text) ? grasshopperPath.Text :
        Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

      string location;
      if (GetLocation("Grasshopper library", "Grasshopper.dll", start_at, out location))
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
      m_replacements["$infoclassname$"] = m_replacements["$safeprojectname$"] + "Info";
      m_replacements["$infovisualname$"] = addondisplayname.Text;

      m_replacements["$componentclassname$"] = componentClassName.Text;

      m_replacements["$componentvisualname$"] = componentVisualName.Text;

      m_replacements["$componentnickname$"] =
        string.IsNullOrWhiteSpace(componentnickname.Text) ?
        Abbreviate(componentVisualName.Text, 3) : componentnickname.Text;

      m_replacements["$sampleIn$"] = commandsample.Checked ? "1" : "0";

      m_replacements["$componentcategory$"] = componentCategory.Text;
      m_replacements["$componentsubcategory$"] = componentSubcategory.Text;
      m_replacements["$componentdescription$"] = componentDescription.Text;

      m_replacements["$grasshopperURL$"] = grasshopperPath.Text;
      m_replacements["$ghioURL$"] = Path.Combine(Path.GetDirectoryName(grasshopperPath.Text), "GH_IO.dll");
      m_replacements["$rhinocommonURL$"] = rhinocommonPath.Text;

      m_replacements["$rhino5_32_checked$"] = rhino32.Checked ? "1" : "0";
      m_replacements["$rhino5_32_URL$"] = rhino32path.Text;

      m_replacements["$rhino5_64_checked$"] = rhino64.Checked ? "1" : "0";
      m_replacements["$rhino5_64_URL$"] = rhino64path.Text;
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
