Imports QLGO1DAL
Imports QLGO1DTO
Imports Utility
Public Class PhieuTiepNhanBus
    Private tnDAL As PhieuTiepNhanDAL
    Public Sub New()
        tnDAL = New PhieuTiepNhanDAL()
    End Sub
    Public Sub New(connectionString As String)
        tnDAL = New PhieuTiepNhanDAL(connectionString)
    End Sub

    Public Function insert(tn As PhieuTiepNhanDTO) As Result
        '1. verify data here!!

        '2. insert to DB
        Return tnDAL.insert(tn)
    End Function
    Public Function update(tn As PhieuTiepNhanDTO) As Result
        '1. verify data here!!

        '2. insert to DB
        Return tnDAL.update(tn)
    End Function
    Public Function delete(maPhieuTN As Integer) As Result
        '1. verify data here!!

        '2. insert to DB
        Return tnDAL.delete(maPhieuTN)
    End Function
    Public Function selectAll(ByRef listPhieuTN As List(Of PhieuTiepNhanDTO)) As Result
        '1. verify data here!!

        '2. insert to DB
        Return tnDAL.selectALL(listPhieuTN)
    End Function
    Public Function select_byMaPhieuTN(iMaPhieuTN As Integer, ByRef listPhieuTN As List(Of PhieuTiepNhanDTO)) As Result
        Return tnDAL.select_byMaPhieuTN(iMaPhieuTN, listPhieuTN)
    End Function
    Public Function getNextID(ByRef nextID As Integer) As Result
        Return tnDAL.getNextID(nextID)
    End Function
End Class


