Imports DevExpress.LookAndFeel
Public Class SetupLogin

    Sub Login()
        'Memeriksa apakah kedua input (username dan password) telah diisi. Jika tidak, tampilkan pesan peringatan.
        If txtUser.Text = "" Or txtPassword.Text = "" Then
            MessageBox.Show("Username, dan Password wajib diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Try
            'pengambilan data ke database berdasarkan inputan username dan password
            Dim Pengguna = EksekusiSQL("select * from pengguna where USERNAME='" & txtUser.Text & "' and PASSWORD='" & txtPassword.Text & "'").Select()
            If Pengguna.Length > 0 Then 'cek jumlah datanya
                'jika ada
                'isikan my.setting berdasarkan siapa yang login
                My.Settings.lgnID = Pengguna(0).Item("ID_PENGGUNA")
                My.Settings.lgnNama = Pengguna(0).Item("NAMA_PENGGUNA")
                My.Settings.lgnAkses = Pengguna(0).Item("HAK_AKSES")
                Select Case My.Settings.lgnAkses
                    'Berdasarkan hak akses pengguna, fungsi PortalMenu() dipanggil untuk mengatur menu yang akan ditampilkan di                         form utama (SetupMenuUtama).
                    Case "Admin"
                        ' Jika pengguna adalah admin, mungkin Anda ingin memberikan akses penuh ke seluruh fitur.
                        ' Di sini Anda bisa memanggil fungsi untuk mengatur menu sesuai dengan peran pengguna.
                        PortalMenu(True, True, True, True, True, True, True, True, True, True, True)
                    Case "OPERATOR"
                        ' Jika pengguna adalah pengguna biasa, mungkin Anda ingin memberikan akses terbatas.
                        ' Di sini Anda bisa memanggil fungsi untuk mengatur menu sesuai dengan peran Operator.
                        PortalMenu(True, True, True, False, False, False, False, False, True, True, True)
                    Case "KASIR"
                        ' Jika pengguna adalah pengguna biasa, mungkin Anda ingin memberikan akses terbatas.
                        ' Di sini Anda bisa memanggil fungsi untuk mengatur menu sesuai dengan peran pengguna.
                        PortalMenu(False, False, False, False, True, True, True, True, False, False, False)
                End Select

                'lanjutkan ke menu utama
                SetupMenuUtama.WindowState = FormWindowState.Maximized
                SetupMenuUtama.Show()
                Me.Close()
            Else
                'jika tidak ada
                If MessageBox.Show("Username/Password tidak ditemukan. Apakah Anda ingin membuat akun baru?", "Validasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    frmPengguna.Show()
                    frmPengguna.WindowState = FormWindowState.Maximized
                Else
                    txtUser.Focus()
                End If
            End If

        Catch ex As Exception
            If MessageBox.Show("Koneksi gagal. Lanjutkan ke konfigurasi koneksi?", "Validasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                frmSetupKonfigurasiKoneksi.ShowDialog()
            End If
        End Try
    End Sub


    Sub Tutup()
        Application.Exit() 'menutup aplikasi bukan menutup form
    End Sub

    Private Sub frmSetupLogin_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Login()
            Case Keys.Escape
                Tutup()
        End Select
    End Sub



    Private Sub frmSetupLogin_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.KeyPreview = True
        txtPassword.Properties.UseSystemPasswordChar = True
        txtUser.Text = ""
        txtPassword.Text = ""
        txtUser.Focus()

        DevExpress.Skins.SkinManager.EnableFormSkins()
        DevExpress.UserSkins.BonusSkins.Register()
        UserLookAndFeel.Default.SetSkinStyle(My.Settings.Tema) 'Menetapkan tema Office 2019 Colorful


    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Login()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Tutup()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        'daftar akun
        If MessageBox.Show("Belum punya akun?.Lanjutkan ke Daftar Akun?", "Validasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            frmPengguna.Show()
            frmPengguna.WindowState = FormWindowState.Maximized
        End If
    End Sub
End Class