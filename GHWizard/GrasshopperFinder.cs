using System;
using System.Collections.Generic;
using Microsoft.Win32;
using System.IO;

namespace GHWizard
{
  class GrasshopperFinder
  {
    const string RH5_64_REG = @"SOFTWARE\McNeel\Rhinoceros\5.0x64\Plug-ins\b45a29b1-4343-4035-989e-044e8580d9cf\PlugIn";
    const string RH5_32_REG = @"SOFTWARE\McNeel\Rhinoceros\5.0\Plug-ins\b45a29b1-4343-4035-989e-044e8580d9cf\PlugIn";
    const string RH5_REG_NAME = @"FolderName";
    const string GH_DLL = "Grasshopper.dll";

    public static bool FindGrasshopper(out string path, out string grasshopperDllName)
    {
      // always search current user first since it is most likely to contain the
      // most recently modified key. RegQueryInfo is not available in .NET. This
      // is the function that we should be using to figure out the proper string
      // to use based on last modified time, but for now things should work for
      // the most part.

      var strings = new List<string>();

      //Rhino 5 64-bit old and new
      if (Environment.Is64BitOperatingSystem)
      {
        SearchRegistryKey(RH5_64_REG, RH5_REG_NAME,
          RegistryHive.CurrentUser, RegistryView.Registry64, strings);

        SearchRegistryKey(RH5_64_REG, RH5_REG_NAME,
          RegistryHive.LocalMachine, RegistryView.Registry64, strings);
      }

      //Rhino 5 32-bit old installation type
      SearchRegistryKey(RH5_32_REG, RH5_REG_NAME,
          RegistryHive.CurrentUser, RegistryView.Registry32, strings);

      //Rhino 5 32-bit
      SearchRegistryKey(RH5_32_REG, RH5_REG_NAME,
          RegistryHive.LocalMachine, RegistryView.Registry32, strings);

      foreach (var str in strings)
      {
        if (File.Exists(Path.Combine(str, GH_DLL)))
        {
          path = str;
          grasshopperDllName = GH_DLL;
          return true;
        }
      }

      path = null;
      grasshopperDllName = null;
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
