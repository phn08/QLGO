Imports QLGO1DAL
Imports QLGO1DTO
Imports Utility
Public Class BaoCaoTonBus
    Private bcDAL As BaoCaoTonDAL
    Public Sub New()
        bcDAL = New BaoCaoTonDAL()
    End Sub
    Public Sub New(connectionString As String)
        bcDAL = New BaoCaoTonDAL(connectionString)
    End Sub

    Public Function insertBC(ct As BaoCaoTonDTO) As Result

        Return bcDAL.insertBC(ct)

    End Function

    Public Function insertTTBC(ctct As ThongTinBaoCaoTonDTO) As Result
        Return bcDAL.insertTTBC(ctct)
    End Function

    Public Function deleteTTBC(ctct As ThongTinBaoCaoTonDTO) As Result
        Return bcDAL.deleteTTBC(ctct)
    End Function

    Public Function deleteBC(ct As BaoCaoTonDTO) As Result

        Return bcDAL.deleteBC(ct)
    End Function

    Public Function select_byMaBCT(iMaBCT As Integer, listBC As List(Of BaoCaoTonDTO)) As Result
        Return bcDAL.select_byMaBCT(iMaBCT, listBC)
    End Function

    Public Function selectALL(listBC As List(Of BaoCaoTonDTO)) As Result

        Return bcDAL.selectALL(listBC)
    End Function

    Public Function selectALLTTBC_ByMaBCT(iMaBCT As Integer, listTTBC As List(Of ThongTinBaoCaoTonDTO)) As Result

        Return bcDAL.selectALLTTBC_ByMaBCT(iMaBCT, listTTBC)
    End Function

    Public Function updateBC_MasterPart(ct As BaoCaoTonDTO) As Result
        Return bcDAL.updateBC_MasterPart(ct)

    End Function

    Public Function updateBC_Cascade(ct As BaoCaoTonDTO) As Result

        Return bcDAL.updateBC_Cascade(ct)
    End Function

    Public Function updateTTBC(ctct As ThongTinBaoCaoTonDTO) As Result

        Return bcDAL.updateTTBC(ctct)
    End Function
End Class
