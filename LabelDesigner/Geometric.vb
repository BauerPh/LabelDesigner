Option Strict On
Imports System.ComponentModel

<Serializable()>
Public MustInherit Class Geometric

    Protected _highlight As Boolean
    Protected _point As New PointF(0, 0)

    <Browsable(False)>
    Public Property highlight As Boolean
        Get
            Return _highlight
        End Get
        Set
            _highlight = Value
        End Set
    End Property

    <Category("Position")>
    Public Property x As Single
        Get
            Return _point.X
        End Get
        Set
            checkValue(Value, 0.0, 999.9, _point.X)
        End Set
    End Property

    <Category("Position")>
    Public Property y As Single
        Get
            Return _point.Y
        End Get
        Set
            checkValue(Value, 0.0, 999.9, _point.Y)
        End Set
    End Property
End Class
