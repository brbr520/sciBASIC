﻿#Region "Microsoft.VisualBasic::5e52fb923691786f6ed99bbb88af77c4, ..\sciBASIC#\Data_science\Mathematical\Math.Statistics\HypothesisTesting\Hypothesis.vb"

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

Namespace Hypothesis

    Public Enum Hypothesis
        ''' <summary>
        ''' ``mu > mu0``
        ''' </summary>
        Greater
        ''' <summary>
        ''' ``mu &lt; mu0``
        ''' </summary>
        Less
        ''' <summary>
        ''' ``mu &lt;> mu0``
        ''' </summary>
        TwoSided
    End Enum
End Namespace
