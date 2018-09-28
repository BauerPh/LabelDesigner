Option Strict On
Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Drawing.Design
Imports System.Windows.Forms.Design
<Serializable()>
Public Class Logo : Inherits LabelObject

    Private _widthMultiplier As Int32 = 1
    Private _heightMultiplier As Int32 = 1
    Private _imageName As String = "mhk"
    Private _imageFilename As String
    Private _image As Image

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

    <Category("Sonstiges")>
    Public Property Logoname As String
        Get
            Return _imageName
        End Get
        Set
            _imageName = Value
        End Set
    End Property

    <Category("Sonstiges")>
    <Editor(GetType(FileNameEditor), GetType(UITypeEditor))>
    Public Property Logodatei As String
        Get
            Return _imageFilename
        End Get
        Set
            Dim saveFilename As String = _imageFilename
            _imageFilename = Value
            Try
                If Not _imageFilename.EndsWith(".bmp") Or Not IO.File.Exists(_imageFilename) Then
                    Throw New Exception
                End If
                _image = Image.FromFile(_imageFilename)
            Catch ex As Exception
                _imageFilename = saveFilename
                MessageBox.Show("Nur *.bmp Dateien erlaubt!", "Wertebereich", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End Set
    End Property
    Public Sub New()
        _name = "Logo"
    End Sub
    Public Overrides Sub draw(ByRef g As Graphics, origin As Point)
        If _image IsNot Nothing Then
            Dim pos As New Size(mmToPx(_point.X), mmToPx(_point.Y) * -1)
            Dim newOrigin As New Point
            newOrigin = origin + pos

            Dim imgSize As New Size(CInt(Math.Round((_image.Width / 2.1))) * _widthMultiplier, CInt(Math.Round((_image.Height / 2.1))) * _heightMultiplier)

            g.DrawImage(_image, newOrigin.X, newOrigin.Y - imgSize.Height, imgSize.Width, imgSize.Height)

            If _highlight Then
                g.DrawRectangle(New Pen(Color.GreenYellow, 5.0), newOrigin.X, newOrigin.Y - imgSize.Height, imgSize.Width, imgSize.Height)
            End If
        End If
    End Sub

    Public Overrides Function generateDPLCode() As String
        Return $"1Y{NumToMultiplier(_widthMultiplier)}{NumToMultiplier(_heightMultiplier)}000{_point.Y * 10:0000}{_point.X * 10:0000}{_imageName}" & CRString
    End Function
End Class
