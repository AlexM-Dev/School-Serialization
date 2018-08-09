Imports System.Runtime.InteropServices

Public Module NativeMethods
    <DllImport("uxtheme.dll", ExactSpelling:=True, CharSet:=CharSet.Unicode)>
    Public Function SetWindowTheme(hWnd As IntPtr, pszSubAppName As String, pszSubIdList As String) As Integer
    End Function
End Module
