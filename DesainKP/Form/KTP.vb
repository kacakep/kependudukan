Imports MySql.Data.MySqlClient
Public Class KTP

    Sub bersih()
        TextBox1.Text = ""
        TextBox2.Text = ""
        DateTimePicker1.Value = ""
        ComboBox1.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
    End Sub
    Sub Tampil_data()
        On Error Resume Next
        koneksi()
        da = New MySqlDataAdapter("SELECT * FROM ktp order by nik", con)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "ktp")
        Me.DataGridView1.DataSource = (ds.Tables("ktp"))
    End Sub

    Sub simpan()
        On Error Resume Next
        'validasi simpan
        If TextBox1.Text = "" Or TextBox2.Text = "" Or Format(DateTimePicker1.Value, "yyyy-MM-dd") = "" Or ComboBox1.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Then
            MsgBox("isi data dengan lengkap")
        Else
            koneksi()
            Dim simpan As String
            MsgBox("data anda akan disimpan")
            simpan = "INSERT INTO ktp (nik,nama,tgl_lahir,jk,alamat,rt,rw,agama,stat_kawin) VALUES('" & TextBox1.Text & "','" & TextBox2.Text & "', '" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "','" & ComboBox1.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & ComboBox2.Text & "','" & ComboBox3.Text & "')"
            cmd = New MySqlCommand(simpan, con)
            cmd.ExecuteNonQuery()
            bersih()
            Tampil_data()
        End If
    End Sub

    Sub edit()
        koneksi()
        'edit
        On Error Resume Next

        If TextBox1.Text = "" Or TextBox2.Text = "" Or Format(DateTimePicker1.Value, "yyyy-MM-dd") = "" Or TextBox3.Text = "" Or ComboBox1.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Then
            MsgBox("Data tidak ada yang diupdate")
        Else
            MsgBox(" Data akan diupdate")
            Dim edit As String

            edit = "UPDATE ktp SET nik = '" & TextBox1.Text & "', nama = '" & TextBox2.Text & "', tgl_lahir = '" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "', Jk = '" & ComboBox1.Text & "' ,alamat = '" & TextBox3.Text & "',rt ='" & TextBox4.Text & "',rw ='" & TextBox5.Text & "',agama ='" & ComboBox2.Text & "',stat_kawin ='" & ComboBox3.Text & "'WHERE nik = '" & TextBox1.Text & "'"
            cmd = New MySqlCommand(edit, con)
            cmd.ExecuteNonQuery()
            bersih()
            Tampil_data()
            Button1.Enabled = True
        End If
    End Sub

    Sub hapus()
        On Error Resume Next

        If TextBox1.Text = "" Or TextBox2.Text = "" Or Format(DateTimePicker1.Value, "yyyy-MM-dd") = "" Or ComboBox1.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Then
            MsgBox("data tidak ada yang dihapus")
            bersih()
        Else

            If MessageBox.Show("Apakah anda yakin ingin menghapus data ?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Dim hapus As String

                hapus = "DELETE  FROM ktp WHERE nik = '" & Me.TextBox1.Text & "'"
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

    Private Sub KTP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Tampil_data()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        On Error Resume Next
        Button1.Enabled = False
        Button2.Enabled = True
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        DateTimePicker1.Value = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        ComboBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
        TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
        TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value
        TextBox5.Text = DataGridView1.Rows(e.RowIndex).Cells(6).Value
        ComboBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(7).Value
        ComboBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(8).Value

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        hapus()
    End Sub
End Class