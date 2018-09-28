Option Strict On
Imports System.Timers

Public Class frmMain
    Private updPictureBoxOnly As Boolean = False
    Private statusLabelTimeout As New Timer(2000)

    Private Sub toolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles toolStrip1.ItemClicked
        Select Case e.ClickedItem.Name
            Case tsbtnAddLine.Name
                vars.label.add(New Line())
                updateAddStatus()
                Exit Sub
            Case tsbtnAddBox.Name
                vars.label.add(New Box())
                updateAddStatus()
                Exit Sub
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
        vars.label.move(lbObjects.SelectedIndex)
    End Sub

    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        Clipboard.SetText(DelCrLf(rtbDPLCode.Text))
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        print()
    End Sub

    Private Sub pgProperties_PropertyValueChanged(s As Object, e As PropertyValueChangedEventArgs) Handles pgProperties.PropertyValueChanged
        pbLabel.Invalidate()
    End Sub

    Private Sub lbObjects_Click(sender As Object, e As EventArgs) Handles lbObjects.Click
        vars.label.highlight(lbObjects.SelectedIndex)
        pbLabel.Invalidate()
    End Sub

    Private Sub pbLabel_Paint(sender As Object, e As PaintEventArgs) Handles pbLabel.Paint
        vars.label.update(e.Graphics, rtbDPLCode, lbObjects, pgProperties, updPictureBoxOnly)
        updPictureBoxOnly = False
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        updateTitle()

        vars.label = New Label(StandardLabelSize, StandardLabelSize)
        If Debugger.IsAttached() Then
            ResourceFilePathPrefix = System.IO.Path.GetFullPath(Application.StartupPath & "\..\..\Resources\")
        Else
            ResourceFilePathPrefix = Application.StartupPath & "\Resources\"
        End If
        tslbRaster.SelectedIndex = 3

        AddHandler statusLabelTimeout.Elapsed, AddressOf statusLabelTimeout_Elapsed
    End Sub

    ' Menu Strip
    ' Datei
    Private Sub msSaveAs_Click(sender As Object, e As EventArgs) Handles msSaveAs.Click
        If saveFile() Then
            msSave.Enabled = True
            showStatus("gespeichert...", 2)
        Else
            MessageBox.Show("Datei konnte nicht gespeichert werden.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub msSave_Click(sender As Object, e As EventArgs) Handles msSave.Click
        If saveFile(actFilename) Then
            showStatus("gespeichert...", 2)
        Else
            MessageBox.Show("Datei konnte nicht gespeichert werden.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub msOpen_Click(sender As Object, e As EventArgs) Handles msOpen.Click
        If loadFile() Then
            msSave.Enabled = True
            pbLabel.Invalidate()
            showStatus("geladen...", 2)
        Else
            MessageBox.Show("Datei konnte nicht geladen werden.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        If vars.label.mouseMove(pbLabel, e.X, e.Y, CSng(tslbRaster.Text)) Then
            pbLabel.Invalidate()
            updPictureBoxOnly = True
        End If
    End Sub

    Private Sub pbLabel_MouseClick(sender As Object, e As MouseEventArgs) Handles pbLabel.MouseClick
        If vars.label.mouseClick Then
            pbLabel.Invalidate()
            updPictureBoxOnly = False
        End If
        updateAddStatus()
    End Sub

    'ESC Taste => Abbrechen
    Private Sub frmMain_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If vars.label.cancelAdd() Then pbLabel.Invalidate()
            updateAddStatus()
        End If
    End Sub


    'Funktionen
    Public Sub updateAddStatus()
        Select Case vars.label.addStatus
            Case 1
                toolStrip1.Enabled = False
                btnDelete.Enabled = False
                btnMove.Enabled = False
                lbObjects.Enabled = False
                showStatus("Ursprung setzen. (ESC = abbrechen)")
            Case 2
                toolStrip1.Enabled = False
                btnDelete.Enabled = False
                btnMove.Enabled = False
                lbObjects.Enabled = False
                showStatus("Größe festlegen. (ESC = abbrechen)")
            Case 3
                toolStrip1.Enabled = False
                btnDelete.Enabled = False
                btnMove.Enabled = False
                lbObjects.Enabled = False
                showStatus("Bitte Objekt platzieren. (ESC = abbrechen)")
            Case Else
                toolStrip1.Enabled = True
                btnDelete.Enabled = True
                btnMove.Enabled = True
                lbObjects.Enabled = True
                showStatus("")
        End Select
    End Sub
    Private Sub statusLabelTimeout_Elapsed(sender As Object, e As EventArgs)
        statusLabelTimeout.Stop()
        lblStatus.Text = ""
    End Sub

    Private Sub showStatus(s As String, Optional timeout_s As Int32 = 0)
        If timeout_s > 0 Then
            statusLabelTimeout.Stop()
            statusLabelTimeout.Interval = timeout_s * 1000
            statusLabelTimeout.Start()
        End If
        lblStatus.Text = s
    End Sub
End Class
