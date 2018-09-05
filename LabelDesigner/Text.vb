Option Strict On
Imports System.ComponentModel
Imports System.Drawing.Drawing2D
<Serializable()>
Public Class Text
    Inherits Geometric

    Private _widthMultiplier As Int32 = 1
    Private _heightMultiplier As Int32 = 1
    Private _charSize As Int32 = 4
    Private _dataString As String = "text"

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

    <Category("Text")>
    Public Property Textgröße As Int32
        Get
            Return _charSize
        End Get
        Set
            checkValue(Value, 4, 999, _charSize)
        End Set
    End Property

    <Category("Text")>
    Public Property Text As String
        Get
            Return _dataString
        End Get
        Set
            If Value.Length > 255 Then
                MessageBox.Show("Es sind maximal 255 Zeichen möglich!", "Wertebereich", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                _dataString = Value
            End If
        End Set
    End Property

    Public Sub draw(ByRef g As Graphics, origin As Point)
        Dim pos As New Size(mmToPx(_point.X), mmToPx(_point.Y) * -1)
        Dim newOrigin As New Point
        newOrigin = origin + pos

        Dim font As New Font("Arial", _charSize + 9)
        Dim stringSize As SizeF = g.MeasureString(_dataString, font)
        Dim fontRect As New Rectangle(newOrigin.X, newOrigin.Y - CInt(stringSize.Height - 2), CInt(stringSize.Width), CInt(stringSize.Height - 2))

        g.DrawString(_dataString, font, New SolidBrush(Color.Black), fontRect)  '(image, newOrigin.X, newOrigin.Y - imgSize.Height, imgSize.Width, imgSize.Height)

        If _highlight Then
            g.DrawRectangle(New Pen(Color.GreenYellow, 5.0), fontRect)
        End If
    End Sub

    Public Function generateDPLCode() As String
        'FA+ 
        Return $"19{NumToMultiplier(_widthMultiplier)}{NumToMultiplier(_heightMultiplier)}S01{_point.Y * 10:0000}{_point.X * 10:0000}P{_charSize:000}P{_charSize:000}{_dataString}" & CRString
    End Function
End Class
