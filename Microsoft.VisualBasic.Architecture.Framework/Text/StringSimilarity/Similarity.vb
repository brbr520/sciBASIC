﻿#Region "Microsoft.VisualBasic::23d1bdb2dbdeb520c5df853d573c2b72, ..\visualbasic_App\Microsoft.VisualBasic.Architecture.Framework\Text\StringSimilarity\Abstract.vb"

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

Imports System.Runtime.CompilerServices

Namespace Text.Similarity

    ''' <summary>
    ''' Summary description for StringMatcher.
    ''' </summary>
    ''' 
    Public Delegate Function ISimilarity(s1 As String, s2 As String) As Double

    Public Module Evaluations

        ''' <summary>
        ''' 两个字符串之间是通过单词的排布的相似度来比较相似度的
        ''' </summary>
        ''' <param name="s1"></param>
        ''' <param name="s2"></param>
        ''' <param name="ignoreCase"></param>
        ''' <param name="cost#"></param>
        ''' <param name="dist"></param>
        ''' <returns></returns>
        Public Function Evaluate(s1 As String,
                                 s2 As String,
                                 Optional ignoreCase As Boolean = True,
                                 Optional cost# = 0.7,
                                 Optional ByRef dist As DistResult = Nothing) As Double

            If String.Equals(s1, s2, If(ignoreCase, StringComparison.OrdinalIgnoreCase, StringComparison.Ordinal)) Then
                Return 1
            End If

            Dim tokenEquals As Equals(Of String) =
                [If](Of Equals(Of String))(
                ignoreCase,
                AddressOf tokenEqualsIgnoreCase,
                AddressOf Evaluations.tokenEquals)

            dist = LevenshteinDistance.ComputeDistance(
                s1.Split,
                s2.Split,
                tokenEquals,
                Function(s) s.FirstOrDefault,
                cost)

            If dist Is Nothing Then
                Return 0
            Else
                Return dist.MatchSimilarity
            End If
        End Function

        Private Function tokenEquals(w1$, w2$) As Boolean
            Return w1$ = w2$
        End Function

        Private Function tokenEqualsIgnoreCase(w1$, w2$) As Boolean
            Return String.Equals(w1, w2, StringComparison.OrdinalIgnoreCase)
        End Function

        ''' <summary>
        ''' 以s1为准则，将s2进行比较，返回s2之中的单词在s1之中的排列顺序
        ''' </summary>
        ''' <param name="s1"></param>
        ''' <param name="s2"></param>
        ''' <returns>序列之中的-1表示s2之中的单词在s1之中不存在</returns>
        Public Function TokenOrders(s1 As String, s2 As String, Optional caseSensitive As Boolean = False) As Integer()
            Dim t1$() = s1.Split
            Return t1$.TokenOrders(s2, caseSensitive)
        End Function

        <Extension>
        Public Function TokenOrders(s1$(), s2$, Optional caseSensitive As Boolean = False) As Integer()
            Dim t2$() = s2.Split
            Dim orders As New List(Of Integer)

            For Each t$ In t2.Distinct  ' 假若有重复的字符串出现，则肯定不会有顺序排布的结果，将重复的去掉
                orders += s1.Located(t$, caseSensitive)
            Next

            Return orders
        End Function

        <Extension>
        Public Function IsOrdered(s1$(), s2$, Optional caseSensitive As Boolean = False) As Boolean
            Dim orders%() = s1.TokenOrders(s2, caseSensitive)
            orders = orders.Where(Function(x) x <> -1).ToArray

            If orders.Length <= 1 Then
                Return False
            End If

            If orders.SequenceEqual(orders.OrderBy(Function(x) x)) Then
                Return True
            Else
                Return False
            End If
        End Function

        <Extension>
        Public Function IsOrdered(s1$, s2$, Optional caseSensitive As Boolean = False) As Boolean
            Return s1.Split.IsOrdered(s2$, caseSensitive)
        End Function
    End Module
End Namespace
