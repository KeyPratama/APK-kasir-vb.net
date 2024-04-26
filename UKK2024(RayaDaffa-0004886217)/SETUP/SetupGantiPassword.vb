Public Class SetupGantiPassword 
    Sub Simpan()
        'Memeriksa apakah semua inputan sudah terisi. Jika ada yang kosong, muncul pesan peringatan.
        If txtPasswordLama.Text = "" Or txtPasswordBaru.Text = "" Or txtUlangiPassword.Text = "" Then
            MessageBox.Show("Password Lama, Password Baru dan Ulangi Password Wajib Di Isi!", "Comfirm", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        'Mencocokkan password lama yang dimasukkan dengan password lama yang tersimpan dalam database.
        Dim PasswordLama = EksekusiSQL("select password from pengguna where ID_PENGGUNA ='" & My.Settings.lgnID & "'").Select()(0).Item("PASSWORD")

        ' Jika tidak cocok, muncul pesan peringatan.
        If txtPasswordLama.Text <> PasswordLama Then
            MessageBox.Show("Password yang anda tidak sesuai!", "Comfirm", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        'Memeriksa apakah Password Baru sama dengan Ulangi Password. Jika tidak sama, muncul pesan peringatan.
        If txtPasswordBaru.Text <> txtUlangiPassword.Text Then
            MessageBox.Show("Password Baru tidak sesuai!", "Comfirm", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        'Jika semua kondisi terpenuhi, password lama akan diganti dengan password baru dalam database.
        EksekusiSQL("update pengguna set PASSWORD ='" & txtPasswordBaru.Text & "' where ID_PENGGUNA = '" & My.Settings.lgnID & "'")

        'Jika selsai, embali ke login
        SetupLogin.Show()
        SetupMenuUtama.Close()
        Me.Close()
    End Sub

    Sub Tutup()
        Me.Close()
    End Sub

    Private Sub frmGantiPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case e.Control And Keys.Enter
                Simpan()
            Case Keys.Escape
                Tutup()

        End Select
    End Sub



    Private Sub FormGantiPassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load 'Mengatur event handler saat form ganti password dimuat.
        Me.KeyPreview = True

        'Mengatur properti UseSystemPasswordChar pada TextBox untuk mengubah karakter input menjadi karakter berbentuk titik (agar          tidak terlihat) saat memasukkan password.
        txtPasswordBaru.Properties.UseSystemPasswordChar = True
        txtPasswordLama.Properties.UseSystemPasswordChar = True
        txtUlangiPassword.Properties.UseSystemPasswordChar = True

        'Mengosongkan Password Lama, Password Baru, dan Ulangi Password, serta menetapkan fokus pada TextBox untuk Password Baru.
        txtPasswordLama.Text = ""
        txtPasswordBaru.Text = ""
        txtUlangiPassword.Text = ""
        txtPasswordBaru.Focus()
    End Sub


    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Simpan()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Tutup()
    End Sub
End Class