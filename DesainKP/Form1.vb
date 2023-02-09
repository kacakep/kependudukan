Imports MySql.Data.MySqlClient
Public Class Form1

    Sub Bersih()
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        If TextBox1.Text = "" And TextBox2.Text = "" Then
            MsgBox("Data tidak boleh kosong")
        Else
            Call koneksi()
            cmd = New MySqlCommand("select * from user where username='" & TextBox1.Text & "' and password='" & TextBox2.Text & "'", con)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                If rd("jabatan").ToString = "admin" Then
                    Menu.Show()
                    Menu.Label1.Text = TextBox1.Text
                    Menu.Label2.Text = "admin"
                    MsgBox("Selamat Datang " + rd!username)
                    Me.Hide()
                Else
                    Me.Hide()
                    Menu.Show()
                    Menu.Label1.Text = TextBox1.Text
                    Menu.Label2.Text = "pegawai"
                    Menu.Button2.Enabled = False
                    Menu.Button5.Enabled = False
                End If
            Else
                MsgBox("Username atau password salah")
            End If
        End If
        Bersih()
    End Sub
End Class
