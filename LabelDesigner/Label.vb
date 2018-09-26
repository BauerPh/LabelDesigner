Option Strict On
Imports System.ComponentModel

<Serializable()>
Public Class Label
    Private Const cPictureBoxSize As Int32 = 600

    Private _objList As New ArrayList
    Private _mouseObj As Object = Nothing
    Private _mouseObjStep As Integer

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

    Public Sub New()
        _mmToPx = (cPictureBoxSize - 2 * BorderSize) / StandardLabelSize

        size.Width = CInt(Math.Round(Width * _mmToPx))
        size.Height = CInt(Math.Round(Height * _mmToPx))

        _offset.Width = (cPictureBoxSize - size.Width) \ 2
        _offset.Height = (cPictureBoxSize - size.Height) \ 2

        _origin = New Point(_offset.Width, _offset.Height + size.Height)
    End Sub

    Public Function add(obj As Object) As Boolean
        If TypeOf obj Is Line Or TypeOf obj Is Box Or TypeOf obj Is Logo Or TypeOf obj Is Datamatrix Or TypeOf obj Is Text Or TypeOf obj Is Barcode Then
            _objList.Add(obj)
            _mouseObj = _objList(_objList.Count - 1)
            If TypeOf obj Is Line Or TypeOf obj Is Box Then
                _mouseObjStep = 1
            Else
                _mouseObjStep = 3
            End If
            Return True
        End If
        Return False
    End Function

    Public Sub update(ByRef g As Graphics, ByRef rtb As RichTextBox, ByRef lb As ListBox, ByRef pg As PropertyGrid, ByVal updListBox As Boolean, ByVal picBoxOnly As Boolean)
        If updListBox Then
            updateListBox(lb)
        End If
        highlight(lb.SelectedIndex)
        draw(g)
        If Not picBoxOnly Then
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
            If TypeOf obj Is Line Then
                CType(obj, Line).highlight = False
            ElseIf TypeOf obj Is Box Then
                CType(obj, Box).highlight = False
            ElseIf TypeOf obj Is Logo Then
                CType(obj, Logo).highlight = False
            ElseIf TypeOf obj Is Datamatrix Then
                CType(obj, Datamatrix).highlight = False
            ElseIf TypeOf obj Is Text Then
                CType(obj, Text).highlight = False
            ElseIf TypeOf obj Is Barcode Then
                CType(obj, Barcode).highlight = False
            End If
        Next
        If index >= 0 Then
            If TypeOf _objList(index) Is Line Then
                CType(_objList(index), Line).highlight = True
            ElseIf TypeOf _objList(index) Is Box Then
                CType(_objList(index), Box).highlight = True
            ElseIf TypeOf _objList(index) Is Logo Then
                CType(_objList(index), Logo).highlight = True
            ElseIf TypeOf _objList(index) Is Datamatrix Then
                CType(_objList(index), Datamatrix).highlight = True
            ElseIf TypeOf _objList(index) Is Text Then
                CType(_objList(index), Text).highlight = True
            ElseIf TypeOf _objList(index) Is Barcode Then
                CType(_objList(index), Barcode).highlight = True
            End If
        End If
    End Sub

    Public Function mouseMove(pb As PictureBox, x As Integer, y As Integer, raster As Single) As Boolean
        If _mouseObj IsNot Nothing Then
            Dim _x As Single = PxTomm(x - _origin.X)
            Dim _y As Single = PxTomm(_origin.Y - y)
            _x = CSng(Math.Round(_x / raster, 0)) * raster
            _y = CSng(Math.Round(_y / raster, 0)) * raster
            If _x < 0.0 Then _x = 0.0
            If _y < 0.0 Then _y = 0.0

            If TypeOf _mouseObj Is Line Then
                Dim obj As Line = CType(_mouseObj, Line)
                If _mouseObjStep = 2 Then
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
                    obj.x = _x
                    obj.y = _y
                End If
            ElseIf TypeOf _mouseObj Is Box Then
                Dim obj As Box = CType(_mouseObj, Box)
                If _mouseObjStep = 2 Then
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
                    obj.x = _x
                    obj.y = _y
                End If
            ElseIf TypeOf _mouseObj Is Logo Then
                Dim obj As Logo = CType(_mouseObj, Logo)
                obj.x = _x
                obj.y = _y
            ElseIf TypeOf _mouseObj Is Datamatrix Then
                Dim obj As Datamatrix = CType(_mouseObj, Datamatrix)
                obj.x = _x
                obj.y = _y
            ElseIf TypeOf _mouseObj Is Text Then
                Dim obj As Text = CType(_mouseObj, Text)
                obj.x = _x
                obj.y = _y
            ElseIf TypeOf _mouseObj Is Barcode Then
                Dim obj As Barcode = CType(_mouseObj, Barcode)
                obj.x = _x
                obj.y = _y
            End If
            Return True
        End If
        Return False
    End Function

    Public Function mouseClick() As Boolean
        If _mouseObj IsNot Nothing Then
            If _mouseObjStep = 1 Then
                _mouseObjStep = 2
            Else
                _mouseObj = Nothing
            End If
            Return True
        End If
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
            If TypeOf obj Is Line Then
                CType(obj, Line).draw(g, _origin)
            ElseIf TypeOf obj Is Box Then
                CType(obj, Box).draw(g, _origin)
            ElseIf TypeOf obj Is Logo Then
                CType(obj, Logo).draw(g, _origin)
            ElseIf TypeOf obj Is Datamatrix Then
                CType(obj, Datamatrix).draw(g, _origin)
            ElseIf TypeOf obj Is Text Then
                CType(obj, Text).draw(g, _origin)
            ElseIf TypeOf obj Is Barcode Then
                CType(obj, Barcode).draw(g, _origin)
            End If
        Next
    End Sub

    Private Sub generateDPLCode(ByRef rtb As RichTextBox)
        rtb.Clear()
        rtb.AppendText(STXString & "L" & CRString & vbCrLf)
        'Objekte verarbeiten
        For Each obj In _objList
            If TypeOf obj Is Line Then
                rtb.AppendText(CType(obj, Line).generateDPLCode() & vbCrLf)
            ElseIf TypeOf obj Is Box Then
                rtb.AppendText(CType(obj, Box).generateDPLCode() & vbCrLf)
            ElseIf TypeOf obj Is Logo Then
                rtb.AppendText(CType(obj, Logo).generateDPLCode() & vbCrLf)
            ElseIf TypeOf obj Is Datamatrix Then
                rtb.AppendText(CType(obj, Datamatrix).generateDPLCode() & vbCrLf)
            ElseIf TypeOf obj Is Text Then
                rtb.AppendText(CType(obj, Text).generateDPLCode() & vbCrLf)
            ElseIf TypeOf obj Is Barcode Then
                rtb.AppendText(CType(obj, Barcode).generateDPLCode() & vbCrLf)
            End If
        Next
        rtb.AppendText("E" & CRString)
    End Sub

    Private Sub updateListBox(ByRef lb As ListBox)
        Dim lines, boxes, logos, datamatrixcodes, texts, barcodes As Int32

        lb.Items.Clear()

        For Each obj In _objList
            If TypeOf obj Is Line Then
                lines += 1
                lb.Items.Add("Linie" & lines)
            ElseIf TypeOf obj Is Box Then
                boxes += 1
                lb.Items.Add("Box" & boxes)
            ElseIf TypeOf obj Is Logo Then
                logos += 1
                lb.Items.Add("Logo" & logos)
            ElseIf TypeOf obj Is Datamatrix Then
                datamatrixcodes += 1
                lb.Items.Add("Datamatrixcode" & datamatrixcodes)
            ElseIf TypeOf obj Is Text Then
                texts += 1
                lb.Items.Add("Text" & texts)
            ElseIf TypeOf obj Is Barcode Then
                barcodes += 1
                lb.Items.Add("Strichcode" & barcodes)
            Else
                lb.Items.Add("ERROR")
            End If
        Next
    End Sub
End Class
