using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.IO;

namespace GHWizard
{
  class GrasshopperFinder
  {
    const string rh5_64_Reg = @"SOFTWARE\McNeel\Rhinoceros\5.0x64\Plug-ins\b45a29b1-4343-4035-989e-044e8580d9cf\PlugIn";
    const string rh5_32_Reg = @"SOFTWARE\McNeel\Rhinoceros\5.0\Plug-ins\b45a29b1-4343-4035-989e-044e8580d9cf\PlugIn";
    const string rh4_MostRecent = @"SOFTWARE\McNeel\Rhinoceros\4.0\{0}\Plug-ins\b45a29b1-4343-4035-989e-044e8580d9cf\PlugIn";
    const string rh5_RegName = @"FolderName";

    const string ghDll = "Grasshopper.dll";

    public static bool FindGrasshopper(out string path, out string grasshopperDllName)
    {
      var strings = new List<string>();

      //Rhino 5 64-bit old and new
      if (Environment.Is64BitOperatingSystem)
      {
        SearchRegistryKey(rh5_64_Reg, rh5_RegName,
          RegistryHive.LocalMachine, RegistryView.Registry64, strings);
          
          SearchRegistryKey(rh5_64_Reg, rh5_RegName,
          RegistryHive.CurrentUser, RegistryView.Registry64, strings);
      }

      //Rhino 5 32-bit
      SearchRegistryKey(rh5_32_Reg, rh5_RegName,
          RegistryHive.LocalMachine, RegistryView.Registry32, strings);
          
      //Rhino 5 32-bit old installation type
      SearchRegistryKey(rh5_32_Reg, rh5_RegName,
          RegistryHive.CurrentUser, RegistryView.Registry32, strings);

      //Grasshooper 
      {
        var f = new List<string>();
        if (SearchRegistryKey(@"SOFTWARE\McNeel\Rhinoceros\4.0\", "MostRecent", RegistryHive.LocalMachine, RegistryView.Registry32, f))
        {
          SearchRegistryKey(string.Format(rh4_MostRecent, f[0]), rh5_RegName, RegistryHive.LocalMachine, RegistryView.Registry32, strings);
        }
      }

      foreach (var str in strings)
      {
        if (File.Exists(Path.Combine(str, ghDll)))
        {
          path = str;
          grasshopperDllName = ghDll;
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
        using (var registryKey = RegistryKey.OpenBaseKey(hive, view).OpenSubKey(keyName))
        {
          if (registryKey != null)
          {
            string value = registryKey.GetValue(valueName) as string;
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
