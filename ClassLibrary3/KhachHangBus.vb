Imports QLGO1DAL
Imports QLGO1DTO
Imports Utility

Public Class KhachHangBus
    Private khDAL As KhachHangDAL
    Public Sub New()
        khDAL = New KhachHangDAL()
    End Sub
    Public Sub New(connectionString As String)
        khDAL = New KhachHangDAL(connectionString)
    End Sub
    Public Function isValidName(kh As KhachHangDTO) As Boolean

        If (kh.TenKH.Length < 1) Then
            Return False
        End If

        Return True

    End Function

    Public Function insert(kh As KhachHangDTO) As Result
        '1. verify data here!!

        '2. insert to DB
        Return khDAL.insert(kh)
    End Function
    Public Function update(kh As KhachHangDTO) As Result
        '1. verify data here!!

        '2. insert to DB
        Return khDAL.update(kh)
    End Function
    Public Function delete(maKH As Integer) As Result
        '1. verify data here!!

        '2. insert to DB
        Return khDAL.delete(maKH)
    End Function
    Public Function selectAll(ByRef listHX As List(Of KhachHangDTO)) As Result
        '1. verify data here!!

        '2. insert to DB
        Return khDAL.selectALL(listHX)
    End Function

    Public Function select_byMaKH(iMaKH As Integer, ByRef listKH As List(Of KhachHangDTO)) As Result
        Return khDAL.select_byMaKH(iMaKH, listKH)
    End Function
    Public Function getNextID(ByRef nextID As Integer) As Result
        Return khDAL.getNextID(nextID)
    End Function
End Class
