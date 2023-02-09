Imports MySql.Data.MySqlClient
Public Class KK
    Sub Tampil_data()
        koneksi()
        da = New MySqlDataAdapter("SELECT * FROM kk order by no_kk", con)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "kk")
        Me.DataGridView1.DataSource = (ds.Tables("kk"))
    End Sub

    Sub bersih()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        ComboBox1.Text = ""
        TextBox4.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        TextBox5.Text = ""
    End Sub

    'Deklarasi Button Simpan
    Sub simpan()

        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or ComboBox1.Text = "" Or TextBox4.Text = "" Or Format(Me.DateTimePicker1.Value, "yyyy-MM-dd") = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Or TextBox5.Text = "" Then
            MsgBox("isi data dengan lengkap")
        Else
            koneksi()
            Dim simpan As String
            MsgBox("data anda akan disimpan")
            simpan = "INSERT INTO kk (no_kk,nama,nik,jk,tmpt_lhr,tgl_lahir,agama,pendidikan,pekerjaan) VALUES('" & TextBox1.Text & "','" & TextBox2.Text & "'.'" & TextBox3.Text & "','" & ComboBox1.Text & "','" & TextBox4.Text & "','" & Format(Me.DateTimePicker1.Value, "yyyy-MM-dd") & "','" & ComboBox2.Text & "','" & ComboBox3.Text & "','" & TextBox5.Text & "')"
            cmd = New MySqlCommand(simpan, con)
            cmd.ExecuteNonQuery()
            bersih()
            Tampil_data()
        End If
    End Sub

    'Deklarasi Button Edit
    Sub edit()
        koneksi()

        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or ComboBox1.Text = "" Or TextBox4.Text = "" Or Format(Me.DateTimePicker1.Value, "yyyy-MM-dd") = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Or TextBox5.Text = "" Then
            MsgBox("data tidak ada yang diupdate")
        Else
            MsgBox(" data akan diupdate")
            Dim edit As String

            edit = "UPDATE KK Set no_kk ='" & TextBox1.Text & "',nama =' " & TextBox2.Text & "' , nik = '" & TextBox3.Text & "', jns_kelamin ='" & ComboBox1.Text & "' , tmpt_lhr = '" & TextBox4.Text & "',tgl_lahir = '" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "', agama = '" & ComboBox2.Text & "', pendidikan = '" & ComboBox3.Text & "', pekerjaan = '" & TextBox5.Text & "' WHERE no_kk = '" & TextBox1.Text & "'"
            cmd = New MySqlCommand(edit, con)
            cmd.ExecuteNonQuery()
            bersih()
            Tampil_data()
            Button1.Enabled = True
        End If
    End Sub

    'Deklarasi Button Hapus
    Sub hapus()
        koneksi()
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or ComboBox1.Text = "" Or TextBox4.Text = "" Or Format(Me.DateTimePicker1.Value, "yyyy-MM-dd") = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Or TextBox5.Text = "" Then
            MsgBox("data tidak ada yang dihapus")
            bersih()
        Else

            If MessageBox.Show("Apakah anda yakin ingin menghapus data ?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Dim hapus As String

                hapus = "DELETE FROM KK WHERE no_kk = '" & TextBox1.Text & "'"
                cmd = New MySqlCommand(hapus, con)
                cmd.ExecuteNonQuery()
                bersih()
                Tampil_data()
            Else
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        simpan()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        edit()
    End Sub

    Private Sub KK_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Tampil_data()
        End With
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        hapus()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Button1.Enabled = False
        Button2.Enabled = True
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value


    End Sub
End Class