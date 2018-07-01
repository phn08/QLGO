Imports System.Configuration
Imports System.Data.SqlClient
Imports QLGO1DTO
Imports Utility

Public Class BaoCaoTonDAL
    Private connectionString As String

    Public Sub New()
        ' Read ConnectionString value from App.config file
        connectionString = ConfigurationManager.AppSettings("ConnectionString")
    End Sub
    Public Sub New(ConnectionString As String)
        Me.connectionString = ConnectionString
    End Sub

    Public Function getNextIDBC(ByRef nextIDBC As Integer) As Result

        Dim query As String = String.Empty
        query &= "SELECT TOP 1 [mabaocaoton] "
        query &= "FROM [tblbaocaoton] "
        query &= "ORDER BY [mabaocaoton] DESC "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    Dim idOnDB As Integer
                    idOnDB = Nothing
                    If reader.HasRows = True Then
                        While reader.Read()
                            idOnDB = reader("mabaocaoton")
                        End While
                    End If
                    ' new ID = current ID + 1
                    nextIDBC = idOnDB + 1
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    nextIDBC = 1
                    Return New Result(False, "Lấy ID kế tiếp của Báo Cáo Tồn không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function getNextIDTTBC(ByRef nextIDTTBC As Integer) As Result

        Dim query As String = String.Empty
        query &= "SELECT TOP 1 [mattbaocao] "
        query &= "FROM [tbltt_baocaoton] "
        query &= "ORDER BY [mattbaocao] DESC "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    Dim idOnDB As Integer
                    idOnDB = Nothing
                    If reader.HasRows = True Then
                        While reader.Read()
                            idOnDB = reader("mattbaocao")
                        End While
                    End If
                    ' new ID = current ID + 1
                    nextIDTTBC = idOnDB + 1
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    nextIDTTBC = 1
                    Return New Result(False, "Lấy ID kế tiếp của Thông Tin Báo Cáo Tồn không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function insertBC(bc As BaoCaoTonDTO) As Result

        Dim query As String = String.Empty
        query &= "INSERT INTO [dbo].[tblbaocaoton] "
        query &= "(  [mabaocaoton] "
        query &= "  ,[thang]) "
        query &= "VALUES "
        query &= "(   @mabaocaoton"
        query &= "   ,@thang) "

        Dim nextIDBC = 0
        Dim result As Result
        result = getNextIDBC(nextIDBC)
        If (result.FlagResult = False) Then
            Return result
        End If
        bc.MaBCT = nextIDBC

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@mabaocaoton", bc.MaBCT)
                    .Parameters.AddWithValue("@thang", bc.Thang)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Thêm Chương Trình không thành công", ex.StackTrace)
                End Try
            End Using
        End Using

        'Them Chi tiet chuong trinh
        If (bc.ListTTBC IsNot Nothing And bc.ListTTBC.Count > 0) Then
            For Each ttbc In bc.ListTTBC
                ttbc.MaBCT = bc.MaBCT
                result = insertTTBC(ttbc)
                If (result.FlagResult = False) Then
                    Return result
                End If
            Next
        End If
        Return New Result(True) ' thanh cong
    End Function

    Public Function insertTTBC(ttbc As ThongTinBaoCaoTonDTO) As Result

        Dim query As String = String.Empty
        query &= "  INSERT INTO [dbo].[tbltt_baocaoton] "
        query &= "             ([mattbaocao] "
        query &= "             ,[mabaocaoton] "
        query &= "             ,[maphutung] "
        query &= "             ,[tondau] "
        query &= "             ,[phatsinh] "
        query &= "             ,[toncuoi]) "
        query &= "       VALUES "
        query &= "             (@mattbaocao "
        query &= "             ,@mabaocaoton "
        query &= "             ,@maphutung "
        query &= "             ,@tondau "
        query &= "             ,@phatsinh "
        query &= "             ,@toncuoi) "


        Dim nextIDTTBC = 0
        Dim result As Result
        result = getNextIDTTBC(nextIDTTBC)
        If (result.FlagResult = False) Then
            Return result
        End If
        ttbc.MaTTBC = nextIDTTBC

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@mattbaocao", ttbc.MaTTBC)
                    .Parameters.AddWithValue("@mabaocaoton", ttbc.MaBCT)
                    .Parameters.AddWithValue("@maphutung", ttbc.MaPhuTung)
                    .Parameters.AddWithValue("@tondau", ttbc.TonDau)
                    .Parameters.AddWithValue("@phatsinh", ttbc.PhatSinh)
                    .Parameters.AddWithValue("@toncuoi", ttbc.TonCuoi)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Thêm Chi Tiết Chương Trình không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function deleteTTBC(ttbc As ThongTinBaoCaoTonDTO) As Result

        Dim query As String = String.Empty
        query &= " DELETE FROM [dbo].[tbltt_baocaoton] "
        query &= " WHERE "
        query &= " [mattbaocaoton] = @mattbaocaoton "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@mattbaocaoton", ttbc.MaTTBC)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Xóa Thông Tin Báo Cáo Tồn không thành công", ex.StackTrace)
                End Try
            End Using
        End Using

        Return New Result(True) ' thanh cong
    End Function

    Public Function deleteBC(bc As BaoCaoTonDTO) As Result

        'Xóa Chi Tiet Chuong Trinh
        If (bc.ListTTBC IsNot Nothing And bc.ListTTBC.Count > 0) Then
            For Each ttbc In bc.ListTTBC
                Dim result = deleteTTBC(ttbc)
                If (result.FlagResult = False) Then
                    Return result
                End If
            Next
        End If

        Dim query As String = String.Empty
        query &= " DELETE FROM [dbo].[tblbaocaoton] "
        query &= " WHERE "
        query &= " [mabaocaoton] = @mabaocaoton "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@mabaocaoton", bc.MaBCT)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Xóa Báo Cáo Tồn không thành công", ex.StackTrace)
                End Try
            End Using
        End Using

        Return New Result(True) ' thanh cong
    End Function

    Public Function select_byMaBCT(iMaBCT As Integer, listBC As List(Of BaoCaoTonDTO)) As Result

        Dim query As String = String.Empty
        query &= " SELECT [mabaocaoton], [thang]"
        query &= " FROM [tblbaocaoton]"
        query &= " WHERE "
        query &= " [mabaocaoton] = @mabaocaoton"


        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@mabaocaoton", iMaBCT)
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        listBC.Clear()
                        While reader.Read()
                            listBC.Add(New BaoCaoTonDTO(reader("mabaocao"), reader("thang"), New List(Of ThongTinBaoCaoTonDTO)))
                        End While
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Lấy tất cả Báo Cáo không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        ' select Chi Tiet Chuong Trinh
        For Each bc In listBC
            Dim result = selectALLTTBC_ByMaBCT(bc.MaBCT, bc.ListTTBC)
            If (result.FlagResult = False) Then
                Return result
            End If
        Next
        Return New Result(True) ' thanh cong
    End Function

    Public Function selectALL(listBC As List(Of BaoCaoTonDTO)) As Result

        Dim query As String = String.Empty
        query &= " SELECT [mabaocaoton], [thang]"
        query &= " FROM [tblbaocaoton]"


        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        listBC.Clear()
                        While reader.Read()
                            listBC.Add(New BaoCaoTonDTO(reader("mabaocaoton"), reader("thang"), New List(Of ThongTinBaoCaoTonDTO)))
                        End While
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Lấy tất cả Báo Cáo Tồn không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        ' select Chi Tiet Chuong Trinh
        For Each bc In listBC
            Dim result = selectALLTTBC_ByMaBCT(bc.MaBCT, bc.ListTTBC)
            If (result.FlagResult = False) Then
                Return result
            End If
        Next
        Return New Result(True) ' thanh cong
    End Function

    Public Function selectALLTTBC_ByMaBCT(iMaBCT As Integer, listTTBC As List(Of ThongTinBaoCaoTonDTO)) As Result

        Dim query As String = String.Empty
        query &= " SELECT [tbltt_baocaoton].[mattbaocao], [tblphutung].[maphutung], [tbltt_baocaoton].[mabaocaoton], [tbltt_baocaoton].[tondau], [tbltt_baocaoton].[phatsinh], [tbltt_baocaoton].[toncuoi], [tblphutung].[tenphutung]"
        query &= " FROM [tbltt_baocaoton], [tblphutung]"
        query &= " WHERE "
        query &= " [tbltt_baocaoton].[maphutung] = [tblphutung].[maphutung]"
        query &= " AND [tbltt_baocaoton].[mabaocaoton]= @mabaocaoton"

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@mabaocaoton", iMaBCT)
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        listTTBC.Clear()
                        While reader.Read()
                            listTTBC.Add(New ThongTinBaoCaoTonDTO(reader("mattbaocao"), reader("mabaocaoton"), reader("maphutung"), reader("tondau"), reader("phatsinh"), reader("toncuoi")))
                        End While
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Lấy tất cả Thông Tin Báo Cáo Tồn không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function updateBC_MasterPart(bc As BaoCaoTonDTO) As Result

        Dim query As String = String.Empty
        query &= " UPDATE [tblbaocaoton] SET"
        query &= " [thang] = @thang "
        query &= "WHERE "
        query &= " [mabaocaoton] = @mabaocaoton"

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@thang", bc.Thang)
                    .Parameters.AddWithValue("@mabaocaoton", bc.MaBCT)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Cập nhật phần Master của Chương Trình không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function updateBC_Cascade(bc As BaoCaoTonDTO) As Result

        Dim query As String = String.Empty
        query &= " UPDATE [tblbaocaoton] SET"
        query &= " [thang] = @thang "
        query &= " WHERE "
        query &= " [mabaocaoton] = @mabaocaoton "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@thang", bc.Thang)
                    .Parameters.AddWithValue("@mabaocaoton", bc.MaBCT)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Cập nhật phần Master của Chương Trình không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        'Update cascade for Chi Tiết Chương Trình
        Dim listTTBConDB = New List(Of ThongTinBaoCaoTonDTO)
        Dim result = selectALLTTBC_ByMaBCT(bc.MaBCT, listTTBConDB)
        If (result.FlagResult = False) Then
            Return result
        End If
        Dim f = False
        For Each ttbcOnDB In listTTBConDB
            f = False
            For Each ttbc In bc.ListTTBC
                If (ttbcOnDB.MaTTBC = ttbc.MaTTBC) Then
                    f = True
                    Exit For
                End If
            Next
            If (f = False) Then ' record on DB is NOT found on GUI  -> Delete
                result = deleteTTBC(ttbcOnDB)
                If (result.FlagResult = False) Then
                    Return result
                End If
            End If
        Next
        f = False
        For Each ttbc In bc.ListTTBC
            f = False
            For Each ttbcOnDB In listTTBConDB
                If (ttbc.MaTTBC = ttbcOnDB.MaTTBC) Then
                    f = True
                    Exit For
                End If
            Next
            If (f = False) Then ' record on GUI is NOT found on DB  -> Insert new
                ttbc.MaBCT = bc.MaBCT
                insertTTBC(ttbc)
                If (result.FlagResult = False) Then
                    Return result
                End If
            Else ' Updated
                updateTTBC(ttbc)
                If (result.FlagResult = False) Then
                    Return result
                End If
            End If
        Next
        Return New Result(True) ' thanh cong
    End Function

    Public Function updateTTBC(ttbc As ThongTinBaoCaoTonDTO) As Result

        Dim query As String = String.Empty
        query &= " UPDATE [tbltt_baocaoton] SET"
        query &= " [tondau] = @tondau, "
        query &= " [phatsinh] = @phatsinh, "
        query &= " [toncuoi] = @toncuoi, "
        query &= " WHERE "
        query &= " [mattbaocao] = @mattbaocao "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@tondau", ttbc.TonDau)
                    .Parameters.AddWithValue("@phatsinh", ttbc.PhatSinh)
                    .Parameters.AddWithValue("@toncuoi", ttbc.TonCuoi)
                    .Parameters.AddWithValue("@mattbaocao", ttbc.MaTTBC)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Cập nhật Chi Tiết Chương Trình không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
End Class

