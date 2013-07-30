// Guids.cs
// MUST match guids.h
using System;

namespace GHPackage
{
  static class GuidList
  {
    public const string guidGrasshopperTemplatePackagePkgString = "AAAC8686-0327-4F9C-88F5-32F61FE96A51";
    public const string guidGrasshopperTemplatePackageCmdSetString = "084208A3-23A8-441A-978D-17C6902DA5B7";
    public static readonly Guid guidGrasshopperTemplatePackageCmdSet = new Guid(guidGrasshopperTemplatePackageCmdSetString);
  };
}