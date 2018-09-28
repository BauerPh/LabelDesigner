Option Strict On
Imports System.ComponentModel

Public Class frmAdd
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        vars.label.add(CType(pgAdd.SelectedObject, ILabelObject))
        frmMain.updateAddStatus()
        Hide()
    End Sub

    Private Sub frmAdd_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        pgAdd.SelectedObject = Nothing
    End Sub
End Class