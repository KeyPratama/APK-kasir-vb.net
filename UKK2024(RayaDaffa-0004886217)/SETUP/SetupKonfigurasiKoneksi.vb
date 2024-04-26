Imports MySql.Data.MySqlClient

Public Class frmSetupKonfigurasiKoneksi

    Sub TampilMySetting() 'digunakan untuk menampilkan pengaturan koneksi yang tersimpan dalam My.Settings ke dalam komponen form seperti TextEdit dan SpinEdit.

        ' Menampilkan isi My.Settings ke komponen pada konfigurasi koneksi
        txtNamaServer.Text = My.Settings.konNamaServer
        txtNamaUser.Text = My.Settings.konNamaUser
        txtKataSandi.Text = My.Settings.konKataSandi
        txtNamaDatabase.Text = My.Settings.konNamaDatabase
        txtPortal.Value = My.Settings.konPortal
    End Sub

    Sub TesKoneksi() 'digunakan untuk menguji koneksi ke database MySQL berdasarkan inputan pengguna di form.
        ' Pengecekan input apakah sudah terisi atau belum

        'dilakukan pengecekan apakah input sudah terisi dengan benar atau belum.
        If txtNamaServer.Text = "" Or txtNamaUser.Text = "" Or txtNamaDatabase.Text = "" Or txtPortal.Value = 0 Then
            MessageBox.Show("Nama Server, Nama User, Nama Database, dan Portal wajib diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub ' Membatalkan kodingan tes koneksi
        End If

        Try
            ' Melakukan koneksi berdasarkan inputan yang ada di komponen konfigurasi koneksi
            ' dibuat string koneksi berdasarkan inputan pengguna.
            Dim Alamat As String = "server=" & txtNamaServer.Text & ";user id=" & txtNamaUser.Text & ";password=" & txtKataSandi.Text & ";database=" & txtNamaDatabase.Text & ";port=" & txtPortal.Value & ""

            '  Dilakukan koneksi ke database MySQL menggunakan MySqlConnection.
            Dim Koneksi As New MySqlConnection(Alamat)
            Koneksi.Open()
            Koneksi.Close()

            'Jika koneksi berhasil, ditampilkan pesan informasi "Koneksi berhasil"
            MessageBox.Show("Koneksi berhasil.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)

            'Jika gagal, ditampilkan pesan peringatan dengan pesan kesalahan yang diambil dari Exception.
        Catch ex As Exception
            MessageBox.Show("Koneksi Gagal. " & ex.Message, "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Sub SimpanKoneksi() ' digunakan untuk menyimpan konfigurasi koneksi baru yang telah diatur oleh pengguna.
        ' Pengecekan input apakah sudah terisi atau belum

        'dilakukan pengecekan apakah input sudah terisi dengan benar atau belum.
        If txtNamaServer.Text = "" Or txtNamaUser.Text = "" Or txtNamaDatabase.Text = "" Or txtPortal.Value = 0 Then
            MessageBox.Show("Nama Server, Nama User, Nama Database, dan Portal wajib diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub ' Membatalkan kodingan tes koneksi
        End If

        Try
            ' Melakukan koneksi berdasarkan inputan yang ada di komponen konfigurasi koneksi
            Dim Alamat As String = "server=" & txtNamaServer.Text & ";user id=" & txtNamaUser.Text & ";password=" & txtKataSandi.Text & ";database=" & txtNamaDatabase.Text & ";port=" & txtPortal.Value
            Dim Koneksi As New MySqlConnection(Alamat)
            Koneksi.Open()
            Koneksi.Close()

            ' Menyimpan koneksi ke pengaturan
            My.Settings.konNamaServer = txtNamaServer.Text
            My.Settings.konNamaUser = txtNamaUser.Text
            My.Settings.konKataSandi = txtKataSandi.Text
            My.Settings.konNamaDatabase = txtNamaDatabase.Text
            My.Settings.konPortal = txtPortal.Value
            My.Settings.Save()

            'Jika koneksi berhasil, konfigurasi koneksi disimpan ke My.Settings, dan ditampilkan pesan informasi "Berhasil                      disimpan". 
            MessageBox.Show("Berhasil disimpan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()

            'Jika gagal, ditampilkan pesan peringatan dengan pesan kesalahan yang diambil dari Exception.
        Catch ex As Exception
            MessageBox.Show("Gagal disimpan. " & ex.Message, "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try


    End Sub

    Private Sub frmSetupKonfigurasiKoneksi_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        ' Tempat shortcut
        Select Case e.KeyCode
            Case e.Control And Keys.T
                TesKoneksi()
            Case e.Control And Keys.S
                SimpanKoneksi()
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub frmSetupKonfigurasiKoneksi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        txtKataSandi.Properties.UseSystemPasswordChar = True 'Menyembunyikan teks kata sandi saat diinputkan menggunakan UseSystemPasswordChar.
        TampilMySetting()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        TesKoneksi()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        SimpanKoneksi()
    End Sub
End Class
