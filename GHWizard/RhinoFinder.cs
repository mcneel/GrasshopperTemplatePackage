using System;
using System.Collections.Generic;
using Microsoft.Win32;
using System.IO;

namespace GHWizard
{
  static class RhinoFinder
  {
    const string RHINO_EXE = "Rhino.exe";
    const string RHINO4_EXE = "Rhino4.exe";
    const string RHINO5_EXE = "Rhino5.exe";

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
          if (File.Exists(Path.Combine(path, RHINO_EXE)))
          {
            rhinoExeName = RHINO_EXE;
            return true;
          }

          if (File.Exists(Path.Combine(path, RHINO4_EXE)))
          {
            rhinoExeName = RHINO4_EXE;
            return true;
          }

          if (File.Exists(Path.Combine(path, RHINO5_EXE)))
          {
            rhinoExeName = RHINO5_EXE;
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
        if (File.Exists(Path.Combine(path, RHINO4_EXE)))
        {
          rhinoExeName = RHINO4_EXE;
          return true;
        }

        if (File.Exists(Path.Combine(path, RHINO_EXE))) // In case we change out minds later...
        {
          rhinoExeName = RHINO_EXE;
          return true;
        }

        if (File.Exists(Path.Combine(path, RHINO5_EXE)))
        {
          rhinoExeName = RHINO5_EXE;
          return true;
        }
      }

      rhinoExeName = string.Empty; path = string.Empty; return false;
    }

    /// <summary>
    /// Caution: this method swallows any exception.
    /// </summary>
    private static void SearchRegistryKey(string keyName, RegistryHive hive, RegistryView view, IList<string> installPaths)
    {
      try
      {
        using (var registry_key = RegistryKey.OpenBaseKey(hive, view).OpenSubKey(keyName))
        {
          if (registry_key != null)
          {
            string value = registry_key.GetValue("InstallPath") as string;
            if (!string.IsNullOrEmpty(value))
            {
              if (!installPaths.Contains(value))
                installPaths.Add(value);
            }
          }
        }
      }
      catch { }
    }
  }
}
