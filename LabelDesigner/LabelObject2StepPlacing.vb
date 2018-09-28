Option Strict On
Imports System.ComponentModel

Public Interface ILabelObject2StepPlacing : Inherits ILabelObject
    Property Breite As Single
    Property Höhe As Single
End Interface

<Serializable()>
Public MustInherit Class LabelObject2StepPlacing : Inherits LabelObject : Implements ILabelObject2StepPlacing

    Protected _size As New SizeF(0.0, 0.0)

    <Category("Größe")>
    Public Property Breite As Single Implements ILabelObject2StepPlacing.Breite
        Get
            Return _size.Width
        End Get
        Set
            checkValue(Value, 0.1, 999.9, _size.Width)
        End Set
    End Property

    <Category("Größe")>
    Public Property Höhe As Single Implements ILabelObject2StepPlacing.Höhe
        Get
            Return _size.Height
        End Get
        Set
            checkValue(Value, 0.1, 999.9, _size.Height)
        End Set
    End Property
End Class
