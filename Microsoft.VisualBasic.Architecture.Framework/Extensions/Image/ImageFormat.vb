﻿#Region "Microsoft.VisualBasic::5e0e4f0c1d92455afa6fc8c32ffb05fe, ..\sciBASIC#\Microsoft.VisualBasic.Architecture.Framework\Extensions\Image\ImageFormat.vb"

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

Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Runtime.CompilerServices

Namespace Imaging

    ''' <summary>
    ''' Specifies the file format of the image.
    ''' </summary>
    Public Enum ImageFormats As Integer

        ''' <summary>
        ''' Gets the bitmap (BMP) image format.
        ''' </summary>
        Bmp
        ''' <summary>
        ''' Gets the enhanced metafile (EMF) image format.
        ''' </summary>
        Emf
        ''' <summary>
        ''' Gets the Exchangeable Image File (Exif) format.
        ''' </summary>
        Exif
        ''' <summary>
        ''' Gets the Graphics Interchange Format (GIF) image format.
        ''' </summary>
        Gif
        ''' <summary>
        ''' Gets the Windows icon image format.
        ''' </summary>
        Icon
        ''' <summary>
        ''' Gets the Joint Photographic Experts Group (JPEG) image format.
        ''' </summary>
        Jpeg
        ''' <summary>
        ''' Gets the format of a bitmap in memory.
        ''' </summary>
        MemoryBmp
        ''' <summary>
        ''' Gets the W3C Portable Network Graphics (PNG) image format.
        ''' </summary>
        Png
        ''' <summary>
        ''' Gets the Tagged Image File Format (TIFF) image format.
        ''' </summary>
        Tiff
        ''' <summary>
        ''' Gets the Windows metafile (WMF) image format.
        ''' </summary>
        Wmf
    End Enum

    ''' <summary>
    ''' Specifies the file format of the image. Not inheritable.
    ''' </summary>
    Public Module ImageFormatExtensions

        ''' <summary>
        ''' default is <see cref="ImageFormat.Png"/>
        ''' </summary>
        ''' <param name="format">大小写不敏感</param>
        ''' <returns></returns>
        <Extension>
        Public Function GetSaveImageFormat(format As String) As ImageFormat
            Dim value As String = format.ToLower.Trim

            If ImagingFormats.ContainsKey(value) Then
                Return ImagingFormats(value)
            Else
                Return ImageFormat.Png
            End If
        End Function

        ReadOnly ImagingFormats As New Dictionary(Of String, ImageFormat) From {
            {"jpg", ImageFormat.Jpeg},
            {"bmp", ImageFormat.Bmp},
            {"emf", ImageFormat.Emf},
            {"exif", ImageFormat.Exif},
            {"gif", ImageFormat.Gif},
            {"png", ImageFormat.Png},
            {"wmf", ImageFormat.Wmf},
            {"tiff", ImageFormat.Tiff}
        }

        <Extension> Public Function GetFormat(format As ImageFormats) As ImageFormat
            Return __formats(format)
        End Function

        Dim enumFormats As Dictionary(Of String, ImageFormats) =
            [Enums](Of ImageFormats)() _
            .ToDictionary(Function(t) t.ToString.ToLower)

        ''' <summary>
        ''' 不存在的名称会返回<see cref="ImageFormats.Png"/>类型
        ''' </summary>
        ''' <param name="format$">大小写不敏感</param>
        ''' <returns></returns>
        <Extension>
        Public Function ParseImageFormat(format$) As ImageFormats
            Return enumFormats.TryGetValue(LCase(format), [default]:=ImageFormats.Png)
        End Function

        ReadOnly __formats As SortedDictionary(Of ImageFormats, ImageFormat) =
            New SortedDictionary(Of ImageFormats, ImageFormat) From {
 _
            {ImageFormats.Bmp, ImageFormat.Bmp},
            {ImageFormats.Emf, ImageFormat.Emf},
            {ImageFormats.Exif, ImageFormat.Exif},
            {ImageFormats.Gif, ImageFormat.Gif},
            {ImageFormats.Icon, ImageFormat.Icon},
            {ImageFormats.Jpeg, ImageFormat.Jpeg},
            {ImageFormats.MemoryBmp, ImageFormat.MemoryBmp},
            {ImageFormats.Png, ImageFormat.Png},
            {ImageFormats.Tiff, ImageFormat.Tiff},
            {ImageFormats.Wmf, ImageFormat.Wmf}
        }

        ''' <summary>
        ''' Saves this <see cref="System.Drawing.Image"/> to the specified file in the specified format.
        ''' (这个函数可以很容易的将图像对象保存为tiff文件)
        ''' </summary>
        ''' <param name="res">The image resource data that will be saved to the disk</param>
        ''' <param name="path">path string</param>
        ''' <param name="format">Image formats enumeration.</param>
        ''' <returns></returns>
        <Extension> Public Function SaveAs(res As Image, path$, Optional format As ImageFormats = ImageFormats.Png) As Boolean
            Try
                Call path.ParentPath.MkDIR

                If format = ImageFormats.Tiff Then
                    Return New TiffWriter(res).MultipageTiffSave(path)
                Else
                    Call res.Save(path, format.GetFormat)
                End If
            Catch ex As Exception
                ex = New Exception(path.ToFileURL, ex)
                Call App.LogException(ex)
                Call ex.PrintException
                Return False
            End Try

            Return True
        End Function
    End Module
End Namespace
