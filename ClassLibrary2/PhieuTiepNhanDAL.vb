
Imports System.Configuration
Imports System.Data.SqlClient
Imports QLGO1DTO
Imports Utility

Public Class PhieuTiepNhanDAL
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
        query &= "SELECT TOP 1 [maphieutn] "
        query &= "FROM [tblphieutiepnhan] "
        query &= "ORDER BY [maphieutn] DESC "

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
                            idOnDB = reader("maphieutn")
                        End While
                    End If
                    ' new ID = current ID + 1
                    nextID = idOnDB + 1
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    nextID = 1
                    Return New Result(False, "Lấy ID kế tiếp của Loại Tiền Công không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function insert(tn As PhieuTiepNhanDTO) As Result

        Dim query As String = String.Empty
        query &= "INSERT INTO [dbo].[tblphieutiepnhan] "
        query &= "(  [maphieutn] "
        query &= "  ,[mattxe] "
        query &= "  ,[ngaynhan]) "
        query &= "VALUES "
        query &= "(   @maphieutn "
        query &= "   ,@mattxe"
        query &= "   ,@ngaynhan) "

        Dim nextID = 0
        Dim result As Result
        result = getNextID(nextID)
        If (result.FlagResult = False) Then
            Return result
        End If
        tn.MaPhieuTN = nextID

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@maphieutn", tn.MaPhieuTN)
                    .Parameters.AddWithValue("@mattxe", tn.MaTTXe)
                    .Parameters.AddWithValue("@ngaynhan", tn.NgayNhan)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Thêm Loại Tiền Công không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function delete(iMaPhieuTN As Integer) As Result
        Dim query As String = String.Empty
        query &= " DELETE FROM [dbo].[tblphieutiepnhan] "
        query &= " WHERE "
        query &= " [maphieutn] = @maphieutn "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@maphieutn", iMaPhieuTN)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Xóa Loại Tiền Công không thành công", ex.StackTrace)
                End Try
            End Using
        End Using

        Return New Result(True) ' thanh cong
    End Function

    Public Function select_byMaHX(iMaPhieuTN As Integer, listDS As List(Of PhieuTiepNhanDTO)) As Result

        Dim query As String = String.Empty
        query &= " SELECT [maphieutn], [mattxe], [ngaynhan]"
        query &= " FROM [tblphieutiepnhan]"
        query &= " WHERE "
        query &= " [maphieutn] = @maphieutn"


        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@maphieutn", iMaPhieuTN)
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        listDS.Clear()
                        While reader.Read()
                            listDS.Add(New PhieuTiepNhanDTO(reader("maphieutn"), reader("mattxe"), reader("ngaynhan")))
                        End While
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Lấy tất cả Loại Tiền Công không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function selectALL(listKH As List(Of PhieuTiepNhanDTO)) As Result

        Dim query As String = String.Empty
        query &= " SELECT [maphieutn], [mattxe], [ngaynhan]"
        query &= " FROM [tblphieutiepnhan]"


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
                        listKH.Clear()
                        While reader.Read()
                            listKH.Add(New PhieuTiepNhanDTO(reader("maphieutn"), reader("mattxe"), reader("ngaynhan")))
                        End While
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Lấy tất cả Loại Tiền Công không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function


    Public Function update(tn As PhieuTiepNhanDTO) As Result

        Dim query As String = String.Empty
        query &= " UPDATE [tblphieutiepnhan] SET "
        query &= " [mattxe] = @mattxe, "
        query &= " [ngaynhan] = @ngaynhan "
        query &= "WHERE "
        query &= " [maphieutn] = @maphieutn"

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@mattxe", tn.MaTTXe)
                    .Parameters.AddWithValue("@ngaynhan", tn.NgayNhan)
                    .Parameters.AddWithValue("@maphieutn", tn.MaPhieuTN)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Cập nhật Loại Tiền Công không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
End Class
