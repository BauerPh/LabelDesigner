Option Strict On
Public Class frmMain
    Private updListBox As Boolean = True
    Private updPictureBoxOnly As Boolean = False
    Public mouseObj As Object

    Private Sub toolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles toolStrip1.ItemClicked
        Select Case e.ClickedItem.Name
            Case tsbtnAddLine.Name
                frmAdd.pgAdd.SelectedObject = New Line()
                frmAdd.Text = "Linie hinzufügen"
            Case tsbtnAddBox.Name
                frmAdd.pgAdd.SelectedObject = New Box()
                frmAdd.Text = "Box hinzufügen"
            Case tsbtnAddText.Name
                frmAdd.pgAdd.SelectedObject = New Text()
                frmAdd.Text = "Text hinzufügen"
            Case tsbtnAddDatamatrixcode.Name
                frmAdd.pgAdd.SelectedObject = New Datamatrix()
                frmAdd.Text = "Datamatrixbarcode hinzufügen"
            Case tsbtnAddBarcode.Name
                frmAdd.pgAdd.SelectedObject = New Barcode()
                frmAdd.Text = "Strichcode hinzufügen"
            Case tsbtnAddLogo.Name
                frmAdd.pgAdd.SelectedObject = New Logo()
                frmAdd.Text = "Logo hinzufügen"
            Case Else
                Exit Sub
        End Select
        frmAdd.ShowDialog(Me)
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        vars.label.delete(lbObjects.SelectedIndex)
        pbLabel.Invalidate()
    End Sub
    Private Sub btnMove_Click(sender As Object, e As EventArgs) Handles btnMove.Click
        mouseObj = vars.label.getObject(lbObjects.SelectedIndex)
    End Sub
    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        Clipboard.SetText(DelCrLf(rtbDPLCode.Text))
    End Sub
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        print()
    End Sub

    Private Sub pgProperties_PropertyValueChanged(s As Object, e As PropertyValueChangedEventArgs) Handles pgProperties.PropertyValueChanged
        pbLabel.Invalidate()
        updListBox = False
    End Sub
    Private Sub lbObjects_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbObjects.SelectedIndexChanged
        vars.label.highlight(lbObjects.SelectedIndex)
        pbLabel.Invalidate()
        updListBox = False
    End Sub
    Private Sub pbLabel_Paint(sender As Object, e As PaintEventArgs) Handles pbLabel.Paint
        vars.label.update(e.Graphics, rtbDPLCode, lbObjects, pgProperties, updListBox, updPictureBoxOnly)
        updListBox = True
        updPictureBoxOnly = False
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        vars.label = New Label(StandardLabelSize, StandardLabelSize)
        If Debugger.IsAttached() Then
            ResourceFilePathPrefix = System.IO.Path.GetFullPath(Application.StartupPath & "\..\..\Resources\")
        Else
            ResourceFilePathPrefix = Application.StartupPath & "\Resources\"
        End If
    End Sub

    ' Menu Strip
    ' Datei
    Private Sub msSaveAs_Click(sender As Object, e As EventArgs) Handles msSaveAs.Click
        If saveFile() Then
            msSave.Enabled = True
        End If
    End Sub

    Private Sub msSave_Click(sender As Object, e As EventArgs) Handles msSave.Click
        saveFile(actFilename)
    End Sub

    Private Sub msOpen_Click(sender As Object, e As EventArgs) Handles msOpen.Click
        If loadFile() Then
            msSave.Enabled = True
            pbLabel.Invalidate()
        End If
    End Sub

    Private Sub msClose_Click(sender As Object, e As EventArgs) Handles msClose.Click
        Application.Exit()
    End Sub
    ' Einstellungen
    Private Sub msTCPSettings_Click(sender As Object, e As EventArgs) Handles msTCPSettings.Click
        frmTCPSettings.ShowDialog()
    End Sub

    'Objekte positionieren / verschieben
    Private Sub pbLabel_MouseMove(sender As Object, e As MouseEventArgs) Handles pbLabel.MouseMove
        If mouseObj IsNot Nothing Then
            vars.label.move(mouseObj, pbLabel, e.X, e.Y)
            pbLabel.Invalidate()
            updPictureBoxOnly = True
        End If
    End Sub

    Private Sub pbLabel_MouseClick(sender As Object, e As MouseEventArgs) Handles pbLabel.MouseClick
        mouseObj = Nothing
        pbLabel.Invalidate()
        updPictureBoxOnly = False
    End Sub
End Class
