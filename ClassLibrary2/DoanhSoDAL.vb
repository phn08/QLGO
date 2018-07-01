Imports System.Configuration
Imports System.Data.SqlClient
Imports QLGO1DTO
Imports Utility

Public Class DoanhSoDAL
    Private connectionString As String

    Public Sub New()
        ' Read ConnectionString value from App.config file
        connectionString = ConfigurationManager.AppSettings("ConnectionString")
    End Sub
    Public Sub New(ConnectionString As String)
        Me.connectionString = ConnectionString
    End Sub

    Public Function getNextIDDS(ByRef nextIDDS As Integer) As Result

        Dim query As String = String.Empty
        query &= "SELECT TOP 1 [madoanhsothang] "
        query &= "FROM [tbldoanhso] "
        query &= "ORDER BY [madoanhsothang] DESC "

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
                            idOnDB = reader("madoanhsothang")
                        End While
                    End If
                    ' new ID = current ID + 1
                    nextIDDS = idOnDB + 1
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    nextIDDS = 1
                    Return New Result(False, "Lấy ID kế tiếp của Doanh Số không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function getNextIDTTDS(ByRef nextIDTTDS As Integer) As Result

        Dim query As String = String.Empty
        query &= "SELECT TOP 1 [mattds] "
        query &= "FROM [tbltt_doanhso] "
        query &= "ORDER BY [mattds] DESC "

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
                            idOnDB = reader("mattds")
                        End While
                    End If
                    ' new ID = current ID + 1
                    nextIDTTDS = idOnDB + 1
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    nextIDTTDS = 1
                    Return New Result(False, "Lấy ID kế tiếp của Thông Tin Doanh Số không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function insertDS(ds As DoanhSoDTO) As Result

        Dim query As String = String.Empty
        query &= "INSERT INTO [dbo].[tbldoanhso] "
        query &= "(  [madoanhsothang] "
        query &= "  ,[thang] "
        query &= "  ,[tongdoanhthu]) "
        query &= "VALUES "
        query &= "(   @madoanhsothang"
        query &= "   ,@thang "
        query &= "   ,@tongdoanhthu) "

        Dim nextIDDS = 0
        Dim result As Result
        result = getNextIDDS(nextIDDS)
        If (result.FlagResult = False) Then
            Return result
        End If
        ds.MaDST = nextIDDS

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@madoanhsothang", ds.MaDST)
                    .Parameters.AddWithValue("@thang", ds.Thang)
                    .Parameters.AddWithValue("@tongdoanhthu", ds.TongDoanhThu)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Thêm Doanh Số không thành công", ex.StackTrace)
                End Try
            End Using
        End Using

        'Them Chi tiet chuong trinh
        If (ds.ListTTDS IsNot Nothing And ds.ListTTDS.Count > 0) Then
            For Each ttds In ds.ListTTDS
                ttds.MaDST = ds.MaDST
                result = insertTTDS(ttds)
                If (result.FlagResult = False) Then
                    Return result
                End If
            Next
        End If
        Return New Result(True) ' thanh cong
    End Function

    Public Function insertTTDS(ttds As ThongTinDoanhSoDTO) As Result

        Dim query As String = String.Empty
        query &= "  INSERT INTO [dbo].[tbltt_doanhso] "
        query &= "             ([mattds] "
        query &= "             ,[madoanhsothang] "
        query &= "             ,[mahx] "
        query &= "             ,[soluotsua] "
        query &= "             ,[thanhtien] "
        query &= "             ,[tile]) "
        query &= "       VALUES "
        query &= "             (@mattds "
        query &= "             ,@madoanhsothang "
        query &= "             ,@mahx "
        query &= "             ,@soluotsua "
        query &= "             ,@thanhtien "
        query &= "             ,@tile) "


        Dim nextIDTTDS = 0
        Dim result As Result
        result = getNextIDTTDS(nextIDTTDS)
        If (result.FlagResult = False) Then
            Return result
        End If
        ttds.MaTTDS = nextIDTTDS

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@mattds", ttds.MaTTDS)
                    .Parameters.AddWithValue("@madoanhsothang", ttds.MaDST)
                    .Parameters.AddWithValue("@mahx", ttds.MaHX)
                    .Parameters.AddWithValue("@soluotsua", ttds.SoLuotSua)
                    .Parameters.AddWithValue("@thanhtien", ttds.ThanhTien)
                    .Parameters.AddWithValue("@tile", ttds.TiLe)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Thêm Thông Tin Doanh Số không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function deleteTTDS(ttds As ThongTinDoanhSoDTO) As Result

        Dim query As String = String.Empty
        query &= " DELETE FROM [dbo].[tbltt_doanhso] "
        query &= " WHERE "
        query &= " [mattds] = @mattds "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@mattds", ttds.MaTTDS)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Xóa Thông Tin Doanh Số không thành công", ex.StackTrace)
                End Try
            End Using
        End Using

        Return New Result(True) ' thanh cong
    End Function

    Public Function deleteDS(ds As DoanhSoDTO) As Result

        'Xóa Chi Tiet Chuong Trinh
        If (ds.ListTTDS IsNot Nothing And ds.ListTTDS.Count > 0) Then
            For Each ttds In ds.ListTTDS
                Dim result = deleteTTDS(ttds)
                If (result.FlagResult = False) Then
                    Return result
                End If
            Next
        End If

        Dim query As String = String.Empty
        query &= " DELETE FROM [dbo].[tbldoanhso] "
        query &= " WHERE "
        query &= " [madoanhsothang] = @madoanhsothang "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@madoanhsothang", ds.MaDST)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Xóa Doanh Số không thành công", ex.StackTrace)
                End Try
            End Using
        End Using

        Return New Result(True) ' thanh cong
    End Function

    Public Function select_byMaDST(iMaDST As Integer, listDS As List(Of DoanhSoDTO)) As Result

        Dim query As String = String.Empty
        query &= " SELECT [madoanhsothang], [tongdoanhthu], [thang]"
        query &= " FROM [tbldoanhso]"
        query &= " WHERE "
        query &= " [madoanhsothang] = @madoanhsothang"


        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@madoanhsothang", iMaDST)
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        listDS.Clear()
                        While reader.Read()
                            listDS.Add(New DoanhSoDTO(reader("madoanhsothang"), reader("tongdoanhthu"), reader("thang"), New List(Of ThongTinDoanhSoDTO)))
                        End While
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Lấy tất cả Doanh Số không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        ' select Chi Tiet Chuong Trinh
        For Each ds In listDS
            Dim result = selectALLTTDS_ByMaDST(ds.MaDST, ds.ListTTDS)
            If (result.FlagResult = False) Then
                Return result
            End If
        Next
        Return New Result(True) ' thanh cong
    End Function

    Public Function selectALL(listDS As List(Of DoanhSoDTO)) As Result

        Dim query As String = String.Empty
        query &= " SELECT [madoanhsothang], [tongdoanhthu], [thang]"
        query &= " FROM [tbldoanhso]"


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
                        listDS.Clear()
                        While reader.Read()
                            listDS.Add(New DoanhSoDTO(reader("madoanhsothang"), reader("tongdoanhthu"), reader("thang"), New List(Of ThongTinDoanhSoDTO)))
                        End While
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Lấy tất cả Doanh Số không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        ' select Chi Tiet Chuong Trinh
        For Each ds In listDS
            Dim result = selectALLTTDS_ByMaDST(ds.MaDST, ds.ListTTDS)
            If (result.FlagResult = False) Then
                Return result
            End If
        Next
        Return New Result(True) ' thanh cong
    End Function

    Public Function selectALLTTDS_ByMaDST(iMaDST As Integer, listTTDS As List(Of ThongTinDoanhSoDTO)) As Result

        Dim query As String = String.Empty
        query &= " SELECT [tbltt_doanhso].[mattds], [tblhieuxe].[mahx], [tbltt_doanhso].[madoanhsothang], [tbltt_doanhso].[soluotsua], [tbltt_doanhso].[thanhtien], [tbltt_doanhso].[tile], [tblhieuxe].[tenhx]"
        query &= " FROM [tbltt_doanhso], [tblhieuxe]"
        query &= " WHERE "
        query &= " [tbltt_doanhso].[mahx] = [tblhieuxe].[mahx]"
        query &= " AND [tbltt_doanhso].[madoanhsothang]= @madoanhsothang"

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@madoanhsothang", iMaDST)
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        listTTDS.Clear()
                        While reader.Read()
                            listTTDS.Add(New ThongTinDoanhSoDTO(reader("mattds"), reader("madoanhsothang"), reader("mahx"), reader("soluotsua"), reader("thanhtien"), reader("tile")))
                        End While
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Lấy tất cả Thông Tin Doanh Số không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function updateDS_MasterPart(ds As DoanhSoDTO) As Result

        Dim query As String = String.Empty
        query &= " UPDATE [tbldoanhso] SET "
        query &= " [thang] = @thang, "
        query &= " [tongdoanhthu] = @tongdoanhthu "
        query &= "WHERE "
        query &= " [madoanhsothang] = @madoanhsothang"

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@thang", ds.Thang)
                    .Parameters.AddWithValue("@tongdoanhthu", ds.TongDoanhThu)
                    .Parameters.AddWithValue("@madoanhsothang", ds.MaDST)
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

    Public Function updateDS_Cascade(ds As DoanhSoDTO) As Result

        Dim query As String = String.Empty
        query &= " UPDATE [tbldoanhso] SET"
        query &= " [thang] = @thang, "
        query &= " [tongdoanhthu] = @tongdoanhthu "
        query &= " WHERE "
        query &= " [madoanhsothang] = @madoanhsothang "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@thang", ds.Thang)
                    .Parameters.AddWithValue("@tongdoanhthu", ds.TongDoanhThu)
                    .Parameters.AddWithValue("@madoanhsothang", ds.MaDST)
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
        Dim listTTDSonDB = New List(Of ThongTinDoanhSoDTO)
        Dim result = selectALLTTDS_ByMaDST(ds.MaDST, listTTDSonDB)
        If (result.FlagResult = False) Then
            Return result
        End If
        Dim f = False
        For Each ttdsOnDB In listTTDSonDB
            f = False
            For Each ttds In ds.ListTTDS
                If (ttdsOnDB.MaTTDS = ttds.MaTTDS) Then
                    f = True
                    Exit For
                End If
            Next
            If (f = False) Then ' record on DB is NOT found on GUI  -> Delete
                result = deleteTTDS(ttdsOnDB)
                If (result.FlagResult = False) Then
                    Return result
                End If
            End If
        Next
        f = False
        For Each ttds In ds.ListTTDS
            f = False
            For Each ttdsOnDB In listTTDSonDB
                If (ttds.MaTTDS = ttdsOnDB.MaTTDS) Then
                    f = True
                    Exit For
                End If
            Next
            If (f = False) Then ' record on GUI is NOT found on DB  -> Insert new
                ttds.MaDST = ds.MaDST
                insertTTDS(ttds)
                If (result.FlagResult = False) Then
                    Return result
                End If
            Else ' Updated
                updateTTDS(ttds)
                If (result.FlagResult = False) Then
                    Return result
                End If
            End If
        Next
        Return New Result(True) ' thanh cong
    End Function

    Public Function updateTTDS(ttds As ThongTinDoanhSoDTO) As Result

        Dim query As String = String.Empty
        query &= " UPDATE [tbltt_doanhso] SET"
        query &= " [soluotsua] = @soluotsua, "
        query &= " [thanhtien] = @thanhtien, "
        query &= " [tile] = @tile, "
        query &= " WHERE "
        query &= " [mattds] = @mattds "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@soluotsua", ttds.SoLuotSua)
                    .Parameters.AddWithValue("@thanhtien", ttds.ThanhTien)
                    .Parameters.AddWithValue("@tile", ttds.TiLe)
                    .Parameters.AddWithValue("@mattds", ttds.MaTTDS)
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

