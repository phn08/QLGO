Imports System.Configuration

Public Class frmHome
    Private Sub PhiếuTiếpNhậnXeSửaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PhiếuTiếpNhậnXeSửaToolStripMenuItem.Click
        Dim frm As frmTiepNhanXeSua
        frm = New frmTiepNhanXeSua()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub PhiếuThuTiềnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PhiếuThuTiềnToolStripMenuItem.Click
        Dim frm As frmPhieuThuTien
        frm = New frmPhieuThuTien()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub PhiếuSửaChữaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PhiếuSửaChữaToolStripMenuItem.Click
        Dim frm As frmPhieuSuaChua
        frm = New frmPhieuSuaChua()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub DanhSáchXeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DanhSáchXeToolStripMenuItem.Click
        Dim frm As frmDanhSachXe
        frm = New frmDanhSachXe()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub BáoCáoTồnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BáoCáoTồnToolStripMenuItem.Click
        Dim frm As frmBaoCaoTon
        frm = New frmBaoCaoTon()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub DoanhSốToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DoanhSốToolStripMenuItem.Click
        Dim frm As frmBaoCaoDoanhSo
        frm = New frmBaoCaoDoanhSo()
        frm.MdiParent = Me
        frm.Show()
    End Sub
End Class