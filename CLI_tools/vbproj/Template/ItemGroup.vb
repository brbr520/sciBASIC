﻿#Region "Microsoft.VisualBasic::6fe3289405c1eb056739042cbfcaf99f, ..\sciBASIC#\CLI_tools\vbproj\Template\ItemGroup.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xieguigang (xie.guigang@live.com)
    '       xie (genetics@smrucc.org)
    ' 
    ' Copyright (c) 2016 GPL3 Licensed
    ' 
    ' 
    ' GNU GENERAL PUBLIC LICENSE (GPL3)
    ' 
    ' This program is free software: you can redistribute it and/or modify
    ' it under the terms of the GNU General Public License as published by
    ' the Free Software Foundation, either version 3 of the License, or
    ' (at your option) any later version.
    ' 
    ' This program is distributed in the hope that it will be useful,
    ' but WITHOUT ANY WARRANTY; without even the implied warranty of
    ' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    ' GNU General Public License for more details.
    ' 
    ' You should have received a copy of the GNU General Public License
    ' along with this program. If not, see <http://www.gnu.org/licenses/>.

#End Region

Imports System.Xml.Serialization
Imports Microsoft.VisualBasic.Serialization.JSON

Public Class ItemGroup

    <XmlElement("Reference")>
    Public Property References As IncludeItem()
    <XmlElement("Import")>
    Public Property [Imports] As IncludeItem()
    <XmlElement("Compile")>
    Public Property Compiles As Compile()
    <XmlElement("None")>
    Public Property Nones As None()
    <XmlElement("BootstrapperPackage")>
    Public Property BootstrapperPackages As BootstrapperPackage()
    <XmlElement("EmbeddedResource")>
    Public Property EmbeddedResources As EmbeddedResource()
    <XmlElement("Content")>
    Public Property Contents As Content()
    <XmlElement("ProjectReference")>
    Public Property ProjectReferences As ProjectReference()

    Public Overrides Function ToString() As String
        Return Me.GetJson
    End Function
End Class

Public Class ProjectReference : Inherits IncludeItem
    Public Property Project As String
    Public Property Name As String
End Class

Public Class IncludeItem

    <XmlAttribute>
    Public Property Include As String
    Public Property HintPath As String
    Public Property [Private] As String

    Public Overrides Function ToString() As String
        Return Me.GetJson
    End Function
End Class

Public Class Compile : Inherits IncludeItem
    Public Property AutoGen As String
    Public Property DesignTime As String
    Public Property DependentUpon As String
    Public Property DesignTimeSharedInput As String
    Public Property SubType As String
End Class

Public Class None : Inherits IncludeItem
    Public Property Generator As String
    Public Property LastGenOutput As String
    Public Property CustomToolNamespace As String
End Class

Public Class EmbeddedResource : Inherits IncludeItem
    Public Property DependentUpon As String
    Public Property Generator As String
    Public Property LastGenOutput As String
    Public Property CustomToolNamespace As String
    Public Property SubType As String
End Class

Public Class BootstrapperPackage : Inherits IncludeItem
    Public Property Visible As String
    Public Property ProductName As String
    Public Property Install As String
End Class

Public Class Content : Inherits IncludeItem

End Class
