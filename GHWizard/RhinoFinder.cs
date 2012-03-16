using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.IO;

namespace GHWizard
{
  static class RhinoFinder
  {
    const string rhinoExe = "Rhino.exe";
    const string rhino4Exe = "Rhino4.exe";
    const string rhino5Exe = "Rhino5.exe";

    public static bool FindRhino5_64bit(out string path, out string rhinoExeName)
    {
      var strings = new List<string>();

      if (Environment.Is64BitOperatingSystem)
      {
        SearchRegistryKey(@"Software\McNeel\Rhinoceros\5.0x64\Install",
          RegistryHive.LocalMachine, RegistryView.Registry64, strings);

        SearchRegistryKey(@"Software\McNeel\Rhinoceros\5.0x64\Install",
          RegistryHive.CurrentUser, RegistryView.Registry64, strings);


        foreach (var str in strings)
        {
          path = Path.Combine(str, "System");
          if (File.Exists(Path.Combine(path, rhinoExe)))
          {
            rhinoExeName = rhinoExe;
            return true;
          }

          if (File.Exists(Path.Combine(path, rhino4Exe)))
          {
            rhinoExeName = rhino4Exe;
            return true;
          }

          if (File.Exists(Path.Combine(path, rhino5Exe)))
          {
            rhinoExeName = rhino5Exe;
            return true;
          }
        }
      }

      rhinoExeName = string.Empty; path = string.Empty; return false;
    }

    public static bool FindRhino5_32bit(out string path, out string rhinoExeName)
    {
      var strings = new List<string>();
      SearchRegistryKey(@"Software\McNeel\Rhinoceros\5.0\Install",
        RegistryHive.LocalMachine, RegistryView.Registry32, strings);

      SearchRegistryKey(@"Software\Wow6432Node\McNeel\Rhinoceros\5.0\Install",
        RegistryHive.LocalMachine, RegistryView.Registry32, strings);

      SearchRegistryKey(@"Software\McNeel\Rhinoceros\5.0\Install",
        RegistryHive.CurrentUser, RegistryView.Registry32, strings);

      SearchRegistryKey(@"Software\Wow6432Node\McNeel\Rhinoceros\5.0\Install",
        RegistryHive.CurrentUser, RegistryView.Registry32, strings);

      foreach (var str in strings)
      {
        path = Path.Combine(str, "System");
        if (File.Exists(Path.Combine(path, rhino4Exe)))
        {
          rhinoExeName = rhino4Exe;
          return true;
        }

        if (File.Exists(Path.Combine(path, rhinoExe))) // In case we change out minds later...
        {
          rhinoExeName = rhinoExe;
          return true;
        }

        if (File.Exists(Path.Combine(path, rhino5Exe)))
        {
          rhinoExeName = rhino5Exe;
          return true;
        }
      }

      rhinoExeName = string.Empty; path = string.Empty; return false;
    }

    /// <summary>
    /// Caution: this method swallows any exception.
    /// </summary>
    private static bool SearchRegistryKey(string keyName, RegistryHive hive, RegistryView view, IList<string> installPaths)
    {
      try
      {
        using (var registryKey = RegistryKey.OpenBaseKey(hive, view).OpenSubKey(keyName))
        {
          if (registryKey != null)
          {
            string value = registryKey.GetValue("InstallPath") as string;
            if (!string.IsNullOrEmpty(value))
            {
              if (!installPaths.Contains(value))
                installPaths.Add(value);
              return true;
            }
          }
        }
      }
      catch { }
      return false;
    }
  }
}
