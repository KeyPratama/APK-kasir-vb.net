Public Class SetupMenuUtama

  
    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        'ganti password
        SetupGantiPassword.ShowDialog()
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        'Logout
        If MessageBox.Show("Akses aplikasi akan ditutup.Lanjutkan?", "Validasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        'keluar
        If MessageBox.Show("Akses aplikasi akan ditutup.Lanjutkan?", "Validasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub



    Private Sub BarButtonItem10_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnKonfigurasiKoneksi.ItemClick
        frmSetupKonfigurasiKoneksi.ShowDialog()
    End Sub

    Private Sub frmSetupMenuUtama_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BarButtonItem8.Caption = "Pengguna : " & My.Settings.lgnNama
        BarButtonItem9.Caption = "Hak Akses : " & My.Settings.lgnAkses
        'pengaturan wallpaper berdasarkan simpanan
        Try
            Me.BackgroundImageLayout = ImageLayout.Stretch
            Me.BackgroundImage = Image.FromFile(My.Settings.LokasiWallpaper)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim Tanggal = Now
        BarButtonItem10.Caption = "Tanggal " & Format(Tanggal, "dd MMMM yyyy") & ", Pukul " & Format(Tanggal, "HH:mm:ss") & ""
    End Sub


    Private Sub BarButtonItem11_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnPelanggan.ItemClick
        frmPelanggan.MdiParent = Me
        frmPelanggan.WindowState = FormWindowState.Maximized
        frmPelanggan.Show()
    End Sub

    Private Sub BarButtonItem12_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnPemasok.ItemClick
        frmPemasok.MdiParent = Me
        frmPemasok.WindowState = FormWindowState.Maximized
        frmPemasok.Show()
    End Sub

    Private Sub BarButtonItem13_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnBarang.ItemClick
        frmBarang.MdiParent = Me
        frmBarang.WindowState = FormWindowState.Maximized
        frmBarang.Show()
    End Sub

   

    Private Sub BarButtonItem15_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnPembelian.ItemClick
        frmMasterTransaksiPembelian.MdiParent = Me
        frmMasterTransaksiPembelian.WindowState = FormWindowState.Maximized
        frmMasterTransaksiPembelian.Show()
    End Sub

    Private Sub BarButtonItem16_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnPenjualan.ItemClick
        frmMasterTransaksiPenjualan.MdiParent = Me
        frmMasterTransaksiPenjualan.WindowState = FormWindowState.Maximized
        frmMasterTransaksiPenjualan.Show()
    End Sub
    Private Sub BarButtonItem18_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRekapPembelian.ItemClick
        frmLaporanPembelian.MdiParent = Me
        frmLaporanPembelian.WindowState = FormWindowState.Maximized
        frmLaporanPembelian.Show()
    End Sub
    Private Sub RekapanPenjualan_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRekapPenjualan.ItemClick
        frmLaporanPenjualan.MdiParent = Me
        frmLaporanPenjualan.WindowState = FormWindowState.Maximized
        frmLaporanPenjualan.Show()
    End Sub

    Private Sub BarButtonItem20_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnKonfigurasiSistem.ItemClick

        SetupKonfigurasiSitem.ShowDialog()
    End Sub

    Private Sub RibbonControl_Click(sender As Object, e As EventArgs) Handles RibbonControl.Click

    End Sub



    Private Sub btnPengguna_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnPengguna.ItemClick
        frmPengguna.MdiParent = Me
        frmPengguna.WindowState = FormWindowState.Maximized
        frmPengguna.Show()
    End Sub
End Class
