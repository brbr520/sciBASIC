﻿Namespace ComponentModel

    ''' <summary>
    ''' This is a file object which have a handle to save its data to the filesystem.(这是一个带有文件数据保存方法的文件模型)
    ''' </summary>
    ''' <remarks></remarks>
    Public Interface ISaveHandle

        ''' <summary>
        ''' Handle for saving the file data.(保存文件的方法)
        ''' </summary>
        ''' <param name="Path">The file path that will save data to.(进行文件数据保存的文件路径)</param>
        ''' <param name="encoding">The text encoding value for the text document.(文本文档的编码格式)</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function Save(Optional Path As String = "", Optional encoding As System.Text.Encoding = Nothing) As Boolean
        Function Save(Optional Path As String = "", Optional encoding As TextEncodings.Encodings = Encodings.UTF8) As Boolean
    End Interface

    Public Interface IDocumentEditor : Inherits ISaveHandle
        Property DocumentPath As String
        Function LoadDocument(Path As String) As Boolean
    End Interface
End Namespace