using System;
using System.Drawing;
using Grasshopper.Kernel;

namespace $safeprojectname$
{
  public class $infoclassname$ : GH_AssemblyInfo
  {
    public override string Name
    {
      get
      {
        return "$infovisualname$";
      }
    }
    public override Bitmap Icon
    {
      get
      {
        //Return a 24x24 pixel bitmap to represent this GHA library.
        return null;
      }
    }
    public override string Description
    {
      get
      {
        //Return a short string describing the purpose of this GHA library.
        return "";
      }
    }
    public override Guid Id
    {
      get
      {
        return new Guid("$guidGHA$");
      }
    }

    public override string AuthorName
    {
      get
      {
        //Return a string identifying you or your company.
        return "$registeredorganization$";
      }
    }
    public override string AuthorContact
    {
      get
      {
        //Return a string representing your preferred contact details.
        return "";
      }
    }
  }
}
