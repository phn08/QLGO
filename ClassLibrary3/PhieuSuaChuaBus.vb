Imports QLGO1DAL
Imports QLGO1DTO
Imports Utility
Public Class PhieuSuaChuaBus
    Private scDAL As PhieuSuaChuaDAL
    Public Sub New()
        scDAL = New PhieuSuaChuaDAL()
    End Sub
    Public Sub New(connectionString As String)
        scDAL = New PhieuSuaChuaDAL(connectionString)
    End Sub

    Public Function insertSC(sc As PhieuSuaChuaDTO) As Result

        Return scDAL.insertSC(sc)

    End Function

    Public Function insertTTSC(ttsc As ThongTinPhieuSuaChuaDTO) As Result
        Return scDAL.insertTTSC(ttsc)
    End Function

    Public Function deleteTTSC(ttsc As ThongTinPhieuSuaChuaDTO) As Result
        Return scDAL.deleteTTSC(ttsc)
    End Function

    Public Function deleteSC(sc As PhieuSuaChuaDTO) As Result

        Return scDAL.deleteSC(sc)
    End Function

    Public Function select_byMaPhieuSC(iMaPhieuSC As Integer, listSC As List(Of PhieuSuaChuaDTO)) As Result
        Return scDAL.select_byMaPhieuSC(iMaPhieuSC, listSC)
    End Function

    Public Function selectALL(listSC As List(Of PhieuSuaChuaDTO)) As Result

        Return scDAL.selectALL(listSC)
    End Function

    Public Function selectALLTTSC_ByMaPhieuSC(iMaPhieuSC As Integer, listTTSC As List(Of ThongTinPhieuSuaChuaDTO)) As Result

        Return scDAL.selectALLTTSC_ByMaPhieuSC(iMaPhieuSC, listTTSC)
    End Function

    Public Function updateSC_MasterPart(sc As PhieuSuaChuaDTO) As Result
        Return scDAL.updateSC_MasterPart(sc)

    End Function

    Public Function updateSC_Cascade(sc As PhieuSuaChuaDTO) As Result

        Return scDAL.updateSC_Cascade(sc)
    End Function

    Public Function updateTTSC(ttsc As ThongTinPhieuSuaChuaDTO) As Result

        Return scDAL.updateTTSC(ttsc)
    End Function
End Class
