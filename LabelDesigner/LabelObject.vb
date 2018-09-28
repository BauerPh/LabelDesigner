Option Strict On
Imports System.ComponentModel
Imports LabelDesigner

Public Interface ILabelObject
    Property Name As String
    Property highlight As Boolean
    Property x As Single
    Property y As Single
    Sub draw(ByRef g As Graphics, origin As Point)
    Function generateDPLCode() As String
End Interface

<Serializable()>
Public MustInherit Class LabelObject : Implements ILabelObject

    Protected _name As String
    Protected _highlight As Boolean
    Protected _point As New PointF(0, 0)

    <Browsable(False)>
    Public Property highlight As Boolean Implements ILabelObject.highlight
        Get
            Return _highlight
        End Get
        Set
            _highlight = Value
        End Set
    End Property

    <Category("Position")>
    Public Property x As Single Implements ILabelObject.x
        Get
            Return _point.X
        End Get
        Set
            checkValue(Value, 0.0, 999.9, _point.X)
        End Set
    End Property

    <Category("Position")>
    Public Property y As Single Implements ILabelObject.y
        Get
            Return _point.Y
        End Get
        Set
            checkValue(Value, 0.0, 999.9, _point.Y)
        End Set
    End Property

    <Category("Beschreibung")>
    Public Property Name As String Implements ILabelObject.Name
        Get
            Return _name
        End Get
        Set
            If Value.Length = 0 Then
                MessageBox.Show("Name darf nicht leer sein!", "Wertebereich", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                _name = Value
            End If
        End Set
    End Property

    Public MustOverride Sub draw(ByRef g As Graphics, origin As Point) Implements ILabelObject.draw
    Public MustOverride Function generateDPLCode() As String Implements ILabelObject.generateDPLCode
End Class
