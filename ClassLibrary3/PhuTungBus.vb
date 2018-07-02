Imports QLGO1DAL
Imports QLGO1DTO
Imports Utility
Public Class PhuTungBus
    Private ptDAL As PhuTungDAL
    Public Sub New()
        ptDAL = New PhuTungDAL()
    End Sub
    Public Sub New(connectionString As String)
        ptDAL = New PhuTungDAL(connectionString)
    End Sub

    Public Function insert(pt As PhuTungDTO) As Result
        '1. verify data here!!

        '2. insert to DB
        Return ptDAL.insert(pt)
    End Function
    Public Function update(pt As PhuTungDTO) As Result
        '1. verify data here!!

        '2. insert to DB
        Return ptDAL.update(pt)
    End Function
    Public Function delete(maPhuTung As Integer) As Result
        '1. verify data here!!

        '2. insert to DB
        Return ptDAL.delete(maPhuTung)
    End Function
    Public Function selectAll(ByRef listPhuTung As List(Of PhuTungDTO)) As Result
        '1. verify data here!!

        '2. insert to DB
        Return ptDAL.selectALL(listPhuTung)
    End Function
    Public Function select_byMaPhuTung(iMaPhuTung As Integer, ByRef listPhuTung As List(Of PhuTungDTO)) As Result
        Return ptDAL.select_byMaPhuTung(iMaPhuTung, listPhuTung)
    End Function
    Public Function getNextID(ByRef nextID As Integer) As Result
        Return ptDAL.getNextID(nextID)
    End Function
End Class



