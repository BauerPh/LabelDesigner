Option Strict On
Imports System.ComponentModel
Imports System.Drawing.Drawing2D
<Serializable()>
Public Class Datamatrix
    Inherits Geometric

    Private _widthMultiplier As Int32 = 20
    Private _heightMultiplier As Int32 = 20
    Private _dataLen As Int32
    Private _codeSize As Int32 = 18 'rows / columns
    Private _data As String = "data"

    <Category("Größe")>
    Public Property Breitenfaktor As Int32
        Get
            Return _widthMultiplier
        End Get
        Set
            checkValue(Value, 1, 61, _widthMultiplier)
        End Set
    End Property

    <Category("Größe")>
    Public Property Höhenfaktor As Int32
        Get
            Return _heightMultiplier
        End Get
        Set
            checkValue(Value, 1, 61, _heightMultiplier)
        End Set
    End Property

    <Category("Datamatrixcode")>
    Public Property Größe As Int32
        Get
            Return _codeSize
        End Get
        Set
            If Value Mod 2 <> 0 Or Value < 0 Or Value > 144 Then
                MessageBox.Show("Nur gerade Zahlen zwischen 2 und 144 oder 0 erlaubt!", "Wertebereich", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                _codeSize = Value
            End If
        End Set
    End Property

    <Category("Datamatrixcode")>
    Public Property Datenstring As String
        Get
            Return _data
        End Get
        Set
            _data = Value
            _dataLen = _data.Length + 10
        End Set
    End Property

    Public Sub draw(ByRef g As Graphics, origin As Point)
        If Not IO.File.Exists(ResourceFilePathPrefix & "datamatrix.gif") Then
            MsgBox("Die Datei wurde nicht gefunden!")
            Exit Sub
        End If

        Dim pos As New Size(mmToPx(_point.X), mmToPx(_point.Y) * -1)
        Dim newOrigin As New Point
        newOrigin = origin + pos

        Dim image As Image = Image.FromFile(ResourceFilePathPrefix & "datamatrix.gif")
        Dim imgSize As New Size(CInt(Math.Round(_widthMultiplier * _codeSize * 0.47)), CInt(Math.Round(_heightMultiplier * _codeSize * 0.47)))

        g.DrawImage(image, newOrigin.X, newOrigin.Y - imgSize.Height, imgSize.Width, imgSize.Height)

        If _highlight Then
            g.DrawRectangle(New Pen(Color.GreenYellow, 5.0), newOrigin.X, newOrigin.Y - imgSize.Height, imgSize.Width, imgSize.Height)
        End If
    End Sub

    Public Function generateDPLCode() As String
        Return $"1W1C{NumToMultiplier(_widthMultiplier)}{NumToMultiplier(_heightMultiplier)}000{_point.Y * 10:0000}{_point.X * 10:0000}{_dataLen:0000}2000{_codeSize:000}{_codeSize:000}{_data}" & CRString
    End Function
End Class
