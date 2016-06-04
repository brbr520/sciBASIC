'! 
'@file Spring.cs
'@author Woong Gyu La a.k.a Chris. <juhgiyo@gmail.com>
'		<http://github.com/juhgiyo/epForceDirectedGraph.cs>
'@date August 08, 2013
'@brief Spring Interface
'@version 1.0
'
'@section LICENSE
'
'The MIT License (MIT)
'
'Copyright (c) 2013 Woong Gyu La <juhgiyo@gmail.com>
'
'Permission is hereby granted, free of charge, to any person obtaining a copy
'of this software and associated documentation files (the "Software"), to deal
'in the Software without restriction, including without limitation the rights
'to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
'copies of the Software, and to permit persons to whom the Software is
'furnished to do so, subject to the following conditions:
'
'The above copyright notice and this permission notice shall be included in
'all copies or substantial portions of the Software.
'
'THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
'IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
'FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
'AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
'LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
'OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
'THE SOFTWARE.
'
'@section DESCRIPTION
'
'An Interface for the Spring Class.
'
'

Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Public Class Spring
	Public Sub New(iPoint1 As Point, iPoint2 As Point, iLength As Single, iK As Single)
		point1 = iPoint1
		point2 = iPoint2
		Length = iLength
		K = iK
	End Sub

	Public Property point1() As Point
		Get
			Return m_point1
		End Get
		Private Set
			m_point1 = Value
		End Set
	End Property
	Private m_point1 As Point
	Public Property point2() As Point
		Get
			Return m_point2
		End Get
		Private Set
			m_point2 = Value
		End Set
	End Property
	Private m_point2 As Point

	Public Property Length() As Single
		Get
			Return m_Length
		End Get
		Private Set
			m_Length = Value
		End Set
	End Property
	Private m_Length As Single

	Public Property K() As Single
		Get
			Return m_K
		End Get
		Private Set
			m_K = Value
		End Set
	End Property
	Private m_K As Single
End Class