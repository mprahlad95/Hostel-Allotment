Public Class complaint

   

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        sql = "insert into tbl_complaint(comp_id,stud_id,Stud_name,complaint,comp_date,status)"
        sql = sql & "values(' " & txtcomplntid.Text & " ','" & txtstudid.Text & "',' " & txtstudname.Text & " ',' " & txtcomplnt.Text & " ',convert(date,'" & DateTimePicker1.Value & "',103),'" & cmbstatus.Text & "')"
        conn.Execute(sql)
        MsgBox("inserted succesfully")
        loadgrid()
        clear()
    End Sub

    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        sql = "update tbl_complaint set comp_id='" & txtcomplntid.Text & "',stud_id='" & txtstudid.Text & "',stud_name='" & txtstudname.Text & "',complaint='" & txtcomplnt.Text & "', comp_date=convert(date,'" & DateTimePicker1.Value & "',103),status='" & cmbstatus.Text & "'where comp_id='" & DataGridView1.CurrentRow.Cells(0).Value & "' "
        conn.Execute(sql)
        MsgBox("record updated")
        loadgrid()
        clear()

    End Sub

    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        sql = "delete from tbl_complaint where  comp_id='" & DataGridView1.CurrentRow.Cells(0).Value & "'"
        conn.Execute(sql)
        MsgBox("deleted succesfully")
        loadgrid()

    End Sub

    Private Sub btrnclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btrnclear.Click
       
        clear()
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        txtcomplntid.Text = DataGridView1.CurrentRow.Cells(0).Value
        txtstudid.Text = DataGridView1.CurrentRow.Cells(1).Value
        txtstudname.Text = DataGridView1.CurrentRow.Cells(2).Value
        txtcomplnt.Text = DataGridView1.CurrentRow.Cells(3).Value

        cmbstatus.Text = DataGridView1.CurrentRow.Cells(4).Value

    End Sub
    Sub loadgrid()

        Dim i
        i = 0
        sql = " select * from tbl_complaint "
        If rs.State = 1 Then rs.Close()
        rs.Open(sql, conn)

        DataGridView1.Rows.Clear()
        Do While rs.EOF = False
            DataGridView1.Rows.Add()
            DataGridView1.Item(0, i).Value = rs(0).Value
            DataGridView1.Item(1, i).Value = rs(1).Value
            DataGridView1.Item(2, i).Value = rs(2).Value
            DataGridView1.Item(3, i).Value = rs(3).Value
            DataGridView1.Item(4, i).Value = rs(5).Value
            DataGridView1.Item(5, i).Value = rs(4).Value



            rs.MoveNext()
            i = i + 1
        Loop

    End Sub
    Sub clear()
        txtcomplntid.Text = " "
        txtstudid.Text = ""
        txtstudname.Text = ""
        txtcomplnt.Text = ""
        cmbstatus.Text = ""
    End Sub

    Private Sub complaint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        opendb()
        loadgrid()

    End Sub
End Class
