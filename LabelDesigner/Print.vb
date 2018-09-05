Option Strict On
Module Printer
    Private TCPCon As New TCPConnection
    Public Sub print()
        TCPCon.connect(My.Settings.TCP_Ip, CShort(My.Settings.TCP_Port))
        TCPCon.setConnectedCallback(AddressOf print_callback)
    End Sub
    Private Sub print_callback()
        If Not TCPCon.send(DelCrLf(frmMain.rtbDPLCode.Text).Replace(CRString, Chr(13)).Replace(STXString, Chr(2))) Then
            MessageBox.Show("Drucken fehlgeschlagen...", "Drucker", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        TCPCon.disconnect()
    End Sub

    Private Sub rcv_callback(text As String)
        MsgBox(text)
    End Sub
End Module
