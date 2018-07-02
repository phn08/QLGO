
Imports QLGO1DAL
Imports QLGO1DTO
Imports Utility
Public Class PhieuThuTienBus

    Private pttDAL As PhieuThuTienDAL
    Public Sub New()
        pttDAL = New PhieuThuTienDAL()
    End Sub
    Public Sub New(connectionString As String)
        pttDAL = New PhieuThuTienDAL(connectionString)
    End Sub

    Public Function insert(ptt As PhieuThuTienDTO) As Result
        '1. verify data here!!

        '2. insert to DB
        Return pttDAL.insert(ptt)
    End Function
    Public Function update(ptt As PhieuThuTienDTO) As Result
        '1. verify data here!!

        '2. insert to DB
        Return pttDAL.update(ptt)
    End Function
    Public Function delete(maPhieuThuTien As Integer) As Result
        '1. verify data here!!

        '2. insert to DB
        Return pttDAL.delete(maPhieuThuTien)
    End Function
    Public Function selectAll(ByRef listPhieuThuTien As List(Of PhieuThuTienDTO)) As Result
        '1. verify data here!!

        '2. insert to DB
        Return pttDAL.selectALL(listPhieuThuTien)
    End Function
    Public Function select_byMaPhieuThuTien(iMaPhieuThuTien As Integer, ByRef listPhieuThuTien As List(Of PhieuThuTienDTO)) As Result
        Return pttDAL.select_byMaPhieuThuTien(iMaPhieuThuTien, listPhieuThuTien)
    End Function
    Public Function getNextID(ByRef nextID As Integer) As Result
        Return pttDAL.getNextID(nextID)
    End Function
End Class

