Imports QLGO1DAL
Imports QLGO1DTO
Imports Utility

Public Class HieuXeBus
    Private hxDAL As HieuXeDAL
    Public Sub New()
        hxDAL = New HieuXeDAL()
    End Sub
    Public Sub New(connectionString As String)
        hxDAL = New HieuXeDAL(connectionString)
    End Sub
    Public Function isValidName(hx As HieuXeDTO) As Boolean

        If (hx.TenHX.Length < 1) Then
            Return False
        End If

        Return True

    End Function

    Public Function insert(hx As HieuXeDTO) As Result
        '1. verify data here!!

        '2. insert to DB
        Return hxDAL.insert(hx)
    End Function
    Public Function update(hx As HieuXeDTO) As Result
        '1. verify data here!!

        '2. insert to DB
        Return hxDAL.update(hx)
    End Function
    Public Function delete(maHX As Integer) As Result
        '1. verify data here!!

        '2. insert to DB
        Return hxDAL.delete(maHX)
    End Function
    Public Function selectAll(ByRef listHX As List(Of HieuXeDTO)) As Result
        '1. verify data here!!

        '2. insert to DB
        Return hxDAL.selectALL(listHX)
    End Function
    Public Function select_byMaHX(iMaHX As Integer, ByRef listHX As List(Of HieuXeDTO)) As Result
        Return hxDAL.select_byMaHX(iMaHX, listHX)
    End Function
    Public Function getNextID(ByRef nextID As Integer) As Result
        Return hxDAL.getNextID(nextID)
    End Function
End Class
