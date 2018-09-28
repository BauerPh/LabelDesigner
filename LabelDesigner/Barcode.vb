Option Strict On
Imports System.ComponentModel
Imports System.Drawing.Drawing2D
<Serializable()>
Public Class Barcode : Inherits LabelObject
    Public Enum enumTyp
        UPC_A = 0
        UPC_E = 2
        Code_128 = 4
        EAN_13 = 6
        EAN_8 = 8
        Code_93 = 10
    End Enum
    Public Enum enumTyp2
        drucken = 0
        nicht_drucken = 1
    End Enum
    Private _typString() As String = {"B", "b", "C", "c", "E", "e", "F", "f", "G", "g", "O", "o"}
    Private _typExampString() As String = {"12345678901", "123456", "BBuchstaben123", "123456789012", "1234567", "Buchstaben123"}

    Private _typ As enumTyp = enumTyp.UPC_A
    Private _secTyp As enumTyp2 = enumTyp2.drucken
    Private _narrowBarWidth As Int32 = 5
    Private _symbolHeight As Int32 = 5
    Private _data As String = _typExampString(0)
    Private _image As Image

    <Category("Barcode")>
    Public Property Typ As enumTyp
        Get
            Return _typ
        End Get
        Set
            _typ = Value
            _data = _typExampString(_typ \ 2)
        End Set
    End Property
    <Category("Barcode")>
    Public Property Text As enumTyp2
        Get
            Return _secTyp
        End Get
        Set
            _secTyp = Value
        End Set
    End Property
    <Category("Barcode")>
    Public Property Balkenbreite As Int32
        Get
            Return _narrowBarWidth
        End Get
        Set
            checkValue(Value, 0, 61, _narrowBarWidth)
        End Set
    End Property

    <Category("Barcode")>
    Public Property Barcodehöhe As Int32
        Get
            Return _symbolHeight
        End Get
        Set
            checkValue(Value, 0, 999, _symbolHeight)
        End Set
    End Property
    <Category("Barcode")>
    Public Property Datenstring As String
        Get
            Return _data
        End Get
        Set
            _data = Value
        End Set
    End Property
    Public Sub New()
        If Not IO.File.Exists(ResourceFilePathPrefix & "barcode.png") Then
            MessageBox.Show("Die Datei ""barcode.png"" wurde nicht gefunden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        _image = Image.FromFile(ResourceFilePathPrefix & "barcode.png")
        _name = "Barcode"
    End Sub

    Public Overrides Sub draw(ByRef g As Graphics, origin As Point)
        If _image IsNot Nothing Then
            Dim pos As New Size(mmToPx(_point.X), mmToPx(_point.Y) * -1)
            Dim newOrigin As New Point
            newOrigin = origin + pos

            Dim imgSize As New Size(48 * _narrowBarWidth, 10 * _symbolHeight)

            g.DrawImage(_image, newOrigin.X, newOrigin.Y - imgSize.Height, imgSize.Width, imgSize.Height)

            If _highlight Then
                g.DrawRectangle(New Pen(Color.GreenYellow, 5.0), newOrigin.X, newOrigin.Y - imgSize.Height, imgSize.Width, imgSize.Height)
            End If
        End If
    End Sub

    Public Overrides Function generateDPLCode() As String
        '1      F       0       0       000     0015    0100    012345678901
        'rot    Typ     wide    narrow  height  row     column  data

        'Types: (small letter => without human readable text)
        'B = UPC-A (0-9) / 12 digits (11 for checksum auto calc)
        'C = UPC-E (0-9) / 7 digits (6 for checksum auto calc)
        'E = Code 128 (128 ASCII character set) / var length
        'F = EAN-13 (0-9) / 13 digits (12 for checksum auto calc)
        'G = EAN-8 (0-9) / 8 digits (7 digits)
        'O = Code 93 (0-9, A-Z, -.$/+%) / var length
        Return $"1{_typString(_typ + _secTyp)}{NumToMultiplier(_narrowBarWidth)}{NumToMultiplier(_narrowBarWidth)}{_symbolHeight:000}{_point.Y * 10:0000}{_point.X * 10:0000}{_data}" & CRString
    End Function
End Class
