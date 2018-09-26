<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.rtbDPLCode = New System.Windows.Forms.RichTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbObjects = New System.Windows.Forms.ListBox()
        Me.pgProperties = New System.Windows.Forms.PropertyGrid()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnCopy = New System.Windows.Forms.Button()
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.DateiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EinstellungenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnMove = New System.Windows.Forms.Button()
        Me.tslbRaster = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.tsbtnAddLine = New System.Windows.Forms.ToolStripButton()
        Me.tsbtnAddBox = New System.Windows.Forms.ToolStripButton()
        Me.tsbtnAddText = New System.Windows.Forms.ToolStripButton()
        Me.tsbtnAddDatamatrixcode = New System.Windows.Forms.ToolStripButton()
        Me.tsbtnAddBarcode = New System.Windows.Forms.ToolStripButton()
        Me.tsbtnAddLogo = New System.Windows.Forms.ToolStripButton()
        Me.pbLabel = New System.Windows.Forms.PictureBox()
        Me.msOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.msSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.msSaveAs = New System.Windows.Forms.ToolStripMenuItem()
        Me.msClose = New System.Windows.Forms.ToolStripMenuItem()
        Me.msTCPSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1.SuspendLayout()
        Me.menuStrip1.SuspendLayout()
        Me.toolStrip1.SuspendLayout()
        CType(Me.pbLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rtbDPLCode
        '
        Me.rtbDPLCode.Location = New System.Drawing.Point(620, 69)
        Me.rtbDPLCode.Name = "rtbDPLCode"
        Me.rtbDPLCode.Size = New System.Drawing.Size(438, 185)
        Me.rtbDPLCode.TabIndex = 1
        Me.rtbDPLCode.Text = ""
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.pbLabel)
        Me.Panel1.Location = New System.Drawing.Point(6, 52)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(608, 608)
        Me.Panel1.TabIndex = 3
        '
        'lbObjects
        '
        Me.lbObjects.FormattingEnabled = True
        Me.lbObjects.Location = New System.Drawing.Point(621, 315)
        Me.lbObjects.Name = "lbObjects"
        Me.lbObjects.Size = New System.Drawing.Size(207, 316)
        Me.lbObjects.TabIndex = 6
        '
        'pgProperties
        '
        Me.pgProperties.HelpVisible = False
        Me.pgProperties.Location = New System.Drawing.Point(835, 289)
        Me.pgProperties.Name = "pgProperties"
        Me.pgProperties.Size = New System.Drawing.Size(224, 342)
        Me.pgProperties.TabIndex = 7
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(621, 637)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 13
        Me.btnDelete.Text = "Löschen"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnCopy
        '
        Me.btnCopy.Location = New System.Drawing.Point(979, 260)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(75, 23)
        Me.btnCopy.TabIndex = 19
        Me.btnCopy.Text = "Copy"
        Me.btnCopy.UseVisualStyleBackColor = True
        '
        'menuStrip1
        '
        Me.menuStrip1.BackColor = System.Drawing.Color.White
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DateiToolStripMenuItem, Me.EinstellungenToolStripMenuItem})
        Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.Size = New System.Drawing.Size(1068, 24)
        Me.menuStrip1.TabIndex = 26
        Me.menuStrip1.Text = "msMenu"
        '
        'DateiToolStripMenuItem
        '
        Me.DateiToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msOpen, Me.msSave, Me.msSaveAs, Me.msClose})
        Me.DateiToolStripMenuItem.Name = "DateiToolStripMenuItem"
        Me.DateiToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.DateiToolStripMenuItem.Text = "Datei"
        '
        'EinstellungenToolStripMenuItem
        '
        Me.EinstellungenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msTCPSettings})
        Me.EinstellungenToolStripMenuItem.Name = "EinstellungenToolStripMenuItem"
        Me.EinstellungenToolStripMenuItem.Size = New System.Drawing.Size(90, 20)
        Me.EinstellungenToolStripMenuItem.Text = "Einstellungen"
        '
        'toolStrip1
        '
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtnAddLine, Me.tsbtnAddBox, Me.ToolStripSeparator1, Me.tsbtnAddText, Me.ToolStripSeparator2, Me.tsbtnAddDatamatrixcode, Me.tsbtnAddBarcode, Me.ToolStripSeparator3, Me.tsbtnAddLogo, Me.ToolStripSeparator4, Me.ToolStripLabel1, Me.tslbRaster})
        Me.toolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.toolStrip1.Size = New System.Drawing.Size(1068, 25)
        Me.toolStrip1.TabIndex = 27
        Me.toolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(615, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "DPL-Code:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(620, 299)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Objekte:"
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(898, 260)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 31
        Me.btnPrint.Text = "Drucken"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnMove
        '
        Me.btnMove.Location = New System.Drawing.Point(702, 637)
        Me.btnMove.Name = "btnMove"
        Me.btnMove.Size = New System.Drawing.Size(75, 23)
        Me.btnMove.TabIndex = 32
        Me.btnMove.Text = "Verschieben"
        Me.btnMove.UseVisualStyleBackColor = True
        '
        'tslbRaster
        '
        Me.tslbRaster.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tslbRaster.DropDownWidth = 10
        Me.tslbRaster.Items.AddRange(New Object() {"0,1", "0,25", "0,5", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.tslbRaster.Name = "tslbRaster"
        Me.tslbRaster.Size = New System.Drawing.Size(75, 25)
        Me.tslbRaster.ToolTipText = "Raster einstellen..."
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(42, 22)
        Me.ToolStripLabel1.Text = "Raster:"
        '
        'tsbtnAddLine
        '
        Me.tsbtnAddLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbtnAddLine.Image = Global.LabelDesigner.My.Resources.Resources.icons8_linie
        Me.tsbtnAddLine.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnAddLine.Name = "tsbtnAddLine"
        Me.tsbtnAddLine.Size = New System.Drawing.Size(23, 22)
        Me.tsbtnAddLine.Text = "Linie hinzufügen"
        Me.tsbtnAddLine.ToolTipText = "Linie hinzufügen"
        '
        'tsbtnAddBox
        '
        Me.tsbtnAddBox.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbtnAddBox.Image = Global.LabelDesigner.My.Resources.Resources.icons8_gestrichenes_rechteck
        Me.tsbtnAddBox.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnAddBox.Name = "tsbtnAddBox"
        Me.tsbtnAddBox.Size = New System.Drawing.Size(23, 22)
        Me.tsbtnAddBox.Text = "Box hinzufügen"
        Me.tsbtnAddBox.ToolTipText = "Box hinzufügen"
        '
        'tsbtnAddText
        '
        Me.tsbtnAddText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbtnAddText.Image = Global.LabelDesigner.My.Resources.Resources.icons8_generischer_text
        Me.tsbtnAddText.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnAddText.Name = "tsbtnAddText"
        Me.tsbtnAddText.Size = New System.Drawing.Size(23, 22)
        Me.tsbtnAddText.Text = "Text hinzufügen"
        Me.tsbtnAddText.ToolTipText = "Text hinzufügen"
        '
        'tsbtnAddDatamatrixcode
        '
        Me.tsbtnAddDatamatrixcode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbtnAddDatamatrixcode.Image = Global.LabelDesigner.My.Resources.Resources.icons8_qr_code
        Me.tsbtnAddDatamatrixcode.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnAddDatamatrixcode.Name = "tsbtnAddDatamatrixcode"
        Me.tsbtnAddDatamatrixcode.Size = New System.Drawing.Size(23, 22)
        Me.tsbtnAddDatamatrixcode.Text = "Datamatrixcode hinzufügen"
        Me.tsbtnAddDatamatrixcode.ToolTipText = "Datamatrixcode hinzufügen"
        '
        'tsbtnAddBarcode
        '
        Me.tsbtnAddBarcode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbtnAddBarcode.Image = Global.LabelDesigner.My.Resources.Resources.icons8_strichcode
        Me.tsbtnAddBarcode.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnAddBarcode.Name = "tsbtnAddBarcode"
        Me.tsbtnAddBarcode.Size = New System.Drawing.Size(23, 22)
        Me.tsbtnAddBarcode.Text = "Strichcode hinzufügen"
        Me.tsbtnAddBarcode.ToolTipText = "Strichcode hinzufügen"
        '
        'tsbtnAddLogo
        '
        Me.tsbtnAddLogo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbtnAddLogo.Image = Global.LabelDesigner.My.Resources.Resources.icons8_007_logo
        Me.tsbtnAddLogo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnAddLogo.Name = "tsbtnAddLogo"
        Me.tsbtnAddLogo.Size = New System.Drawing.Size(23, 22)
        Me.tsbtnAddLogo.Text = "Logo hinzufügen"
        Me.tsbtnAddLogo.ToolTipText = "Logo hinzufügen"
        '
        'pbLabel
        '
        Me.pbLabel.Location = New System.Drawing.Point(3, 3)
        Me.pbLabel.Name = "pbLabel"
        Me.pbLabel.Size = New System.Drawing.Size(600, 600)
        Me.pbLabel.TabIndex = 0
        Me.pbLabel.TabStop = False
        '
        'msOpen
        '
        Me.msOpen.Image = Global.LabelDesigner.My.Resources.Resources.icons8_datei_ansehen
        Me.msOpen.Name = "msOpen"
        Me.msOpen.Size = New System.Drawing.Size(166, 22)
        Me.msOpen.Text = "Öffnen..."
        '
        'msSave
        '
        Me.msSave.Enabled = False
        Me.msSave.Image = Global.LabelDesigner.My.Resources.Resources.icons8_speichern
        Me.msSave.Name = "msSave"
        Me.msSave.Size = New System.Drawing.Size(166, 22)
        Me.msSave.Text = "Speichern"
        '
        'msSaveAs
        '
        Me.msSaveAs.Image = Global.LabelDesigner.My.Resources.Resources.icons8_speichern_als
        Me.msSaveAs.Name = "msSaveAs"
        Me.msSaveAs.Size = New System.Drawing.Size(166, 22)
        Me.msSaveAs.Text = "Speichern unter..."
        '
        'msClose
        '
        Me.msClose.Image = Global.LabelDesigner.My.Resources.Resources.icons8_fenster_schließen_32
        Me.msClose.Name = "msClose"
        Me.msClose.Size = New System.Drawing.Size(166, 22)
        Me.msClose.Text = "Beenden"
        '
        'msTCPSettings
        '
        Me.msTCPSettings.Image = Global.LabelDesigner.My.Resources.Resources.icons8_wired_netzwerkverbindung_32
        Me.msTCPSettings.Name = "msTCPSettings"
        Me.msTCPSettings.Size = New System.Drawing.Size(178, 22)
        Me.msTCPSettings.Text = "TCP Einstellungen..."
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1068, 666)
        Me.Controls.Add(Me.btnMove)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.toolStrip1)
        Me.Controls.Add(Me.btnCopy)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.pgProperties)
        Me.Controls.Add(Me.lbObjects)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.rtbDPLCode)
        Me.Controls.Add(Me.menuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Label Designer v1.2"
        Me.Panel1.ResumeLayout(False)
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        CType(Me.pbLabel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pbLabel As PictureBox
    Friend WithEvents rtbDPLCode As RichTextBox
    Private WithEvents Panel1 As Panel
    Friend WithEvents lbObjects As ListBox
    Friend WithEvents pgProperties As PropertyGrid
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnCopy As Button
    Friend WithEvents menuStrip1 As MenuStrip
    Friend WithEvents DateiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents msOpen As ToolStripMenuItem
    Friend WithEvents msSave As ToolStripMenuItem
    Friend WithEvents msSaveAs As ToolStripMenuItem
    Friend WithEvents toolStrip1 As ToolStrip
    Friend WithEvents tsbtnAddLine As ToolStripButton
    Friend WithEvents tsbtnAddBox As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tsbtnAddText As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents tsbtnAddDatamatrixcode As ToolStripButton
    Friend WithEvents tsbtnAddBarcode As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents tsbtnAddLogo As ToolStripButton
    Friend WithEvents msClose As ToolStripMenuItem
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents EinstellungenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents msTCPSettings As ToolStripMenuItem
    Friend WithEvents btnPrint As Button
    Friend WithEvents btnMove As Button
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents tslbRaster As ToolStripComboBox
End Class
