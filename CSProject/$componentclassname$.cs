using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace $safeprojectname$
{
  public class $componentclassname$ : GH_Component
  {
    /// <summary>
    /// Each implementation of GH_Component must provide a public 
    /// constructor without any arguments.
    /// Category represents the Tab in which the component will appear, 
    /// Subcategory the panel. If you use non-existing tab or panel names, 
    /// new tabs/panels will automatically be created.
    /// </summary>
    public $componentclassname$()
      : base("$componentvisualname$", "$componentnickname$",
          "$componentdescription$",
          "$componentcategory$", "$componentsubcategory$")
    {
    }

    /// <summary>
    /// Registers all the input parameters for this component.
    /// </summary>
    protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
    {
      $if$ ($sampleIn$ == 1)// Use the pManager object to register your input parameters.
      // You can often supply default values when creating parameters.
      // By default, all parameters have item access, if you wish to import 
      // lists or trees, be sure to adjust the GH_ParamAccess argument to match.
      pManager.Register_PlaneParam("Plane", "P", "Base plane for spiral", Plane.WorldXY);
      pManager.Register_DoubleParam("Inner Radius", "R0", "Inner radius for spiral", 1.0);
      pManager.Register_DoubleParam("Outer Radius", "R1", "Outer radius for spiral", 10.0);
      pManager.Register_IntegerParam("Turns", "T", "Number of turns between inner and outer radii", 10);

      // If you want to change properties of certain parameters, 
      // you can use the pManager instance to access them by index:
      //pManager[0].Optional = true;
$endif$    }

    /// <summary>
    /// Registers all the output parameters for this component.
    /// </summary>
    protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
    {
      $if$ ($sampleIn$ == 1)// Use the pManager object to register your output parameters.
      // Output parameters do not have default values or access flags.
      pManager.Register_CurveParam("Spiral", "S", "Spiral curve");

      // Sometimes you want to hide a specific parameter from the Rhino preview.
      // You can use the HideParameter() method as a quick way:
      //pManager.HideParameter(0);
$endif$    }

    /// <summary>
    /// This is the method that actually does the work.
    /// </summary>
    /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
    /// to store data in output parameters.</param>
    protected override void SolveInstance(IGH_DataAccess DA)
    {
      $if$ ($sampleIn$ == 1)// First, we need to retrieve all data from the input parameters.
      // We'll start by declaring variables and assigning them starting values.
      Plane plane = Plane.WorldXY;
      double radius0 = 0.0;
      double radius1 = 0.0;
      int turns = 0;

      // Then we need to access the input parameters individually. 
      // When data cannot be extracted from a parameter, we should abort this method.
      if (!DA.GetData(0, ref plane)) return;
      if (!DA.GetData(1, ref radius0)) return;
      if (!DA.GetData(2, ref radius1)) return;
      if (!DA.GetData(3, ref turns)) return;

      // We should now validate the data and warn the user if invalid data is supplied.
      if (radius0 < 0.0)
      {
          AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Spiral radius needs to be bigger than zero");
          return;
      }
      if (radius1 <= radius0)
      {
          AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Spiral outer radius needs to be bigger than the inner radius");
          return;
      }
      if (turns <= 0)
      {
          AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Spiral needs at least one turn");
          return;
      }

      // We're set to create the spiral now. To keep the size of the SolveInstance() method small, 
      // The actual functionality will be in a different method:
      Curve spiral = CreateSpiral(plane, radius0, radius1, turns);

      // Finally assign the spiral to the output parameter.
      DA.SetData(0, spiral);
$endif$    }$if$ ($sampleIn$ == 1)

    private Curve CreateSpiral(Plane plane, double r0, double r1, Int32 turns)
    {
      Line l0 = new Line(r0, 0, 0, r1, 0, 0);
      Line l1 = new Line(-r0, 0, 0, -r1, 0, 0);

      Point3d[] p0;
      Point3d[] p1;

      l0.ToNurbsCurve().DivideByCount(turns, true, out p0);
      l1.ToNurbsCurve().DivideByCount(turns, true, out p1);

      PolyCurve spiral = new PolyCurve();

      for (int i = 0; i <= p0.Length - 2; i++)
      {
        Arc arc0 = new Arc(p0[i], Vector3d.YAxis, p1[i + 1]);
        Arc arc1 = new Arc(p1[i + 1], -Vector3d.YAxis, p0[i + 1]);

        spiral.Append(arc0);
        spiral.Append(arc1);
      }

      return spiral;
    }

    /// <summary>
    /// The Exposure property controls where in the panel a component icon 
    /// will appear. There are seven possible locations (primary to septenary), 
    /// each of which can be combined with the GH_Exposure.obscure flag, which 
    /// ensures the component will only be visible on panel dropdowns.
    /// </summary>
    public override GH_Exposure Exposure
    {
      get { return GH_Exposure.primary; }
    }$endif$

    /// <summary>
    /// Provides an Icon for every component that will be visible in the User Interface.
    /// Icons need to be 24x24 pixels.
    /// </summary>
    protected override System.Drawing.Bitmap Icon
    {
      get
      { 
        // You can add image files to your project resources and access them like this:
        //return Resources.IconForThisComponent;
        return null;
      }
    }

    /// <summary>
    /// Each component must have a unique Guid to identify it. 
    /// It is vital this Guid doesn't change otherwise old ghx files 
    /// that use the old ID will partially fail during loading.
    /// </summary>
    public override Guid ComponentGuid
    {
      get { return new Guid("{$guid2$}"); }
    }
  }
}