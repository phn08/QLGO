Imports QLGO1BUS
Imports QLGO1DTO
Imports Utility
Imports System.Delegate

Public Class frmTiepNhanXeSua
    Private phieuTNBus As PhieuTiepNhanBus
    Private ttxBus As ThongTinXeBus
    Private khBus As KhachHangBus
    Private hxBus As HieuXeBus

    Private listHX As List(Of HieuXeDTO)
    Private listKH As List(Of KhachHangDTO)

    Private Sub frmTiepNhanXeSua_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        phieuTNBus = New PhieuTiepNhanBus
        ttxBus = New ThongTinXeBus
        khBus = New KhachHangBus
        hxBus = New HieuXeBus

        listHX = New List(Of HieuXeDTO)
        Dim result = hxBus.selectAll(listHX)
        If (Result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách Hiệu Xe không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(Result.SystemMessage)
            Me.BeginInvoke(New MethodInvoker(AddressOf Close))
            Return
        End If
        listKH = New List(Of KhachHangDTO)
        result = khBus.selectAll(listKH)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách Hiệu Xe không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Me.BeginInvoke(New MethodInvoker(AddressOf Close))
            Return
        End If
        dtpNgayNhan.Value = DateTime.Now
        cbHX.DataSource = New BindingSource(listHX, String.Empty)
        cbHX.DisplayMember = "TenHX"
        cbHX.ValueMember = "MaHX"
        cbKH.DataSource = New BindingSource(listKH, String.Empty)
        cbKH.DisplayMember = "TenKH"
        cbKH.ValueMember = "MaKH"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ttxDTO As ThongTinXeDTO
        ttxDTO = New ThongTinXeDTO
        ttxDTO.BienSo = tbBienSo.Text
        Dim checkname As String
        checkname = cbKH.FindString(cbKH.Text)
        If (checkname <= -1) Then
            Dim khDTO As KhachHangDTO
            khDTO = New KhachHangDTO
            khBus.getNextID(khDTO.MaKH)
            khDTO.TenKH = cbKH.Text
            khDTO.DiaChi = tbDiaChi.Text
            khDTO.DienThoai = tbPhone.Text
            listKH.Add(khDTO)
            khBus.insert(khDTO)
            ttxDTO.MaKH = khDTO.MaKH
        Else
            ttxDTO.MaKH = cbKH.SelectedValue
        End If
        ttxBus.getNextID(ttxDTO.MaTTXe)
        ttxDTO.MaHX = cbHX.SelectedValue
        ttxDTO.BienSo = tbBienSo.Text
        ttxBus.insert(ttxDTO)
        Dim i As Integer
        phieuTNBus.getNextID(i)
        phieuTNBus.insert(New PhieuTiepNhanDTO(i, ttxDTO.MaTTXe, dtpNgayNhan.Value))
    End Sub
End Class
