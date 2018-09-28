Option Strict On
Imports System.ComponentModel

<Serializable()>
Public Class Label
    Private Const cPictureBoxSize As Int32 = 600

    Private _objList As New List(Of ILabelObject)
    Private _mouseObj As ILabelObject = Nothing
    Private _mouseObjStep As Integer
    Private _adding As Boolean = False
    Private _addStatus As Int16

    Private size As New Size()
    Private _mmToPx As Single

    Private _offset As New Size()
    Private _origin As Point

    Public ReadOnly Property Width As Single
        Get
            Return size.Width / _mmToPx
        End Get
    End Property
    Public ReadOnly Property Height As Single
        Get
            Return size.Height / _mmToPx
        End Get
    End Property
    Public ReadOnly Property Origin As Point
        Get
            Return _origin
        End Get
    End Property
    Public ReadOnly Property mmToPx As Single
        Get
            Return _mmToPx
        End Get
    End Property
    Public ReadOnly Property addStatus As Int16
        Get
            Return _addStatus
        End Get
    End Property

    'PUBLIC METHODS
    Public Sub New(width As Single, height As Single)
        If width > height Then
            _mmToPx = (cPictureBoxSize - 2 * BorderSize) / width
        Else
            _mmToPx = (cPictureBoxSize - 2 * BorderSize) / height
        End If
        size.Width = CInt(Math.Round(width * _mmToPx))
        size.Height = CInt(Math.Round(height * _mmToPx))

        _offset.Width = (cPictureBoxSize - size.Width) \ 2
        _offset.Height = (cPictureBoxSize - size.Height) \ 2

        _origin = New Point(_offset.Width, _offset.Height + size.Height)
    End Sub

    Public Sub add(obj As ILabelObject)
        _objList.Add(obj)
        _mouseObj = _objList(_objList.Count - 1)
        If TypeOf obj Is ILabelObject2StepPlacing Then
            _mouseObjStep = 1
            _addStatus = 1
        Else
            _mouseObjStep = 3
            _addStatus = 3
        End If
        _adding = True
    End Sub

    Public Sub update(ByRef g As Graphics, ByRef rtb As RichTextBox, ByRef lb As ListBox, ByRef pg As PropertyGrid, ByVal picBoxOnly As Boolean)
        If picBoxOnly Then
            draw(g)
        Else
            Dim lbSelectedIndex As Integer = lb.SelectedIndex
            updateListBox(lb)
            If lb.Items.Count - 1 < lbSelectedIndex Then
                lbSelectedIndex = lb.Items.Count - 1
            End If
            lb.SelectedIndex = lbSelectedIndex
            highlight(lb.SelectedIndex)
            draw(g)
            generateDPLCode(rtb)
            showProp(lb.SelectedIndex, pg)
        End If
    End Sub

    Public Sub delete(index As Int32)
        If index >= 0 Then
            _objList.RemoveAt(index)
        End If
    End Sub

    Public Sub move(index As Int32)
        If index >= 0 Then
            _mouseObj = _objList(index)
            _mouseObjStep = 3
        End If
    End Sub

    Public Sub highlight(index As Int32)
        For Each obj In _objList
            obj.highlight = False
        Next
        If index >= 0 Then
            _objList(index).highlight = True
        End If
    End Sub

    Public Function mouseMove(pb As PictureBox, x As Integer, y As Integer, raster As Single) As Boolean
        If _mouseObj IsNot Nothing Then
            Dim _x As Single = PxToMm(x - _origin.X)
            Dim _y As Single = PxToMm(_origin.Y - y)
            _x = CSng(Math.Round(_x / raster, 0)) * raster
            _y = CSng(Math.Round(_y / raster, 0)) * raster
            If _x < 0.0 Then _x = 0.0
            If _y < 0.0 Then _y = 0.0

            If TypeOf _mouseObj Is ILabelObject2StepPlacing And _mouseObjStep = 2 Then
                Dim obj As ILabelObject2StepPlacing = CType(_mouseObj, ILabelObject2StepPlacing)
                Dim diffX = _x - obj.x
                Dim diffY = _y - obj.y
                If diffX <= 0 Then
                    diffX = raster
                End If
                If diffY <= 0 Then
                    diffY = raster
                End If
                obj.Breite = diffX
                obj.Höhe = diffY
            Else
                _mouseObj.x = _x
                _mouseObj.y = _y
            End If
            Return True
        End If
        Return False
    End Function

    Public Function mouseClick() As Boolean
        If _mouseObj IsNot Nothing Then
            If _mouseObjStep = 1 Then
                _mouseObjStep = 2
                _addStatus = 2
                Return False
            Else
                _mouseObj = Nothing
                _addStatus = 0
                _adding = False
                Return True
            End If
        End If
        Return False
    End Function

    Public Function cancelAdd() As Boolean
        If _adding Then
            'Letztes Element entfernen
            _mouseObj = Nothing
            _objList.RemoveAt(_objList.Count - 1)
            _addStatus = 0
            Return True
        End If
        _addStatus = 0
        Return False
    End Function

    'PRIVATE METHODS
    Private Sub showProp(index As Int32, ByRef pg As PropertyGrid)
        If index >= 0 And index < _objList.Count Then
            pg.SelectedObject = _objList(index)
        Else
            pg.SelectedObject = Nothing
        End If
    End Sub

    Private Sub draw(ByRef g As Graphics)
        Dim rect As New RectangleF(_offset.Width, _offset.Height, size.Width, size.Height)
        'Label zeichnen
        DrawRoundedRect(g, New Pen(Color.Red, 0.1), New SolidBrush(Color.White), rect, 10)
        'Bereich begrenzen
        g.SetClip(rect)
        'Objekte zeichnen
        For Each obj In _objList
            obj.draw(g, _origin)
        Next
    End Sub

    Private Sub generateDPLCode(ByRef rtb As RichTextBox)
        rtb.Clear()
        rtb.AppendText(STXString & "L" & CRString & vbCrLf)
        'Objekte verarbeiten
        For Each obj In _objList
            rtb.AppendText(obj.generateDPLCode() & vbCrLf)
        Next
        rtb.AppendText("E" & CRString)
    End Sub

    Private Sub updateListBox(ByRef lb As ListBox)
        lb.BeginUpdate()
        lb.Items.Clear()
        For Each obj In _objList
            lb.Items.Add(obj.Name)
        Next
        lb.EndUpdate()
    End Sub
End Class
