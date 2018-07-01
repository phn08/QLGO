Imports System.Configuration
Imports System.Data.SqlClient
Imports QLGO1DTO
Imports Utility

Public Class PhieuSuaChuaDAL
    Private connectionString As String

    Public Sub New()
        ' Read ConnectionString value from App.config file
        connectionString = ConfigurationManager.AppSettings("ConnectionString")
    End Sub
    Public Sub New(ConnectionString As String)
        Me.connectionString = ConnectionString
    End Sub

    Public Function getNextIDSC(ByRef nextIDSC As Integer) As Result

        Dim query As String = String.Empty
        query &= "SELECT TOP 1 [maphieusc] "
        query &= "FROM [tblphieusuachua] "
        query &= "ORDER BY [maphieusc] DESC "

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
                            idOnDB = reader("maphieusc")
                        End While
                    End If
                    ' new ID = current ID + 1
                    nextIDSC = idOnDB + 1
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    nextIDSC = 1
                    Return New Result(False, "Lấy ID kế tiếp của Phiếu Sửa Chữa không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function getNextIDTTSC(ByRef nextIDTTSC As Integer) As Result

        Dim query As String = String.Empty
        query &= "SELECT TOP 1 [mattphieusc] "
        query &= "FROM [tbltt_phieusuachua] "
        query &= "ORDER BY [mattphieusc] DESC "

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
                            idOnDB = reader("mattphieusc")
                        End While
                    End If
                    ' new ID = current ID + 1
                    nextIDTTSC = idOnDB + 1
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    nextIDTTSC = 1
                    Return New Result(False, "Lấy ID kế tiếp của Thông Tin Phiếu Sửa Chữa không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function insertSC(sc As PhieuSuaChuaDTO) As Result

        Dim query As String = String.Empty
        query &= "INSERT INTO [dbo].[tblphieusuachua] "
        query &= "(  [maphieusc] "
        query &= "  ,[maphieutn] "
        query &= "  ,[ngaysc]) "
        query &= "VALUES "
        query &= "(   @maphieusc"
        query &= "   ,@maphieutn "
        query &= "   ,@ngaysc) "

        Dim nextIDSC = 0
        Dim result As Result
        result = getNextIDSC(nextIDSC)
        If (result.FlagResult = False) Then
            Return result
        End If
        sc.MaPhieuSC = nextIDSC

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@maphieusc", sc.MaPhieuSC)
                    .Parameters.AddWithValue("@maphieutn", sc.MaPhieuTN)
                    .Parameters.AddWithValue("@ngaysc", sc.NgaySC)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Thêm Phiếu Sửa Chữa không thành công", ex.StackTrace)
                End Try
            End Using
        End Using

        'Them Chi tiet chuong trinh
        If (sc.ListTTSC IsNot Nothing And sc.ListTTSC.Count > 0) Then
            For Each ttsc In sc.ListTTSC
                ttsc.MaPhieuSC = sc.MaPhieuSC
                result = insertTTSC(ttsc)
                If (result.FlagResult = False) Then
                    Return result
                End If
            Next
        End If
        Return New Result(True) ' thanh cong
    End Function

    Public Function insertTTSC(ttsc As ThongTinPhieuSuaChuaDTO) As Result

        Dim query As String = String.Empty
        query &= "  INSERT INTO [dbo].[tbltt_phieusuachua] "
        query &= "             ([mattphieusc], "
        query &= "              [maphieusc],"
        query &= "              [maphutung], "
        query &= "              [noidung], "
        query &= "              [soluong], "
        query &= "              [matiencong]) "
        query &= "       VALUES "
        query &= "             (@mattphieusc "
        query &= "             ,@maphieusc "
        query &= "             ,@maphutung "
        query &= "             ,@noidung "
        query &= "             ,@soluong "
        query &= "             ,@matiencong) "


        Dim nextIDTTSC = 0
        Dim result As Result
        result = getNextIDTTSC(nextIDTTSC)
        If (result.FlagResult = False) Then
            Return result
        End If
        ttsc.MaTTPSC = nextIDTTSC

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@mattphieusc", ttsc.MaTTPSC)
                    .Parameters.AddWithValue("@maphieusc", ttsc.MaPhieuSC)
                    .Parameters.AddWithValue("@maphutung", ttsc.MaPhuTung)
                    .Parameters.AddWithValue("@noidung", ttsc.NoiDung)
                    .Parameters.AddWithValue("@soluong", ttsc.SoLuong)
                    .Parameters.AddWithValue("@matiencong", ttsc.MaTienCong)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Thêm Thông Tin Phiếu Sửa Chữa không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function deleteTTSC(ttsc As ThongTinPhieuSuaChuaDTO) As Result

        Dim query As String = String.Empty
        query &= " DELETE FROM [dbo].[tbltt_phieusuachua] "
        query &= " WHERE "
        query &= " [mattphieusc] = @mattphieusc "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@mattphieusc", ttsc.MaTTPSC)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Xóa Thông Tin Phiếu Sửa Chữa không thành công", ex.StackTrace)
                End Try
            End Using
        End Using

        Return New Result(True) ' thanh cong
    End Function

    Public Function deleteSC(sc As PhieuSuaChuaDTO) As Result

        'Xóa Chi Tiet Chuong Trinh
        If (sc.ListTTSC IsNot Nothing And sc.ListTTSC.Count > 0) Then
            For Each ttsc In sc.ListTTSC
                Dim result = deleteTTSC(ttsc)
                If (result.FlagResult = False) Then
                    Return result
                End If
            Next
        End If

        Dim query As String = String.Empty
        query &= " DELETE FROM [dbo].[tblphieusuachua] "
        query &= " WHERE "
        query &= " [maphieusc] = @maphieusc "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@maphieusc", sc.MaPhieuSC)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Xóa Phiếu Sửa Chữa không thành công", ex.StackTrace)
                End Try
            End Using
        End Using

        Return New Result(True) ' thanh cong
    End Function

    Public Function select_byMaPhieuSC(iMaPhieuSC As Integer, listSC As List(Of PhieuSuaChuaDTO)) As Result

        Dim query As String = String.Empty
        query &= " SELECT [maphieusc], [maphieutn], [ngaysc]"
        query &= " FROM [tblphieusuachua]"
        query &= " WHERE "
        query &= " [maphieusc] = @maphieusc"


        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@maphieusc", iMaPhieuSC)
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        listSC.Clear()
                        While reader.Read()
                            listSC.Add(New PhieuSuaChuaDTO(reader("maphieusc"), reader("maphieutn"), reader("ngaysc"), New List(Of ThongTinPhieuSuaChuaDTO)))
                        End While
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Lấy tất cả Phiếu Sửa Chữa không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        ' select Chi Tiet Chuong Trinh
        For Each sc In listSC
            Dim result = selectALLTTSC_ByMaPhieuSC(sc.MaPhieuSC, sc.ListTTSC)
            If (result.FlagResult = False) Then
                Return result
            End If
        Next
        Return New Result(True) ' thanh cong
    End Function

    Public Function selectALL(listSC As List(Of PhieuSuaChuaDTO)) As Result

        Dim query As String = String.Empty
        query &= " SELECT [maphieusc], [maphieutn], [ngaysc]"
        query &= " FROM [tblphieusuachua]"


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
                        listSC.Clear()
                        While reader.Read()
                            listSC.Add(New PhieuSuaChuaDTO(reader("maphieusc"), reader("maphieutn"), reader("ngaysc"), New List(Of ThongTinPhieuSuaChuaDTO)))
                        End While
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Lấy tất cả Phiếu Sửa Chữa không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        ' select Chi Tiet Chuong Trinh
        For Each sc In listSC
            Dim result = selectALLTTSC_ByMaPhieuSC(sc.MaPhieuSC, sc.ListTTSC)
            If (result.FlagResult = False) Then
                Return result
            End If
        Next
        Return New Result(True) ' thanh cong
    End Function

    Public Function selectALLTTSC_ByMaPhieuSC(iMaPhieuSC As Integer, listTTSC As List(Of ThongTinPhieuSuaChuaDTO)) As Result

        Dim query As String = String.Empty
        query &= " SELECT [tbltt_phieusuachua].[mattphieusc], [tbltt_phieusuachua].[maphieusc], [tbltt_phieusuachua].[maphutung], [tblhieuxe].[mahx], [tbltt_phieusuachua].[maphieusc], [tbltt_phieusuachua].[soluotsua], [tbltt_phieusuachua].[thanhtien], [tbltt_phieusuachua].[tile], [tblhieuxe].[tenhx]"
        query &= " FROM [tbltt_phieusuachua], [tblhieuxe]"
        query &= " WHERE "
        query &= " [tbltt_phieusuachua].[mahx] = [tblhieuxe].[mahx]"
        query &= " AND [tbltt_phieusuachua].[maphieusc]= @maphieusc"

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@maphieusc", iMaPhieuSC)
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        listTTSC.Clear()
                        While reader.Read()
                            listTTSC.Add(New ThongTinPhieuSuaChuaDTO(reader("mattphieusc"), reader("maphieusc"), reader("mahx"), reader("soluotsua"), reader("thanhtien"), reader("tile")))
                        End While
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Lấy tất cả Thông Tin Phiếu Sửa Chữa không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function updateSC_MasterPart(sc As PhieuSuaChuaDTO) As Result

        Dim query As String = String.Empty
        query &= " UPDATE [tblphieusuachua] SET"
        query &= " [ngaysc] = @ngaysc "
        query &= " WHERE "
        query &= " [maphieusc] = @maphieusc "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@ngaysc", sc.NgaySC)
                    .Parameters.AddWithValue("@maphieusc", sc.MaPhieuSC)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Cập nhật phần Master của Phiếu Sửa Chữa không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function updateSC_Cascade(sc As PhieuSuaChuaDTO) As Result

        Dim query As String = String.Empty
        query &= " UPDATE [tblphieusuachua] SET"
        query &= " [ngaysc] = @ngaysc "
        query &= " WHERE "
        query &= " [maphieusc] = @maphieusc "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@ngaysc", sc.NgaySC)
                    .Parameters.AddWithValue("@maphieusc", sc.MaPhieuSC)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Cập nhật phần Master của Phiếu Sửa Chữa không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        'Update cascade for Chi Tiết Chương Trình
        Dim listTTSConDB = New List(Of ThongTinPhieuSuaChuaDTO)
        Dim result = selectALLTTSC_ByMaPhieuSC(sc.MaPhieuSC, listTTSConDB)
        If (result.FlagResult = False) Then
            Return result
        End If
        Dim f = False
        For Each ttscOnDB In listTTSConDB
            f = False
            For Each ttsc In sc.ListTTSC
                If (ttscOnDB.MaTTPSC = ttsc.MaTTPSC) Then
                    f = True
                    Exit For
                End If
            Next
            If (f = False) Then ' record on DB is NOT found on GUI  -> Delete
                result = deleteTTSC(ttscOnDB)
                If (result.FlagResult = False) Then
                    Return result
                End If
            End If
        Next
        f = False
        For Each ttsc In sc.ListTTSC
            f = False
            For Each ttscOnDB In listTTSConDB
                If (ttsc.MaTTPSC = ttscOnDB.MaTTPSC) Then
                    f = True
                    Exit For
                End If
            Next
            If (f = False) Then ' record on GUI is NOT found on DB  -> Insert new
                ttsc.MaPhieuSC = sc.MaPhieuSC
                insertTTSC(ttsc)
                If (result.FlagResult = False) Then
                    Return result
                End If
            Else ' Updated
                updateTTSC(ttsc)
                If (result.FlagResult = False) Then
                    Return result
                End If
            End If
        Next
        Return New Result(True) ' thanh cong
    End Function

    Public Function updateTTSC(ttsc As ThongTinPhieuSuaChuaDTO) As Result

        Dim query As String = String.Empty
        query &= " UPDATE [tbltt_phieusuachua] SET"
        query &= " [noidung] = @noidung, "
        query &= " [soluong] = @soluong, "
        query &= " WHERE "
        query &= " [mattphieusc] = @mattphieusc "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@noidung", ttsc.NoiDung)
                    .Parameters.AddWithValue("@soluong", ttsc.SoLuong)
                    .Parameters.AddWithValue("@mattphieusc", ttsc.MaTTPSC)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Cập nhật Thông Tin Phiếu Sửa Chữa không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
End Class

