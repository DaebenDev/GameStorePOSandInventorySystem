Imports System.Configuration
Imports System.Data.OleDb

Module DbConnection
    Public cn As New OleDbConnection
    Public cmd As OleDbCommand
    Public dr As OleDbDataReader
    Public sql As String

    ' Use Path.GetFullPath to ensure accurate file resolution
    Dim connStr As String = "Provider = Microsoft.ACE.OLEDB.12.0;Data Source=Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Mindoro\Desktop\GameStorePOSandInventorySystemWorking\WinFormsApp1\Database\GamePOS.accdb"

    Public Sub DataConnection()
        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If

            cn.ConnectionString = connStr
            cn.Open()
            MsgBox("Connection Success", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Module
