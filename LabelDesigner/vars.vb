Option Strict On
Module vars
    ' Constants
    Public Const AppName As String = "Label Designer"
    Public Const VersionString As String = "v1.3"
    Public Const CRString As String = "\r"
    Public Const STXString As String = "\02"
    Public Const StandardLabelSize As Single = 101.6
    Public Const BorderSize As Int32 = 17

    ' Objects / Variables
    Public label As Label
    Public actFilename As String = ""
    Public ResourceFilePathPrefix As String
End Module
