Imports QLGO1DAL
Imports QLGO1DTO
Imports Utility
Public Class ThongTinXeBus
    Private ttxDAL As ThongTinXeDAL
    Public Sub New()
        ttxDAL = New ThongTinXeDAL()
    End Sub
    Public Sub New(connectionString As String)
        ttxDAL = New ThongTinXeDAL(connectionString)
    End Sub

    Public Function insert(ttx As ThongTinXeDTO) As Result
        '1. verify data here!!

        '2. insert to DB
        Return ttxDAL.insert(ttx)
    End Function
    Public Function update(ttx As ThongTinXeDTO) As Result
        '1. verify data here!!

        '2. insert to DB
        Return ttxDAL.update(ttx)
    End Function
    Public Function delete(maTTXe As Integer) As Result
        '1. verify data here!!

        '2. insert to DB
        Return ttxDAL.delete(maTTXe)
    End Function
    Public Function selectAll(ByRef listTTXe As List(Of ThongTinXeDTO)) As Result
        '1. verify data here!!

        '2. insert to DB
        Return ttxDAL.selectALL(listTTXe)
    End Function
    Public Function select_byMaTTXe(iMaTTXe As Integer, ByRef listTTXe As List(Of ThongTinXeDTO)) As Result
        Return ttxDAL.select_byMaTTXe(iMaTTXe, listTTXe)
    End Function
    Public Function getNextID(ByRef nextID As Integer) As Result
        Return ttxDAL.getNextID(nextID)
    End Function
End Class