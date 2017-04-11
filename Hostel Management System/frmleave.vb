Public Class frmleave


    Private Sub leave_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        opendb()
        loadgrid()


    End Sub

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        sql = "insert into tbl_leave(leave_id,stud_id,stud_name,mess_food,place,date_of_depart,date_of_arrive,leaves,remarks)"
        sql = sql & "values(' " & txtleaves.Text & "', ' " & txtid.Text & " ','" & txtname.Text & "','" & cmbmess.Text & "','" & txtplace.Text & "',convert(date,'" & DateTimePicker1.Value & "',103), convert(date,'" & DateTimePicker2.Value & "',103),'" & txtleaves.Text & "','" & txtremarks.Text & "')"
        conn.Execute(sql)
        MsgBox("inserted succesfully")
        loadgrid()


    End Sub

    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        sql = "update tbl_leave set stud_id='" & txtid.Text & "',leave_id='" & txtleaveid.Text & "',stud_name='" & txtname.Text & "',mess_food='" & cmbmess.Text & "',place='" & txtplace.Text & "',date_of_depart=convert(date,'" & DateTimePicker1.Value & "',103),date_of_arrive=convert(date,'" & DateTimePicker1.Value & "',103),leaves='" & txtleaves.Text & "',remarks='" & txtremarks.Text & "'where stud_id='" & DataGridView1.CurrentRow.Cells(1).Value & "' "
        conn.Execute(sql)
        MsgBox("record updated")
        loadgrid()

    End Sub
    Sub loadgrid()

        Dim i
        i = 0
        sql = " select * from tbl_leave "
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
            DataGridView1.Item(8, i).Value = rs(8).Value
            rs.MoveNext()
            i = i + 1
        Loop

    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        txtleaveid.Text = DataGridView1.CurrentRow.Cells(0).Value
        txtid.Text = DataGridView1.CurrentRow.Cells(1).Value
        txtname.Text = DataGridView1.CurrentRow.Cells(2).Value
        cmbmess.Text = DataGridView1.CurrentRow.Cells(3).Value
        txtplace.Text = DataGridView1.CurrentRow.Cells(4).Value
        DateTimePicker1.Text = DataGridView1.CurrentRow.Cells(5).Value
        DateTimePicker2.Text = DataGridView1.CurrentRow.Cells(6).Value
        txtleaves.Text = DataGridView1.CurrentRow.Cells(7).Value
        txtremarks.Text = DataGridView1.CurrentRow.Cells(8).Value
       
    End Sub

    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        sql = "delete from tbl_leave where  stud_id='" & DataGridView1.CurrentRow.Cells(1).Value & "'"
        conn.Execute(sql)
        MsgBox("deleted succesfully")
        loadgrid()

    End Sub

    Private Sub btnclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclear.Click
        clear()

    End Sub
    Sub clear()
        txtleaveid.Text = " "
        txtid.Text = ""
        txtname.Text = ""
        cmbmess.Text = ""
        txtplace.Text = ""
        txtleaves.Text = ""
        txtremarks.Text = ""
        cmbsearch.Text = ""

    End Sub

    Private Sub btnsearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        If cmbsearch.Text = "stud_id" Then
            Dim i
            i = 0

            sql = "select * from tbl_leave where stud_id='" & txtsearch.Text & "'"
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
                DataGridView1.Item(8, i).Value = rs(8).Value
                

                rs.MoveNext()


            Loop
        ElseIf cmbsearch.Text = "stud_name" Then
            Dim i
            i = 0
            sql = "select * from tbl_leave where stud_name='" & txtsearch.Text & "'"
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
                DataGridView1.Item(8, i).Value = rs(8).Value
               
                rs.MoveNext()


            Loop
       
        End If
    End Sub
End Class