Public Class addmission

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        With Me.OpenFileDialog1
            .Filter = "all files | *.*"
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                studentpic.ImageLocation = .FileName
            End If
        End With
    End Sub

   
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    End Sub
End Class