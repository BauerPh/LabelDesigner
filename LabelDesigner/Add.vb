﻿Option Strict On
Public Class frmAdd
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        vars.label.add(pgAdd.SelectedObject)
        Hide()
    End Sub
End Class