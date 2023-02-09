Imports MySql.Data.MySqlClient
Public Class DataPenduduk
    Sub Combobox()
        Call koneksi()
        Dim str As String
        str = "select nik from ktp"
        cmd = New MySqlCommand(str, con)
        rd = cmd.ExecuteReader
        If rd.HasRows Then
            Do While rd.Read
                ComboBox4.Items.Add(rd("nik"))
            Loop
        Else
        End If
    End Sub
    Sub Tampil_data()
        koneksi()
        da = New MySqlDataAdapter("SELECT * FROM data_penduduk order by no_kk", con)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "data_penduduk")
        Me.DataGridView1.DataSource = (ds.Tables("data_penduduk"))
    End Sub
    Sub Bersih()
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        ComboBox4.Text = ""
        ComboBox5.Text = ""
        Tampil_data()
    End Sub


    'Sub untuk menyimpan
    Sub simpan()
        koneksi()
        If TextBox1.Text = "" Or ComboBox4.Text = "" Or TextBox3.Text = "" Or ComboBox5.Text = "" Or ComboBox1.Text = "" Or Format(DateTimePicker1.Value, "yyyy-MM-dd") = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Or TextBox8.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Or TextBox11.Text = "" Then
            MsgBox("isi data dengan lengkap")
        Else
            Dim simpan As String
            MsgBox("data anda akan disimpan")
            simpan = "INSERT INTO data_penduduk (id_dpi,no,nik,nama,no_kk,jns_kelamin,tgl_lahir,pekerjaan,alamat,rt,rw,agama,pendidikan,username) VALUES('" & TextBox1.Text & "','" & ComboBox4.Text & "','" & TextBox3.Text & "',''" & ComboBox5.Text & "','" & ComboBox1.Text & "','" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "','" & TextBox5.Text & "',''" & TextBox6.Text & "',''" & TextBox7.Text & "',''" & TextBox8.Text & "',''" & ComboBox2.Text & "',''" & ComboBox3.Text & "',''" & TextBox11.Text & "')"
            cmd = New MySqlCommand(simpan, con)
            cmd.ExecuteNonQuery()
            Bersih()
        End If
        Bersih()
    End Sub

    Private Sub DataPenduduk_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Combobox()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        simpan()
    End Sub

End Class