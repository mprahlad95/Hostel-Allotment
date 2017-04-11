Public Class frmadmission

    Private Sub frmadmission_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OpenDB()
        sql = "select * from tbl_year"
        If rs.State = 1 Then rs.Close()
        rs.Open(sql, conn)
        If rs.EOF = False Then
            txtfrom.Text = rs(0).Value
            txtto.Text = rs(1).Value
        End If
    End Sub

    Private Sub btnbrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbrowse.Click
        With Me.OpenFileDialog1
            .Filter = "all files | *.*"
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                studentpic.ImageLocation = .FileName
            End If
        End With
    End Sub
End Class