using System;
using System.Collections.Generic;
using Microsoft.Win32;
using System.IO;

namespace GHWizard
{
  class GrasshopperFinder
  {
    const string RH_REG = @"SOFTWARE\McNeel\Rhinoceros\6.0\Plug-ins\b45a29b1-4343-4035-989e-044e8580d9cf\PlugIn";
    const string RH_FOLDER_NAME = @"FolderName";
    const string GH_DLL = "Grasshopper.dll";

    public static bool FindGrasshopper(out string path, out string grasshopperDllName)
    {
      grasshopperDllName = GH_DLL;
      var strings = new List<string>();

      //Rhino 6
      SearchRegistryKey(RH_REG, RH_FOLDER_NAME,
        RegistryHive.CurrentUser, RegistryView.Registry64, strings);

      SearchRegistryKey(RH_REG, RH_FOLDER_NAME,
        RegistryHive.LocalMachine, RegistryView.Registry64, strings);

      foreach (var str in strings)
      {
        if (File.Exists(Path.Combine(str, GH_DLL)))
        {
          path = str;
          return true;
        }
      }

      path = null;
      return false;
    }


    /// <summary>
    /// Caution: this method swallows any exception.
    /// </summary>
    private static bool SearchRegistryKey(string keyName, string valueName, RegistryHive hive, RegistryView view, IList<string> found)
    {
      try
      {
        using (var registry_key = RegistryKey.OpenBaseKey(hive, view).OpenSubKey(keyName))
        {
          if (registry_key != null)
          {
            string value = registry_key.GetValue(valueName) as string;
            if (!string.IsNullOrEmpty(value))
            {
              if (!found.Contains(value))
                found.Add(value);
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
