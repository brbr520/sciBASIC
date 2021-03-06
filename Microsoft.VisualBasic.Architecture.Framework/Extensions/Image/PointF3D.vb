﻿#Region "Microsoft.VisualBasic::b70ed42a2afa9a49564dac1214e5d1c3, ..\sciBASIC#\Microsoft.VisualBasic.Architecture.Framework\Extensions\Image\PointF3D.vb"

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

Namespace Imaging

    ''' <summary>
    ''' 这个接口是为了实现Imaging模块的Point3D对象和数学函数模块的3D插值模块的兼容
    ''' </summary>
    Public Interface PointF3D
        Property X!
        Property Y!
        Property Z!
    End Interface
End Namespace
