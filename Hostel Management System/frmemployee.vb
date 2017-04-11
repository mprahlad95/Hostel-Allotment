﻿Public Class frmemployee

    
    Private Sub frmemployee_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        opendb()
        loadgrid()

    End Sub

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        sql = "insert into tbl_empinfo(emp_id,emp_name,emp_address,emp_qualification,emp_cont,email_id,emp_desig)"
        sql = sql & "values(' " & txtid.Text & " ',' " & txtname.Text & " ',' " & txtaddress.Text & " ',' " & txtqualification.Text & " ',' " & txtcont.Text & " ',' " & txteid.Text & " ',' " & txtdesig.Text & " ') "
        conn.Execute(sql)
        MsgBox("inserted succesfully")
        loadgrid()
        clear()
    End Sub
    Sub loadgrid()

        Dim i
        i = 0
        sql = " select * from tbl_empinfo "
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


            rs.MoveNext()
            i = i + 1
        Loop

    End Sub

    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        sql = "update tbl_empinfo set emp_id='" & txtid.Text & "',emp_name='" & txtname.Text & "',emp_address='" & txtaddress.Text & "',emp_qualification='" & txtqualification.Text & "',emp_cont='" & txtcont.Text & "',email_id='" & txteid.Text & "',emp_desig='" & txtdesig.Text & "' where emp_id='" & DataGridView1.CurrentRow.Cells(0).Value & "' "
        conn.Execute(sql)
        MsgBox("record updated")
        loadgrid()
        clear()

    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        txtid.Text = DataGridView1.CurrentRow.Cells(0).Value
        txtname.Text = DataGridView1.CurrentRow.Cells(1).Value
        txtaddress.Text = DataGridView1.CurrentRow.Cells(2).Value
        txtqualification.Text = DataGridView1.CurrentRow.Cells(3).Value
        txtcont.Text = DataGridView1.CurrentRow.Cells(4).Value
        txteid.Text = DataGridView1.CurrentRow.Cells(5).Value
        txtdesig.Text = DataGridView1.CurrentRow.Cells(6).Value
    End Sub

    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        sql = "delete from tbl_empinfo where  emp_id='" & DataGridView1.CurrentRow.Cells(0).Value & "'"
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
        txtaddress.Text = ""
        txtqualification.Text = ""
        txtcont.Text = ""
        txteid.Text = ""
        txtdesig.Text = ""

    End Sub
End Class