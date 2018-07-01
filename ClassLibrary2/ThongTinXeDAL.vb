Imports System.Configuration
Imports System.Data.SqlClient
Imports QLGO1DTO
Imports Utility

Public Class ThongTinXeDAL
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
        query &= "SELECT TOP 1 [mattxe] "
        query &= "FROM [tbltt_xe] "
        query &= "ORDER BY [mattxe] DESC "

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
                            idOnDB = reader("mattxe")
                        End While
                    End If
                    ' new ID = current ID + 1
                    nextID = idOnDB + 1
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    nextID = 1
                    Return New Result(False, "Lấy ID kế tiếp của Phụ Tùng không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function insert(ttx As ThongTinXeDTO) As Result

        Dim query As String = String.Empty
        query &= "INSERT INTO [dbo].[tbltt_xe] "
        query &= "(  [mattxe] "
        query &= "  ,[makh] "
        query &= "  ,[mahx] "
        query &= "  ,[bienso]) "
        query &= "VALUES "
        query &= "(  @mattxe "
        query &= "  ,@makh "
        query &= "  ,@mahx "
        query &= "  ,@bienso) "

        Dim nextID = 0
        Dim result As Result
        result = getNextID(nextID)
        If (result.FlagResult = False) Then
            Return result
        End If
        ttx.MaTTXe = nextID

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@mattxe", ttx.MaTTXe)
                    .Parameters.AddWithValue("@makh", ttx.MaKH)
                    .Parameters.AddWithValue("@mahx", ttx.MaHX)
                    .Parameters.AddWithValue("@bienso", ttx.BienSo)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Thêm Phụ Tùng không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function delete(iMaTTXe As Integer) As Result
        Dim query As String = String.Empty
        query &= " DELETE FROM [dbo].[tbltt_xe] "
        query &= " WHERE "
        query &= " [mattxe] = @mattxe "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@mattxe", iMaTTXe)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Xóa Phụ Tùng không thành công", ex.StackTrace)
                End Try
            End Using
        End Using

        Return New Result(True) ' thanh cong
    End Function

    Public Function select_byMaTTXe(iMaTTXe As Integer, listPT As List(Of ThongTinXeDTO)) As Result

        Dim query As String = String.Empty
        query &= " SELECT [mattxe], [makh], [mahx], [bienso]"
        query &= " FROM [tbltt_xe]"
        query &= " WHERE "
        query &= " [mattxe] = @mattxe"

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@mattxe", iMaTTXe)
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        listPT.Clear()
                        While reader.Read()
                            listPT.Add(New ThongTinXeDTO(reader("mattxe"), reader("makh"), reader("mahx"), reader("bienso")))
                        End While
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Lấy tất cả Phụ Tùng không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function selectALL(listPT As List(Of ThongTinXeDTO)) As Result

        Dim query As String = String.Empty
        query &= " SELECT [mattxe], [makh], [mahx], [bienso]"
        query &= " FROM [tbltt_xe]"

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
                            listPT.Add(New ThongTinXeDTO(reader("mattxe"), reader("makh"), reader("mahx"), reader("bienso")))
                        End While
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Lấy tất cả Phụ Tùng không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function update(ttx As ThongTinXeDTO) As Result

        Dim query As String = String.Empty
        query &= " UPDATE [tbltt_xe] SET "
        query &= "   [makh] = @makh "
        query &= "  ,[mahx] = @mahx"
        query &= "  ,[bienso] = @bienso "
        query &= "WHERE "
        query &= " [mattxe] = @mattxe"

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@makh", ttx.MaKH)
                    .Parameters.AddWithValue("@mahx", ttx.MaHX)
                    .Parameters.AddWithValue("@bienso", ttx.BienSo)
                    .Parameters.AddWithValue("@mattxe", ttx.MaTTXe)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Cập nhật Phụ Tùng không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
End Class

