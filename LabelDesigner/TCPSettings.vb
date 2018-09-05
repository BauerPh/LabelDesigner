Option Strict On
Imports System.Net
Imports System.Timers
Public Class frmTCPSettings
    Private Const _cCheckConnectionTimeoutMs As Int32 = 250

    Private _TCPCon As TCPConnection
    Private _Timeout As New Timer

    Private Sub TCPSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tbTCPIP.Text = My.Settings.TCP_Ip
        numTCPPort.Value = My.Settings.TCP_Port
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If IPAddress.TryParse(tbTCPIP.Text, Nothing) Then
            My.Settings.TCP_Ip = tbTCPIP.Text
            My.Settings.TCP_Port = CInt(numTCPPort.Value)
            Close()
        Else
            MessageBox.Show("""" & tbTCPIP.Text & """ ist keine gültige Ip-Adresse!", "IP-Adresse", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub btnTestConnection_Click(sender As Object, e As EventArgs) Handles btnTestConnection.Click
        If IPAddress.TryParse(tbTCPIP.Text, Nothing) Then
            _TCPCon = New TCPConnection
            _TCPCon.connect(tbTCPIP.Text, CShort(numTCPPort.Value))
            _TCPCon.setConnectedCallback(AddressOf tcpConnectedCb)
            btnTestConnection.Enabled = False
        Else
            MessageBox.Show("""" & tbTCPIP.Text & """ ist keine gültige Ip-Adresse!", "IP-Adresse", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub tcpConnectedCb()
        _TCPCon.setLineReceivedCallback(AddressOf tcpOnReceive)
        _TCPCon.send(Chr(2) & "k" & Chr(13))
        _Timeout = New Timer(_cCheckConnectionTimeoutMs)
        AddHandler _Timeout.Elapsed, AddressOf Timout_Elapsed
        _Timeout.Start()
    End Sub

    Private Sub tcpOnReceive(text As String)
        _Timeout.Stop()
        _TCPCon.disconnect()
        If text = "Y" Then
            MessageBox.Show("Die Verbindung war erfolgreich!", "Verbindungscheck", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Die Verbindung war erfolgreich, es ist jedoch nicht der entsprechende Drucker!", "Verbindungscheck", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        btnTestConnection.Enabled = True
    End Sub

    Private Sub Timout_Elapsed(sender As Object, e As EventArgs)
        _Timeout.Stop()
        _TCPCon.disconnect()
        MessageBox.Show("Die Verbindung war erfolgreich, der Drucker antwortet jedoch nicht!", "Verbindungscheck", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        btnTestConnection.Enabled = True
    End Sub
End Class