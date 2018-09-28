Option Strict On
Imports System.ComponentModel
Imports System.Drawing.Drawing2D

<Serializable()>
Public Class Line : Inherits LabelObject2StepPlacing
    Public Sub New()
        _name = "Linie"
    End Sub

    Public Overrides Sub draw(ByRef g As Graphics, origin As Point)
        Dim pos As New Size(mmToPx(_point.X), mmToPx(_point.Y) * -1 + 1)
        Dim size As New Size(mmToPx(_size.Width), mmToPx(_size.Height))
        Dim newOrigin As New Point
        newOrigin = origin + pos

        Dim graphicsPath As New GraphicsPath
        Dim p1 As PointF = New Point(newOrigin.X, newOrigin.Y)
        Dim p2 As PointF = New Point(newOrigin.X + size.Width, newOrigin.Y)
        Dim p3 As PointF = New Point(newOrigin.X + size.Width, newOrigin.Y - size.Height)
        Dim p4 As PointF = New Point(newOrigin.X, newOrigin.Y - size.Height)
        With graphicsPath
            'unten
            .AddLine(p1, p2)
            'rechts
            .AddLine(p2, p3)
            'oben
            .AddLine(p3, p4)
            'links
            .AddLine(p4, p1)
            .CloseFigure()
        End With

        If _highlight Then
            g.FillPath(New SolidBrush(Color.GreenYellow), graphicsPath)
        Else
            g.FillPath(New SolidBrush(Color.Black), graphicsPath)
        End If
    End Sub

    Public Overrides Function generateDPLCode() As String
        Dim retval As String = $"1X11000{_point.Y * 10:0000}{_point.X * 10:0000}"

        Dim w As Int32 = CInt(_size.Width * 10)
        Dim h As Int32 = CInt(_size.Height * 10)
        If w > 999 Or h > 999 Then
            Return retval & $"l{w:0000}{h:0000}" & CRString
        Else
            Return retval & $"L{w:000}{h:000}" & CRString
        End If
    End Function
End Class
