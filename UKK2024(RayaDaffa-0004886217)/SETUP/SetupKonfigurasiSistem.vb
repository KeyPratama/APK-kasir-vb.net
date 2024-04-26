Imports DevExpress.LookAndFeel
Imports DevExpress.XtraBars.Helpers
Public Class SetupKonfigurasiSitem

   
    Sub TampilWallpaper(ByVal LokasiGambar As String)
        ' digunakan untuk menampilkan gambar wallpaper pada komponen PictureEdit dengan mode gambar yang diperpanjang.
        Try
            txtWallpaperPreview.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
            txtWallpaperPreview.Image = Image.FromFile(LokasiGambar)
        Catch ex As Exception

        End Try
    End Sub

    Sub TampilPengaturan() 'digunakan untuk menampilkan pengaturan yang tersimpan ke dalam form.

        ' Lokasi laporan, tema aplikasi, dan lokasi wallpaper akan ditampilkan sesuai dengan pengaturan yang tersimpan dalam                 My.Settings.
        txtLokasiLaporan.Text = My.Settings.LokasiLaporan
        'Tampilkan isian tema ke galeryControl
        DevExpress.Skins.SkinManager.EnableFormSkins()
        DevExpress.UserSkins.BonusSkins.Register()
        UserLookAndFeel.Default.SetSkinStyle(My.Settings.Tema)
        SkinHelper.InitSkinGallery(txtTema, True)
        txtWallpaper.Text = My.Settings.LokasiWallpaper
        TampilWallpaper(My.Settings.LokasiWallpaper)
    End Sub

    Sub SimpanPengaturan() 'digunakan untuk menyimpan pengaturan yang telah diubah oleh pengguna.
        My.Settings.LokasiLaporan = txtLokasiLaporan.Text
        'simpan pilihan tema dari galerycontrol
        Dim NamaSkin = txtTema.Gallery.GetCheckedItem.Value
        If NamaSkin = "Xmas (Blue)" Then
            NamaSkin = "Xmas 2008 Blue"
        ElseIf NamaSkin = "Summer" Then
            NamaSkin = "Summer 2008"
        ElseIf NamaSkin = "Office 2013 White" Then
            NamaSkin = "Office 2013"
        End If
        My.Settings.Tema = NamaSkin
        My.Settings.LokasiWallpaper = txtWallpaper.Text
        My.Settings.Save()
        'tampilkan wallpaper ke dalam menu utama
        Try
            If My.Settings.LokasiWallpaper = "" Then
                SetupMenuUtama.BackgroundImage = Nothing
            Else
                SetupMenuUtama.BackgroundImageLayout = ImageLayout.Stretch
                SetupMenuUtama.BackgroundImage = Image.FromFile(My.Settings.LokasiWallpaper)
            End If
        Catch ex As Exception

        End Try
        Me.Close()
    End Sub

    Sub Tutup()
        Me.Close()
    End Sub

    Private Sub frmSetupKonfigurasiSistem_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case e.Control And Keys.S
                SimpanPengaturan()
            Case Keys.Escape
                Tutup()
        End Select
    End Sub

    Private Sub frmSetupKonfigurasiSistem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        txtWallpaper.ReadOnly = True
        TampilPengaturan()

    End Sub

    Private Sub txtWallpaper_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtWallpaper.ButtonClick
        'koding untuk memilih gambar di drive
        Dim OPD As New OpenFileDialog
        OPD.Filter = "JPG|*jpg|PNG|*.png"
        If OPD.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtWallpaper.Text = OPD.FileName
            TampilWallpaper(OPD.FileName)
        End If
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        SimpanPengaturan()
    End Sub

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        Tutup()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        'bersihkan
        txtWallpaper.Text = ""
        txtWallpaperPreview.Image = Nothing
    End Sub
End Class
