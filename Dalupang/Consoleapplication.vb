Imports System.Runtime.InteropServices

Module ConsoleHelper
    <DllImport("kernel32.dll", SetLastError:=True)>
    Public Function AllocConsole() As Boolean
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)>
    Public Function FreeConsole() As Boolean
    End Function
End Module