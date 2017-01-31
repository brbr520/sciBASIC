﻿Imports Microsoft.VisualBasic.Imaging.Drawing2D
Imports Microsoft.VisualBasic.Imaging.Drawing3D
Imports Microsoft.VisualBasic.Imaging.Drawing3D.Device
Imports Microsoft.VisualBasic.Linq

Public Class FormLandscape

    Dim canvas As GDIDevice

    Private Sub FormLandscape_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim surfaces = New Cube(10)

        canvas = New GDIDevice With {
            .bg = Color.LightBlue,
            .Model = Function() surfaces.faces,
            .Dock = DockStyle.Fill,
            .AutoRotation = True
        }
        Controls.Add(canvas)
        canvas.Run()
    End Sub

    Private Sub LoadModelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadModelToolStripMenuItem.Click
        Using file As New OpenFileDialog With {
            .Filter = "3D model(*.3mf)|*.3mf"
        }
            If file.ShowDialog = DialogResult.OK Then
                Dim project = Landscape.IO.Open(file.FileName)
                Dim surfaces = project.GetSurfaces

                canvas.Model = Function() surfaces
            End If
        End Using
    End Sub

    Private Sub AutoRotateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutoRotateToolStripMenuItem.Click
        canvas.AutoRotation = AutoRotateToolStripMenuItem.Checked
    End Sub
End Class