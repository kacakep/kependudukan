Public Class Menu
    Private PindahForm As Form = Nothing
    Public Sub BukaForm(Bukaform As Form)
        If PindahForm IsNot Nothing Then PindahForm.Close()
        PindahForm = Bukaform
        PindahForm.TopLevel = False
        PindahForm.FormBorderStyle = FormBorderStyle.None
        PindahForm.Dock = DockStyle.Fill
        Panel6.Controls.Add(Bukaform)
        Bukaform.BringToFront()
        Bukaform.Show()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        pnlStats.Top = Button1.Top
        pnlStats.Height = Button1.Height
        Panel6.Visible = False

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        pnlStats.Top = Button2.Top
        pnlStats.Height = Button2.Height
        Panel6.Visible = True
        BukaForm(New DataPenduduk)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        pnlStats.Top = Button3.Top
        pnlStats.Height = Button3.Height
        Panel6.Visible = True
        BukaForm(New KK)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        pnlStats.Top = Button4.Top
        pnlStats.Height = Button4.Height
        Panel6.Visible = True
        BukaForm(New KTP)

    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        pnlStats.Top = Button5.Top
        pnlStats.Height = Button5.Height
        Panel6.Visible = True
        BukaForm(New Pegawai)

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If MsgBox("Apakah Anda Ingin Keluar? ", vbYesNo) = vbYes Then
            Me.Close()
            Form1.Show()
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        End
    End Sub
End Class