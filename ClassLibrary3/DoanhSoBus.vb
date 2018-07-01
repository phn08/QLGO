Imports QLGO1DAL
Imports QLGO1DTO
Imports Utility
Public Class DoanhSoBus
    Private dsDAL As DoanhSoDAL
    Public Sub New()
        dsDAL = New DoanhSoDAL()
    End Sub
    Public Sub New(connectionString As String)
        dsDAL = New DoanhSoDAL(connectionString)
    End Sub

    Public Function insertDS(sc As DoanhSoDTO) As Result

        Return dsDAL.insertDS(sc)

    End Function

    Public Function insertTTDS(ttds As ThongTinDoanhSoDTO) As Result
        Return dsDAL.insertTTDS(ttds)
    End Function

    Public Function deleteTTDS(ttds As ThongTinDoanhSoDTO) As Result
        Return dsDAL.deleteTTDS(ttds)
    End Function

    Public Function deleteDS(sc As DoanhSoDTO) As Result

        Return dsDAL.deleteDS(sc)
    End Function

    Public Function select_byMaDST(iMaDST As Integer, listDS As List(Of DoanhSoDTO)) As Result
        Return dsDAL.select_byMaDST(iMaDST, listDS)
    End Function

    Public Function selectALL(listDS As List(Of DoanhSoDTO)) As Result

        Return dsDAL.selectALL(listDS)
    End Function

    Public Function selectALLTTDS_ByMaDST(iMaDST As Integer, listTTDS As List(Of ThongTinDoanhSoDTO)) As Result

        Return dsDAL.selectALLTTDS_ByMaDST(iMaDST, listTTDS)
    End Function

    Public Function updateDS_MasterPart(sc As DoanhSoDTO) As Result
        Return dsDAL.updateDS_MasterPart(sc)

    End Function

    Public Function updateDS_Cascade(sc As DoanhSoDTO) As Result

        Return dsDAL.updateDS_Cascade(sc)
    End Function

    Public Function updateTTDS(ttds As ThongTinDoanhSoDTO) As Result

        Return dsDAL.updateTTDS(ttds)
    End Function
End Class