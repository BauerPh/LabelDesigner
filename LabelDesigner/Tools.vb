Option Strict On
Imports System.Drawing.Drawing2D
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO
Module Tools
    'Rechteck mit abgerundeten Ecken erstellen (ohne Füllung)
    Public Sub DrawRoundedRect(ByRef g As Graphics, ByRef pen As Pen, ByRef rect As RectangleF, ByVal radius As Single)
        DrawRoundedRect(g, pen, Nothing, rect, radius)
    End Sub
    'Rechteck mit abgerundeten Ecken erstellen (mit Füllung)
    Public Sub DrawRoundedRect(ByRef g As Graphics, ByRef pen As Pen, ByRef brush As SolidBrush, ByRef rect As RectangleF, ByVal radius As Single)
        Dim _graphicsPath As New GraphicsPath
        Dim _diameter As Single = radius * 2
        'Rechteck in oberer linken Ecke für Elipsenbogen
        Dim _cornerRect As New RectangleF(rect.Location, New SizeF(_diameter, _diameter))
        With _graphicsPath
            'Oben links
            .AddArc(_cornerRect, 180, 90)
            'Oben rechts
            _cornerRect.X = rect.Right - _diameter
            .AddArc(_cornerRect, 270, 90)
            'Unten rechts
            _cornerRect.Y = rect.Bottom - _diameter
            .AddArc(_cornerRect, 0, 90)
            'Unten links
            _cornerRect.X = rect.Left
            .AddArc(_cornerRect, 90, 90)
            .CloseFigure()
        End With
        'Füllen?
        If brush IsNot Nothing Then
            g.FillPath(brush, _graphicsPath)
        End If
        g.DrawPath(pen, _graphicsPath)
    End Sub

    Function NumToMultiplier(num As Int32) As Char
        If num >= 0 And num <= 9 Then
            Return Chr(num + 48)
        ElseIf num >= 10 And num <= 35 Then
            Return Chr(num + 55)
        ElseIf num >= 36 And num <= 61 Then
            Return Chr(num + 61)
        Else
            Return "0"c
        End If
    End Function

    Function MultiplierToNum(mult As Char) As Int32
        Dim ascInt As Int32 = Asc(mult)
        If ascInt >= 48 And ascInt <= 57 Then
            Return ascInt - 48
        ElseIf ascInt >= 65 And ascInt <= 90 Then
            Return ascInt - 55
        ElseIf ascInt >= 97 And ascInt <= 122 Then
            Return ascInt - 61
        Else
            Return 0
        End If
    End Function

    Function DelCrLf(str As String) As String
        Dim strTmp As String = ""

        If str Is Nothing Then Return ""

        For i = 0 To Len(str) - 1
            If Not (str(i) = vbLf Or str(i) = vbCr) Then
                strTmp = strTmp & str(i)
            End If
        Next i

        Return strTmp
    End Function

    Function mmToPx(mm As Single) As Int32
        Return CInt(Math.Round(mm * vars.label.mmToPx))
    End Function

    Function PxToMm(Px As Int32) As Single
        Return CSng(Px) / vars.label.mmToPx
    End Function

    Sub checkValue(value As Int32, min As Int32, max As Int32, ByRef target As Int32)
        If value < min Or value > max Then
            MessageBox.Show("Nur Werte zwischen " & min & " und " & max & " erlaubt!", "Wertebereich", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            target = value
        End If
    End Sub
    Sub checkValue(value As Single, min As Single, max As Single, ByRef target As Single)
        If value < min Or value > max Then
            MessageBox.Show("Nur Werte zwischen " & min & " und " & max & " erlaubt!", "Wertebereich", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            target = value
        End If
    End Sub

    Public Function saveFile(Optional filename As String = Nothing) As Boolean
        Dim fs As FileStream = Nothing
        Dim tmpFilename As String = Nothing
        Dim fileDialog As New SaveFileDialog
        fileDialog.Filter = "Label Designer Dateien|*.ld"
        Dim success As Boolean = False
        Try
            If filename Is Nothing Then
                ' Datei auswählen
                If fileDialog.ShowDialog() = DialogResult.OK Then
                    tmpFilename = fileDialog.FileName
                End If
            Else
                tmpFilename = filename
            End If

            If tmpFilename IsNot Nothing Then
                ' Datei zum Schreiben öffnen / erstellen
                fs = New FileStream(tmpFilename, FileMode.Create, FileAccess.Write)

                ' Objekt serialisieren und speichern
                Dim formatter As New BinaryFormatter()
                formatter.Serialize(fs, vars.label)

                actFilename = tmpFilename
                success = True
            End If
        Catch ex As Exception
        Finally
            ' Datei schließen
            If fs IsNot Nothing Then fs.Close()
        End Try

        If success Then
            updateTitle()
        End If

        Return success
    End Function

    Public Function loadFile() As Boolean
        Dim success As Boolean = False
        Dim fileDialog As New OpenFileDialog
        fileDialog.Filter = "Label Designer Dateien|*.ld"
        ' Datei auswählen
        If fileDialog.ShowDialog() = DialogResult.OK Then
            ' Prüfen, ob Datei existiert
            If IO.File.Exists(fileDialog.FileName) Then
                Dim fs As FileStream = Nothing
                Try
                    ' Datei zum Lesen öffnen
                    fs = New FileStream(fileDialog.FileName, FileMode.Open, FileAccess.Read)

                    ' Daten deserialiseren und dem Array zuweisen
                    Dim formatter As New BinaryFormatter()
                    vars.label = CType(formatter.Deserialize(fs), Label)

                    actFilename = fileDialog.FileName
                    success = True

                Catch ex As Exception
                Finally
                    ' Datei schließen
                    If fs IsNot Nothing Then fs.Close()
                End Try
            End If
        End If

        If success Then
            updateTitle()
        End If

        Return success
    End Function

    Public Sub updateTitle()
        If actFilename.Length > 0 Then
            frmMain.Text = AppName & " " & VersionString & " - " & actFilename
        Else
            frmMain.Text = AppName & " " & VersionString
        End If
    End Sub

End Module
