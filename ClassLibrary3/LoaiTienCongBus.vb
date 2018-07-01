Imports QLGO1DAL
Imports QLGO1DTO
Imports Utility

Public Class LoaiTienCongBus
    Private tcDAL As LoaiTienCongDAL
    Public Sub New()
        tcDAL = New LoaiTienCongDAL()
    End Sub
    Public Sub New(connectionString As String)
        tcDAL = New LoaiTienCongDAL(connectionString)
    End Sub
    Public Function isValidName(tc As LoaiTienCongDTO) As Boolean

        If (tc.TenLoaiTienCong.Length < 1) Then
            Return False
        End If

        Return True

    End Function

    Public Function insert(tc As LoaiTienCongDTO) As Result
        '1. verify data here!!

        '2. insert to DB
        Return tcDAL.insert(tc)
    End Function
    Public Function update(tc As LoaiTienCongDTO) As Result
        '1. verify data here!!

        '2. insert to DB
        Return tcDAL.update(tc)
    End Function
    Public Function delete(maTienCong As Integer) As Result
        '1. verify data here!!

        '2. insert to DB
        Return tcDAL.delete(maTienCong)
    End Function
    Public Function selectAll(ByRef listHX As List(Of LoaiTienCongDTO)) As Result
        '1. verify data here!!

        '2. insert to DB
        Return tcDAL.selectALL(listHX)
    End Function

    Public Function select_byMaTienCong(iMaTienCong As Integer, ByRef listKH As List(Of LoaiTienCongDTO)) As Result
        Return tcDAL.select_byMaTienCong(iMaTienCong, listKH)
    End Function
    Public Function getNextID(ByRef nextID As Integer) As Result
        Return tcDAL.getNextID(nextID)
    End Function
End Class
