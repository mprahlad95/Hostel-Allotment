Module General
    Public conn As New ADODB.Connection
    Public sql As String
    Public rs As New ADODB.Recordset

    Public Function OpenDB()
        Try


            If Conn.State = 1 Then Conn.Close()
            conn.Open("Provider=SQLOLEDB.1;Persist Security Info=False;user id=sa;password=mangalore123;Initial Catalog=Hostel;Data Source=SHAHAD-PC")
            Return (0)
        Catch ex As Exception
            MsgBox("Database is not connected ..... Please Check Your Network Connection", MsgBoxStyle.Critical)
            End
        End Try
    End Function
End Module
