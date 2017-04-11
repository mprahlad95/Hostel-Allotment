Public Class visitor

   

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        sql = "insert into tbl_visitor(visitor_id,student_id,Student_Name,visitor_name,reltn,reason,date,time)"
        sql = sql & "values(' " & txtvisit.Text & " ','" & txtstud.Text & "',' " & txtname.Text & " ',' " & txtvisitname.Text & " ',' " & txtreltn.Text & " ',' " & txtreason.Text & " ',convert(date,'" & DateTimePicker1.Value & "',103),convert(time(7),'" & DateTime.Now.ToLongTimeString() & "',105)) "
        conn.Execute(sql)
        MsgBox("inserted succesfully")
        loadgrid()
        clear()


    End Sub
    Sub loadgrid()

        Dim i
        i = 0
        sql = " select * from tbl_visitor "
        If rs.State = 1 Then rs.Close()
        rs.Open(sql, conn)

        DataGridView1.Rows.Clear()
        Do While rs.EOF = False
            DataGridView1.Rows.Add()
            DataGridView1.Item(0, i).Value = rs(0).Value
            DataGridView1.Item(1, i).Value = rs(1).Value
            DataGridView1.Item(2, i).Value = rs(2).Value
            DataGridView1.Item(3, i).Value = rs(3).Value
            DataGridView1.Item(4, i).Value = rs(4).Value
            DataGridView1.Item(5, i).Value = rs(5).Value
            DataGridView1.Item(6, i).Value = rs(6).Value
            DataGridView1.Item(7, i).Value = rs(7).Value

            rs.MoveNext()
            i = i + 1
        Loop

    End Sub

    Private Sub visitor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        opendb()
        loadgrid()

    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        txtvisit.Text = DataGridView1.CurrentRow.Cells(0).Value
        txtstud.Text = DataGridView1.CurrentRow.Cells(1).Value
        txtname.Text = DataGridView1.CurrentRow.Cells(2).Value
        txtvisitname.Text = DataGridView1.CurrentRow.Cells(3).Value
        txtreltn.Text = DataGridView1.CurrentRow.Cells(4).Value
        txtreason.Text = DataGridView1.CurrentRow.Cells(5).Value
        DateTimePicker1.Text = DataGridView1.CurrentRow.Cells(6).Value
    End Sub

    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        sql = "update tbl_visitor set visitor_id='" & txtvisit.Text & "',student_id='" & txtstud.Text & "',student_name='" & txtname.Text & "',visitor_name='" & txtvisitname.Text & "',reltn='" & txtreltn.Text & "',reason='" & txtreason.Text & "', date=convert(date,'" & DateTimePicker1.Value & "',103),time=convert(time(7),'" & DateTime.Now.ToLongTimeString() & "',105)where visitor_id='" & DataGridView1.CurrentRow.Cells(0).Value & "' "
        conn.Execute(sql)
        MsgBox("record updated")
        loadgrid()
        clear()


    End Sub

    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        sql = "delete from tbl_visitor where  visitor_id='" & DataGridView1.CurrentRow.Cells(0).Value & "'"
        conn.Execute(sql)
        MsgBox("deleted succesfully")
        loadgrid()

    End Sub
    Sub clear()
        txtvisit.Text = " "
        txtstud.Text = ""
        txtname.Text = ""
        txtvisitname.Text = ""
        txtreltn.Text = ""
        txtreason.Text = ""

    End Sub
End Class