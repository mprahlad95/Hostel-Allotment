Public Class outing

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        sql = "insert into tbl_outing_register(stud_id,stud_name,date,out_time,reason,in_time)"
        sql = sql & "values(' " & txtid.Text & " ','" & txtname.Text & "',convert(date,'" & DateTimePicker1.Value & "',103),convert(time(7),'" & DateTime.Now.ToLongTimeString() & "',105), '" & txtreason.Text & "',convert(time(7),'" & DateTime.Now.ToLongTimeString() & "',105))"
        conn.Execute(sql)
        MsgBox("inserted succesfully")
        loadgrid()
        clear()


    End Sub

    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        
        sql = "update tbl_outing_register set stud_id='" & txtid.Text & "',stud_name='" & txtname.Text & "',date=convert(date,'" & DateTimePicker1.Value & "',103),out_time=convert(time(7),'" & DateTime.Now.ToLongTimeString() & "',105),reason='" & txtreason.Text & "',in_time=convert(time(7),'" & DateTime.Now.ToLongTimeString() & "',105)where stud_id='" & DataGridView1.CurrentRow.Cells(0).Value & "'"
        conn.Execute(sql)
        MsgBox("record updated")
        loadgrid()
        clear()

       
    End Sub

    Private Sub outing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        opendb()
        loadgrid()

    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        txtid.Text = DataGridView1.CurrentRow.Cells(0).Value
        txtname.Text = DataGridView1.CurrentRow.Cells(1).Value
        DateTimePicker1.Text = DataGridView1.CurrentRow.Cells(2).Value
        DateTimePicker2.Text = DataGridView1.CurrentRow.Cells(3).Value
        txtreason.Text = DataGridView1.CurrentRow.Cells(4).Value
        DateTimePicker3.Text = DataGridView1.CurrentRow.Cells(5).Value

    End Sub
    Sub loadgrid()

        Dim i
        i = 0
        sql = " select * from tbl_outing_register "
        If rs.State = 1 Then rs.Close()
        rs.Open(sql, conn)

        DataGridView1.Rows.Clear()
        Do While rs.EOF = False
            DataGridView1.Rows.Add()
            DataGridView1.Item(0, i).Value = rs(1).Value
            DataGridView1.Item(1, i).Value = rs(2).Value
            DataGridView1.Item(2, i).Value = rs(3).Value
            DataGridView1.Item(3, i).Value = rs(4).Value
            DataGridView1.Item(4, i).Value = rs(5).Value
            DataGridView1.Item(5, i).Value = rs(6).Value

            rs.MoveNext()
            i = i + 1
        Loop

    End Sub

    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        sql = "delete from tbl_outing_register where  stud_id='" & DataGridView1.CurrentRow.Cells(0).Value & "'"
        conn.Execute(sql)
        MsgBox("deleted succesfully")
        loadgrid()
        clear()

    End Sub

    Private Sub btnclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclear.Click
        clear()
    End Sub
    Sub clear()
        txtid.Text = " "
        txtname.Text = ""
        
        txtreason.Text = ""


    End Sub
End Class
