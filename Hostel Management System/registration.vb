Public Class registration

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        sql = "insert into Tbl_login(user_type,user_name,password)"
        sql = sql & "values(' " & cmbtype.Text & " ','" & txtname.Text & "',' " & txtpassword.Text & " ') "
        conn.Execute(sql)
        MsgBox("inserted succesfully")
        loadgrid()
        clear()

    End Sub

    Private Sub registration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        opendb()
        loadgrid()

    End Sub

    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        sql = "update Tbl_login set user_type='" & cmbtype.Text & "',user_name='" & txtname.Text & "',password='" & txtpassword.Text & "'where user_name='" & DataGridView1.CurrentRow.Cells(1).Value & "' "
        conn.Execute(sql)
        MsgBox("record updated")
        loadgrid()
        clear()

    End Sub
    Sub loadgrid()

        Dim i
        i = 0
        sql = " select * from Tbl_login "
        If rs.State = 1 Then rs.Close()
        rs.Open(sql, conn)

        DataGridView1.Rows.Clear()
        Do While rs.EOF = False
            DataGridView1.Rows.Add()
            DataGridView1.Item(0, i).Value = rs(0).Value
            DataGridView1.Item(1, i).Value = rs(1).Value
            DataGridView1.Item(2, i).Value = rs(2).Value
            
            rs.MoveNext()
            i = i + 1
        Loop

    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        cmbtype.Text = DataGridView1.CurrentRow.Cells(0).Value
        txtname.Text = DataGridView1.CurrentRow.Cells(1).Value
        txtpassword.Text = DataGridView1.CurrentRow.Cells(2).Value
    End Sub

    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        sql = "delete from Tbl_login where  user_name='" & DataGridView1.CurrentRow.Cells(1).Value & "'"
        conn.Execute(sql)
        MsgBox("deleted succesfully")
        loadgrid()
        clear()

    End Sub

    Private Sub btnclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclear.Click
        clear()

    End Sub
    Sub clear()
        cmbtype.Text = " "
        txtname.Text = ""
        txtpassword.Text = ""
       
    End Sub
End Class