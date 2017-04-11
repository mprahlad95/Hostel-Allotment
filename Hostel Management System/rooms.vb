Public Class rooms

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        sql = "insert into tbl_room(room_no,capacity)"
        sql = sql & "values(' " & txtroomno.Text & " ','" & txtcapacity.Text & "') "
        conn.Execute(sql)
        MsgBox("inserted succesfully")
        loadgrid()
        clear()
    End Sub
    Sub loadgrid()

        Dim i
        i = 0
        sql = " select * from tbl_room "
        If rs.State = 1 Then rs.Close()
        rs.Open(sql, conn)

        DataGridView1.Rows.Clear()
        Do While rs.EOF = False
            DataGridView1.Rows.Add()
            DataGridView1.Item(0, i).Value = rs(0).Value
            DataGridView1.Item(1, i).Value = rs(1).Value
            

            rs.MoveNext()
            i = i + 1
        Loop

    End Sub

    Private Sub rooms_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        opendb()
        loadgrid()
        rno()

    End Sub

    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        sql = "update tbl_room set room_no='" & txtroomno.Text & "',capacity='" & txtcapacity.Text & "'where room_no='" & DataGridView1.CurrentRow.Cells(0).Value & "' "
        conn.Execute(sql)
        MsgBox("record updated")
        loadgrid()
        clear()
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        txtroomno.Text = DataGridView1.CurrentRow.Cells(0).Value
        txtcapacity.Text = DataGridView1.CurrentRow.Cells(1).Value
    End Sub

    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        sql = "delete from tbl_room where  room_no='" & DataGridView1.CurrentRow.Cells(0).Value & "'"
        conn.Execute(sql)
        MsgBox("deleted succesfully")
        loadgrid()
        clear()
    End Sub
    Sub clear()
        txtroomno.Text = " "
        txtcapacity.Text = ""
        

    End Sub

    Private Sub btnclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclear.Click
        clear()

    End Sub

    Sub rno()
        Dim j
        j = 1
        txtroomno.Text = j
        sql = "select max(room_no) from tbl_room"
        If rs.State = 1 Then rs.Close()
        rs.Open(sql, conn)



        If rs.EOF = False Then
            j = rs(0).Value
            j = j + 1
            txtroomno.Text = j
        End If

    End Sub
End Class