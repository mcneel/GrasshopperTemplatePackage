using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;

namespace GHPackage
{
  /// <summary>
  /// This is the class that implements the package exposed by this assembly.
  ///
  /// The minimum requirement for a class to be considered a valid package for Visual Studio
  /// is to implement the IVsPackage interface and register itself with the shell.
  /// This package uses the helper classes defined inside the Managed Package Framework (MPF)
  /// to do it: it derives from the Package class that provides the implementation of the 
  /// IVsPackage interface and uses the registration attributes defined in the framework to 
  /// register itself and its components with the shell.
  /// </summary>
  // tells the PkgDef creation utility (CreatePkgDef.exe) that this is a package
  [PackageRegistration(UseManagedResourcesOnly = true)]
  // register the information needed to show the this package in the Help/About dialog of VS2010
  // #110 and #112 refer to strings in VSPackage.resx
  [InstalledProductRegistration("#110", "#112", "1.1.0.0", IconResourceID = 400)]
  [Guid(GuidList.guidGrasshopperTemplatePackagePkgString)]
  public sealed class GrasshopperTemplatePackage : Package
  {
    /// <summary>
    /// Don't do any work in the constructor. Initialization shoud occur in the
    /// Initialize function.
    /// </summary>
    protected override void Initialize()
    {
      Trace.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering Initialize() of: {0}", this));
      base.Initialize();
    }
  }
}
