Imports System.Collections.Generic

Imports Grasshopper.Kernel
Imports Rhino.Geometry


Public Class $componentclassname$
	Inherits GH_Component
	''' <summary>
	''' Each implementation of GH_Component must provide a public 
	''' constructor without any arguments.
	''' Category represents the Tab in which the component will appear, 
	''' Subcategory the panel. If you use non-existing tab or panel names, 
	''' new tabs/panels will automatically be created.
	''' </summary>
	Public Sub New()
		MyBase.New("$componentvisualname$", "$componentnickname$", _
					"$componentdescription$", _
					"$componentcategory$", "$componentsubcategory$")
	End Sub

	''' <summary>
	''' Registers all the input parameters for this component.
	''' </summary>
	Protected Overrides Sub RegisterInputParams(pManager As GH_Component.GH_InputParamManager)
$if$ ($sampleIn$ == 1)' Use the pManager object to register your input parameters.
	' You can often supply default values when creating parameters.
	' By default, all parameters have item access, if you wish to import 
	' lists or trees, be sure to adjust the GH_ParamAccess argument to match.
	pManager.Register_PlaneParam("Plane", "P", "Base plane for spiral", Plane.WorldXY)
	pManager.Register_DoubleParam("Inner Radius", "R0", "Inner radius for spiral", 1.0)
	pManager.Register_DoubleParam("Outer Radius", "R1", "Outer radius for spiral", 10.0)
	pManager.Register_IntegerParam("Turns", "T", "Number of turns between inner and outer radii", 10)

	' If you want to change properties of certain parameters, 
	' you can use the pManager instance to access them by index:
	'pManager(0).Optional = True
$endif$	End Sub

	''' <summary>
	''' Registers all the output parameters for this component.
	''' </summary>
	Protected Overrides Sub RegisterOutputParams(pManager As GH_Component.GH_OutputParamManager)
$if$ ($sampleIn$ == 1)	' Use the pManager object to register your output parameters.
	' Output parameters do not have default values or access flags.

	' Sometimes you want to hide a specific parameter from the Rhino preview.
	' You can use the HideParameter() method as a quick way:
	'pManager.HideParameter(0)
	pManager.Register_CurveParam("Spiral", "S", "Spiral curve")
$endif$	End Sub

	''' <summary>
	''' This is the method that actually does the work.
	''' </summary>
	''' <param name="DA">The DA object can be used to retrieve data from input parameters and 
	''' to store data in output parameters.</param>
	Protected Overrides Sub SolveInstance(DA As IGH_DataAccess)
      $if$ ($sampleIn$ == 1)	' First, we need to retrieve all data from the input parameters.
	' We'll start by declaring variables and assigning them starting values.
	Dim plane As Plane = plane.WorldXY
	Dim radius0 As Double = 0.0
    Dim radius1 As Double = 0.0
    Dim turns As Int32 = 0

    ' Then we need to access the input parameters individually. 
    ' When data cannot be extracted from a parameter, we should abort this method.
    If (Not DA.GetData(0, plane)) Then Return
    If (Not DA.GetData(1, radius0)) Then Return
    If (Not DA.GetData(2, radius1)) Then Return
    If (Not DA.GetData(3, turns)) Then Return

    ' We should now validate the data and warn the user if invalid data is supplied.
    If (radius0 < 0.0) Then
      AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Spiral radius needs to be bigger than zero")
      Return
    End If
    If (radius1 <= radius0) Then
      AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Spiral outer radius needs to be bigger than the inner radius")
      Return
    End If
    If (turns <= 0) Then
      AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Spiral needs at least one turn")
      Return
    End If

    ' We're set to create the spiral now. To keep the size of the SolveInstance() method small, 
    ' The actual functionality will be in a different method:
    Dim spiral As Curve = CreateSpiral(plane, radius0, radius1, turns)

    ' Finally assign the spiral to the output parameter.
    DA.SetData(0, spiral)
$endif$	End Sub$if$ ($sampleIn$ == 1)

Private Function CreateSpiral(plane As Plane, r0 As Double, r1 As Double, turns As Int32) As Curve
	Dim l0 As New Line(r0, 0, 0, r1, 0, 0)
	Dim l1 As New Line(-r0, 0, 0, -r1, 0, 0)

    Dim p0 As Point3d() = Nothing
    Dim p1 As Point3d() = Nothing

	l0.ToNurbsCurve().DivideByCount(turns, True, p0)
	l1.ToNurbsCurve().DivideByCount(turns, True, p1)

	Dim spiral As New PolyCurve()

	For i As Integer = 0 To p0.Length - 2
		Dim arc0 As New Arc(p0(i), Vector3d.YAxis, p1(i + 1))
		Dim arc1 As New Arc(p1(i + 1), -Vector3d.YAxis, p0(i + 1))

		spiral.Append(arc0)
		spiral.Append(arc1)
	Next

	Return spiral
End Function

	''' <summary>
	''' The Exposure property controls where in the panel a component icon 
	''' will appear. There are seven possible locations (primary to septenary), 
	''' each of which can be combined with the GH_Exposure.obscure flag, which 
	''' ensures the component will only be visible on panel dropdowns.
	''' </summary>
	Public Overrides ReadOnly Property Exposure() As GH_Exposure
		Get
			Return GH_Exposure.primary
		End Get
	End Property
$endif$

	''' <summary>
	''' Provides an Icon for every component that will be visible in the User Interface.
	''' Icons need to be 24x24 pixels.
	''' </summary>
	Protected Overrides ReadOnly Property Icon() As System.Drawing.Bitmap
		Get
			'You can add image files to your project resources and access them like this:
			' return Resources.IconForThisComponent;
			Return Nothing
		End Get
	End Property

	''' <summary>
	''' Each component must have a unique Guid to identify it. 
	''' It is vital this Guid doesn't change otherwise old ghx files 
	''' that use the old ID will partially fail during loading.
	''' </summary>
	Public Overrides ReadOnly Property ComponentGuid() As Guid
		Get
			Return New Guid("{$guid2$}")
		End Get
	End Property
End Class