Option Strict On
Imports System.ComponentModel
Imports System.Drawing.Drawing2D
<Serializable()>
Public Class Box
    Inherits Geometric

    Private _size As New SizeF(10.0, 10.0)
    Private _thicknessTopBottom As Single = 0.5
    Private _thicknessSide As Single = 0.5

    <Category("Größe")>
    Public Property Breite As Single
        Get
            Return _size.Width
        End Get
        Set
            checkValue(Value, 0.1, 999.9, _size.Width)
        End Set
    End Property

    <Category("Größe")>
    Public Property Höhe As Single
        Get
            Return _size.Height
        End Get
        Set
            checkValue(Value, 0.1, 999.9, _size.Height)
        End Set
    End Property

    <Category("Linie")>
    Public Property LinienstärkeObenUnten As Single
        Get
            Return _thicknessTopBottom
        End Get
        Set
            checkValue(Value, 0.1, 300.0, _thicknessTopBottom)
        End Set
    End Property

    <Category("Linie")>
    Public Property LinienstärkeRechtsLinks As Single
        Get
            Return _thicknessSide
        End Get
        Set
            checkValue(Value, 0.1, 300.0, _thicknessSide)
        End Set
    End Property

    Public Sub draw(ByRef g As Graphics, origin As Point)
        Dim pos As New Size(mmToPx(_point.X), mmToPx(_point.Y) * -1)
        Dim size As New Size(mmToPx(_size.Width), mmToPx(_size.Height))
        Dim newOrigin As New Point
        newOrigin = origin + pos

        Dim penColor As Color
        If _highlight Then
            penColor = Color.GreenYellow
        Else
            penColor = Color.Black
        End If
        Dim pen1 As New Pen(penColor, mmToPx(_thicknessTopBottom))
        Dim pen2 As New Pen(penColor, mmToPx(_thicknessSide))
        'unten
        g.DrawLine(pen1, newOrigin.X, newOrigin.Y, newOrigin.X + size.Width, newOrigin.Y)
        'oben
        g.DrawLine(pen1, newOrigin.X, newOrigin.Y - size.Height, newOrigin.X + size.Width, newOrigin.Y - size.Height)
        'links
        g.DrawLine(pen2, newOrigin.X, newOrigin.Y, newOrigin.X, newOrigin.Y - size.Height)
        'rechts
        g.DrawLine(pen2, newOrigin.X + size.Width, newOrigin.Y, newOrigin.X + size.Width, newOrigin.Y - size.Height)
    End Sub

    Public Function generateDPLCode() As String
        Dim retval As String = $"1X11000{_point.Y * 10:0000}{_point.X * 10:0000}"

        Dim w As Int32 = CInt(_size.Width * 10)
        Dim h As Int32 = CInt(_size.Height * 10)
        Dim thTB As Int32 = CInt(_thicknessTopBottom * 10)
        Dim thS As Int32 = CInt(_thicknessSide * 10)
        If w > 999 Or h > 999 Or thTB > 999 Or thS > 999 Then
            Return retval & $"b{w:0000}{h:0000}{thTB:0000}{thS:0000}" & CRString
        Else
            Return retval & $"B{w:000}{h:000}{thTB:000}{thS:000}" & CRString
        End If
    End Function
End Class
