<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTCPSettings
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTCPSettings))
        Me.tbTCPIP = New System.Windows.Forms.TextBox()
        Me.numTCPPort = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnTestConnection = New System.Windows.Forms.Button()
        CType(Me.numTCPPort, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbTCPIP
        '
        Me.tbTCPIP.Location = New System.Drawing.Point(68, 11)
        Me.tbTCPIP.MaxLength = 15
        Me.tbTCPIP.Name = "tbTCPIP"
        Me.tbTCPIP.Size = New System.Drawing.Size(102, 20)
        Me.tbTCPIP.TabIndex = 0
        Me.tbTCPIP.Text = "192.168.0.253"
        '
        'numTCPPort
        '
        Me.numTCPPort.Location = New System.Drawing.Point(192, 12)
        Me.numTCPPort.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.numTCPPort.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numTCPPort.Name = "numTCPPort"
        Me.numTCPPort.Size = New System.Drawing.Size(84, 20)
        Me.numTCPPort.TabIndex = 1
        Me.numTCPPort.Value = New Decimal(New Integer() {9100, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(176, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = ":"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "IP/Port:"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(102, 38)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(84, 23)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "Speichern"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(192, 38)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(84, 23)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Abbrechen"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnTestConnection
        '
        Me.btnTestConnection.Location = New System.Drawing.Point(12, 38)
        Me.btnTestConnection.Name = "btnTestConnection"
        Me.btnTestConnection.Size = New System.Drawing.Size(84, 23)
        Me.btnTestConnection.TabIndex = 6
        Me.btnTestConnection.Text = "Verb. testen"
        Me.btnTestConnection.UseVisualStyleBackColor = True
        '
        'frmTCPSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(314, 69)
        Me.Controls.Add(Me.btnTestConnection)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.numTCPPort)
        Me.Controls.Add(Me.tbTCPIP)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTCPSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "TCP Einstellungen"
        CType(Me.numTCPPort, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tbTCPIP As TextBox
    Friend WithEvents numTCPPort As NumericUpDown
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnTestConnection As Button
End Class
