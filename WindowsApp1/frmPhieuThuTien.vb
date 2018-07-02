Imports QLGO1BUS
Imports QLGO1DTO
Imports Utility
Imports System.Delegate

Public Class frmPhieuThuTien
    Private pttBus As PhieuThuTienBus
    Private phieuTNBus As PhieuTiepNhanBus
    Private ttxBus As ThongTinXeBus
    Private khBus As KhachHangBus

    Private listKH As List(Of KhachHangDTO)
    Private listTN As List(Of PhieuTiepNhanDTO)
    Private listTTX As List(Of ThongTinXeDTO)
    Private Sub frmPhieuThuTien_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pttBus = New PhieuThuTienBus
        phieuTNBus = New PhieuTiepNhanBus
        ttxBus = New ThongTinXeBus
        khBus = New KhachHangBus
        listTN = New List(Of PhieuTiepNhanDTO)
        Dim result = phieuTNBus.selectAll(listTN)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách Phiếu Tiếp Nhận không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Me.BeginInvoke(New MethodInvoker(AddressOf Close))
            Return
        End If
        listKH = New List(Of KhachHangDTO)
        result = khBus.selectAll(listKH)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách Khách Hàng không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Me.BeginInvoke(New MethodInvoker(AddressOf Close))
            Return
        End If
        listTTX = New List(Of ThongTinXeDTO)
        result = ttxBus.selectAll(listTTX)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách Thông Tin Xe không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Me.BeginInvoke(New MethodInvoker(AddressOf Close))
            Return
        End If
        cbTN.DataSource = New BindingSource(listTN, String.Empty)
        cbTN.DisplayMember = "MaPhieuTN"
        cbTN.ValueMember = "MaPhieuTN"
    End Sub

    Private Sub cbTN_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTN.SelectedIndexChanged
        Dim listChk As List(Of ThongTinXeDTO) = listTTX
        Dim listChk2 As List(Of KhachHangDTO) = listKH
        ttxBus.select_byMaTTXe(listTN.Item(cbTN.SelectedValue).MaTTXe, listChk)
        khBus.select_byMaKH(listChk.Item(0).MaKH, listChk2)
        tbBienSo.Text = listChk.Item(0).BienSo
        tbKH.Text = listChk2.Item(0).TenKH
        tbPhone.Text = listChk2.Item(0).DienThoai
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim i As Integer
        pttBus.getNextID(i)
        pttBus.insert(New PhieuThuTienDTO(i, cbTN.SelectedValue, Integer.Parse(tbSoTien.Text), dtpNgayThuTien.Value))
    End Sub
End Class