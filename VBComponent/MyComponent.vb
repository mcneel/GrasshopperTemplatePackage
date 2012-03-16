Imports System.Collections.Generic

Imports Grasshopper.Kernel
Imports Rhino.Geometry


Public Class $componentclassname$
	Inherits GH_Component
	''' <summary>
	''' Initializes a new instance of the $safeitemrootname$ class.
	''' </summary>
	Public Sub New()
		MyBase.New("$componentvisualname$", "Nickname", _
					"Description", _
					"Category", "Subcategory")
	End Sub

	''' <summary>
	''' Registers all the input parameters for this component.
	''' </summary>
	Protected Overrides Sub RegisterInputParams(pManager As GH_Component.GH_InputParamManager)
    End Sub

	''' <summary>
	''' Registers all the output parameters for this component.
	''' </summary>
	Protected Overrides Sub RegisterOutputParams(pManager As GH_Component.GH_OutputParamManager)
    End Sub

	''' <summary>
	''' This is the method that actually does the work.
	''' </summary>
    ''' <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
	Protected Overrides Sub SolveInstance(DA As IGH_DataAccess)
	End Sub

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
	''' Gets the unique ID for this component. Do not change this ID after release.
	''' </summary>
	Public Overrides ReadOnly Property ComponentGuid() As Guid
		Get
			Return New Guid("{$guid2$}")
		End Get
	End Property
End Class