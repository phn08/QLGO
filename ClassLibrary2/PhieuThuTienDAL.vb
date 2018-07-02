Imports System.Configuration
Imports System.Data.SqlClient
Imports QLGO1DTO
Imports Utility

Public Class PhieuThuTienDAL
    Private connectionString As String

    Public Sub New()
        ' Read ConnectionString value from App.config file
        connectionString = ConfigurationManager.AppSettings("ConnectionString")
    End Sub
    Public Sub New(ConnectionString As String)
        Me.connectionString = ConnectionString
    End Sub

    Public Function getNextID(ByRef nextID As Integer) As Result

        Dim query As String = String.Empty
        query &= "SELECT TOP 1 [maphieuthutien] "
        query &= "FROM [tblphieuthutien] "
        query &= "ORDER BY [maphieuthutien] DESC "

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
                            idOnDB = reader("maphieuthutien")
                        End While
                    End If
                    ' new ID = current ID + 1
                    nextID = idOnDB + 1
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    nextID = 1
                    Return New Result(False, "Lấy ID kế tiếp của Phiếu Thu Tiền không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function insert(tt As PhieuThuTienDTO) As Result

        Dim query As String = String.Empty
        query &= "INSERT INTO [dbo].[tblphieuthutien] "
        query &= "(  [maphieuthutien] "
        query &= "  ,[maphieutn] "
        query &= "  ,[ngaythutien] "
        query &= "  ,[sotienthu]) "
        query &= "VALUES "
        query &= "(  @maphieuthutien "
        query &= "  ,@maphieutn "
        query &= "  ,@ngaythutien "
        query &= "  ,@sotienthu) "

        Dim nextID = 0
        Dim result As Result
        result = getNextID(nextID)
        If (result.FlagResult = False) Then
            Return result
        End If
        tt.MaPhieuThuTien = nextID

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@maphieuthutien", tt.MaPhieuThuTien)
                    .Parameters.AddWithValue("@maphieutn", tt.MaPhieuTN)
                    .Parameters.AddWithValue("@ngaythutien", tt.NgayThuTien)
                    .Parameters.AddWithValue("@sotienthu", tt.SoTienThu)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Thêm Phiếu Thu Tiền không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function delete(iMaPhieuThuTien As Integer) As Result
        Dim query As String = String.Empty
        query &= " DELETE FROM [dbo].[tblphieuthutien] "
        query &= " WHERE "
        query &= " [maphieuthutien] = @maphieuthutien "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@maphieuthutien", iMaPhieuThuTien)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Xóa Phiếu Thu Tiền không thành công", ex.StackTrace)
                End Try
            End Using
        End Using

        Return New Result(True) ' thanh cong
    End Function

    Public Function select_byMaPhieuThuTien(iMaPhieuThuTien As Integer, listPT As List(Of PhieuThuTienDTO)) As Result

        Dim query As String = String.Empty
        query &= " SELECT [maphieuthutien], [maphieutn], [ngaythutien], [sotienthu]"
        query &= " FROM [tblphieuthutien]"
        query &= " WHERE "
        query &= " [maphieuthutien] = @maphieuthutien"

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@maphieuthutien", iMaPhieuThuTien)
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        listPT.Clear()
                        While reader.Read()
                            listPT.Add(New PhieuThuTienDTO(reader("maphieuthutien"), reader("maphieutn"), reader("ngaythutien"), reader("sotienthu")))
                        End While
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Lấy tất cả Phiếu Thu Tiền không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function selectALL(listPT As List(Of PhieuThuTienDTO)) As Result

        Dim query As String = String.Empty
        query &= " SELECT [maphieuthutien], [maphieutn], [ngaythutien], [sotienthu]"
        query &= " FROM [tblphieuthutien]"

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
                        listPT.Clear()
                        While reader.Read()
                            listPT.Add(New PhieuThuTienDTO(reader("maphieuthutien"), reader("maphieutn"), reader("ngaythutien"), reader("sotienthu")))
                        End While
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Lấy tất cả Phiếu Thu Tiền không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function update(tt As PhieuThuTienDTO) As Result

        Dim query As String = String.Empty
        query &= " UPDATE [tblphieuthutien] SET "
        query &= "   [maphieutn] = @maphieutn "
        query &= "  ,[ngaythutien] = @ngaythutien"
        query &= "  ,[sotienthu] = @sotienthu "
        query &= "WHERE "
        query &= " [maphieuthutien] = @maphieuthutien"

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@maphieutn", tt.MaPhieuTN)
                    .Parameters.AddWithValue("@ngaythutien", tt.NgayThuTien)
                    .Parameters.AddWithValue("@sotienthu", tt.SoTienThu)
                    .Parameters.AddWithValue("@maphieuthutien", tt.MaPhieuThuTien)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Cập nhật Phiếu Thu Tiền không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
End Class
