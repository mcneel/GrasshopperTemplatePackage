Grasshopper SDK Wizards Package
===============================

What Is This?
-------------
If you want to create a custom grasshopper component (www.grasshopper3d.com), it is good
to have a project wizard to get you started. Visual Studio has a grasshopper project
wizard that can be found by searching for "grasshopper" in the extension manager's online
gallery. The code here is used for building this Visual Studio project wizard.

Building
--------
You need Visual Studio 2010

You also need the Visual Studio SDK:
http://www.microsoft.com/en-us/download/details.aspx?id=21835

Using VS IDE complilation in Release mode with GrasshopperTemplatePackage as default
project should produce a file named "RCPackage.vsix" inside /GrasshopperTemplatePackage/bin.

Updating
--------
Do not change the ID of the project and modify the version as stated in 
source.extension.vsixmanifest to trigger update.

Copyright
---------
Copyright (c) 2013 Robert McNeel & Associates. All Rights Reserved.

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to use,
copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the
Software.

THIS SOFTWARE IS PROVIDED "AS IS" WITHOUT EXPRESS OR IMPLIED WARRANTY. ALL IMPLIED
WARRANTIES OF FITNESS FOR ANY PARTICULAR PURPOSE AND OF MERCHANTABILITY ARE HEREBY
DISCLAIMED.

Rhinoceros is a registered trademark of Robert McNeel & Associates.
