Option Strict On
Imports System.Net.Sockets
Imports System.IO
Imports System.Text
Imports System.Timers
Imports System.ComponentModel
Public Class TCPConnection
    Private Const _cConnectTimeoutMs As Int32 = 500

    Public Delegate Sub connectedCallback()
    Public Delegate Sub lineReceivedCallback(data As String)

    Private _connectedCallback As connectedCallback
    Private _lineReceivedCallback As lineReceivedCallback

    'Background Worker
    Private WithEvents _connectBGW As New BackgroundWorker With {
        .WorkerSupportsCancellation = True
    }
    Private _connectTimeout As Timer
    Private WithEvents _receiveBGW As New BackgroundWorker With {
        .WorkerSupportsCancellation = True
    }

    Private _ipAddr As String
    Private _port As Int16
    Private _stream As NetworkStream
    Private _streamw As StreamWriter
    Private _streamr As StreamReader
    Private _client As TcpClient
    'BGW
    Private Sub _connectBGW_DoWork(sender As Object, e As DoWorkEventArgs) Handles _connectBGW.DoWork
        'Client Objekt erzeugen
        If _client Is Nothing Then _client = New TcpClient

        If Not _client.Connected Then
            'connect
            _client.ConnectAsync(_ipAddr, _port)
            'start Timeout
            _connectTimeout = New Timer(_cConnectTimeoutMs)
            AddHandler _connectTimeout.Elapsed, AddressOf connectTimeout_Elapsed
            _connectTimeout.Start()
            'Wait for connection or Timeout
            While Not _client.Connected
                If _connectBGW.CancellationPending Then
                    'cancel connect
                    disconnect()
                    e.Cancel = True
                    Return
                End If
            End While
            'check connection
            If _client.Connected Then
                _stream = _client.GetStream
                _streamw = New StreamWriter(_stream, Encoding.ASCII)
                _streamr = New StreamReader(_stream, Encoding.ASCII)
                e.Result = 1 'connect okay
            Else
                e.Result = 0 'connect error
            End If
        Else
            e.Result = 2 'already connected
        End If
    End Sub

    Private Sub _connectBGW_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles _connectBGW.RunWorkerCompleted
        If e.Cancelled Then
            MessageBox.Show("TCP Verbindung fehlgeschlagen...", "TCP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Select Case CInt(e.Result)
            Case 0 'Fehler
                MessageBox.Show("TCP Fehler...", "TCP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case 1, 2 'Verbunden
                If _connectedCallback IsNot Nothing Then
                    _connectedCallback()
                End If
                If Not _receiveBGW.IsBusy Then
                    _receiveBGW.RunWorkerAsync()
                End If
            Case Else
                MessageBox.Show("Unmöglicher Fehler aufgetreten...?!", "TCP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Select
    End Sub
    Private Sub connectTimeout_Elapsed(sender As Object, e As EventArgs)
        _connectTimeout.Stop()
        _connectBGW.CancelAsync()
    End Sub

    Private Sub _receiveBGW_DoWork(sender As Object, e As DoWorkEventArgs) Handles _receiveBGW.DoWork
        Static retString As String = ""
        While True
            'prüfen ob beendet werden muss
            If _receiveBGW.CancellationPending Then
                e.Cancel = True
                Return
            End If

            Try
                'Immer nur ein Zeichen lesen (wenn vorhanden) und bei Zeilenende die Callbackmethode aufrufen
                If Not _streamr.EndOfStream Then
                    Dim rcvChar As Integer = _streamr.Read()
                    If rcvChar = 13 Then 'CR
                        _lineReceivedCallback(retString)
                        retString = ""
                    Else
                        retString += Chr(rcvChar).ToString
                    End If
                End If
            Catch ex As Exception
            End Try
        End While
    End Sub

    'Public API
    Public Sub setConnectedCallback(cb As connectedCallback)
        _connectedCallback = cb
    End Sub
    Public Sub setLineReceivedCallback(cb As lineReceivedCallback)
        _lineReceivedCallback = cb
    End Sub
    Public Function connect(ip As String, port As Int16) As Boolean
        _ipAddr = ip
        _port = port
        If Not _connectBGW.IsBusy Then
            _connectBGW.RunWorkerAsync()
            Return True
        End If
        Return False
    End Function
    Public Sub disconnect()
        _receiveBGW.CancelAsync()
        If _client IsNot Nothing Then
            _client.Close()
        End If
        _streamw = Nothing
        _streamr = Nothing
        _stream = Nothing
        _client = Nothing
    End Sub
    Public Function send(ByRef text As String) As Boolean
        If _client IsNot Nothing And _client.Connected And _streamw IsNot Nothing Then
            'send
            _streamw.Write(text)
            _streamw.Flush()
            Return True
        End If
        Return False
    End Function
End Class
