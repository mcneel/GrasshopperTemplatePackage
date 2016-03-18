using System;
using System.Collections.Generic;
using Microsoft.Win32;
using System.IO;

namespace GHWizard
{
  static class RhinoFinder
  {
    const string RhinoExe = "Rhino.exe";

    public static bool FindRhino6(out string path, out string rhinoExeName)
    {
      var strings = new List<string>();

      if (Environment.Is64BitOperatingSystem)
      {
        SearchRegistryKey(@"Software\McNeel\Rhinoceros\6.0\Install",
          RegistryHive.LocalMachine, RegistryView.Registry64, strings);

        SearchRegistryKey(@"Software\McNeel\Rhinoceros\6.0\Install",
          RegistryHive.CurrentUser, RegistryView.Registry64, strings);


        foreach (var str in strings)
        {
          path = Path.Combine(str, "System");
          if (File.Exists(Path.Combine(path, RhinoExe)))
          {
            rhinoExeName = RhinoExe;
            return true;
          }
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
