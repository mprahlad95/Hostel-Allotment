Public Class Frmmaster

    
    Private Sub YEARSETTINGSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles YEARSETTINGSToolStripMenuItem.Click
        frmyear.MdiParent = Me
        frmyear.Show()
    End Sub

    Private Sub REGISTRATIONToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REGISTRATIONToolStripMenuItem.Click
        frmadmission.MdiParent = Me
        frmadmission.Show()
    End Sub
End Class