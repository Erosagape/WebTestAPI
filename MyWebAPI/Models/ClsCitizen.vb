'-----Class Definition-----
Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient

Public Class clsCitizen
    Private Property m_ConnStr As String
    Private Property connectType As DatabaseType
    Private Const m_SQLSelect As String = "SELECT * FROM citizen "
    Private Const m_SQLWhere As String = " WHERE citizenId='{0}' "
    Private Const m_SQLDelete As String = "DELETE FROM citizen {0}"
    Public Property citizenId As String
    Public Property citizenTitle As String
    Public Property citizenName As String
    Public Property citizenHouseno As String
    Public Property citizenRoad As String
    Public Property citizenSubdistrict As String
    Public Property citizenDistrict As String
    Public Property citizenProvince As String
    Public Property citizenCountry As String
    Public Property citizenZipcode As String
    Public Property citizenMarriage As String
    Public Property citizenSex As String
    Public Property citizenStatus As String
    Public Sub New()
        SetConnect(DefaultDatabaseType)
    End Sub
    Public Sub New(pDBType As Integer)
        SetConnect(pDBType)
    End Sub
    Public Sub SetConnect(Optional pDBType As Integer = 0)
        connectType = If(pDBType = 0, DefaultDatabaseType, pDBType)
        m_ConnStr = New CUtil(connectType).GetConnection()
    End Sub
    Public Sub AssignValue(dr As DataRow)
        dr("citizenId") = Me.citizenId
        dr("citizenTitle") = Me.citizenTitle
        dr("citizenName") = Me.citizenName
        dr("citizenHouseno") = Me.citizenHouseno
        dr("citizenRoad") = Me.citizenRoad
        dr("citizenSubdistrict") = Me.citizenSubdistrict
        dr("citizenDistrict") = Me.citizenDistrict
        dr("citizenProvince") = Me.citizenProvince
        dr("citizenCountry") = Me.citizenCountry
        dr("citizenZipcode") = Me.citizenZipcode
        dr("citizenMarriage") = Me.citizenMarriage
        dr("citizenSex") = Me.citizenSex
        dr("citizenStatus") = Me.citizenStatus
    End Sub
    Public Sub AddNew()
        citizenId = ""
        citizenTitle = ""
        citizenName = ""
        citizenHouseno = ""
        citizenRoad = ""
        citizenSubdistrict = ""
        citizenDistrict = ""
        citizenProvince = ""
        citizenCountry = ""
        citizenZipcode = ""
        citizenMarriage = ""
        citizenSex = ""
        citizenStatus = ""
    End Sub
    Public Sub SetValue(rd As IDataReader, this As clsCitizen)
        If IsDBNull(rd.GetValue(rd.GetOrdinal("citizenId"))) = False Then
            this.citizenId = rd.GetString(rd.GetOrdinal("citizenId")).ToString()
        End If
        If IsDBNull(rd.GetValue(rd.GetOrdinal("citizenTitle"))) = False Then
            this.citizenTitle = rd.GetString(rd.GetOrdinal("citizenTitle")).ToString()
        End If
        If IsDBNull(rd.GetValue(rd.GetOrdinal("citizenName"))) = False Then
            this.citizenName = rd.GetString(rd.GetOrdinal("citizenName")).ToString()
        End If
        If IsDBNull(rd.GetValue(rd.GetOrdinal("citizenHouseno"))) = False Then
            this.citizenHouseno = rd.GetString(rd.GetOrdinal("citizenHouseno")).ToString()
        End If
        If IsDBNull(rd.GetValue(rd.GetOrdinal("citizenRoad"))) = False Then
            this.citizenRoad = rd.GetString(rd.GetOrdinal("citizenRoad")).ToString()
        End If
        If IsDBNull(rd.GetValue(rd.GetOrdinal("citizenSubdistrict"))) = False Then
            this.citizenSubdistrict = rd.GetString(rd.GetOrdinal("citizenSubdistrict")).ToString()
        End If
        If IsDBNull(rd.GetValue(rd.GetOrdinal("citizenDistrict"))) = False Then
            this.citizenDistrict = rd.GetString(rd.GetOrdinal("citizenDistrict")).ToString()
        End If
        If IsDBNull(rd.GetValue(rd.GetOrdinal("citizenProvince"))) = False Then
            this.citizenProvince = rd.GetString(rd.GetOrdinal("citizenProvince")).ToString()
        End If
        If IsDBNull(rd.GetValue(rd.GetOrdinal("citizenCountry"))) = False Then
            this.citizenCountry = rd.GetString(rd.GetOrdinal("citizenCountry")).ToString()
        End If
        If IsDBNull(rd.GetValue(rd.GetOrdinal("citizenZipcode"))) = False Then
            this.citizenZipcode = rd.GetString(rd.GetOrdinal("citizenZipcode")).ToString()
        End If
        If IsDBNull(rd.GetValue(rd.GetOrdinal("citizenMarriage"))) = False Then
            this.citizenMarriage = rd.GetString(rd.GetOrdinal("citizenMarriage")).ToString()
        End If
        If IsDBNull(rd.GetValue(rd.GetOrdinal("citizenSex"))) = False Then
            this.citizenSex = rd.GetString(rd.GetOrdinal("citizenSex")).ToString()
        End If
        If IsDBNull(rd.GetValue(rd.GetOrdinal("citizenStatus"))) = False Then
            this.citizenStatus = rd.GetString(rd.GetOrdinal("citizenStatus")).ToString()
        End If
    End Sub
    Public Function SaveData() As String
        Dim SQLWhere = String.Format(m_SQLWhere, Me.citizenId)
        Return New CUtil(connectType).UpdateData(m_SQLSelect & SQLWhere, AddressOf AssignValue).Message
    End Function
    Public Function RefreshData() As String
        Return FindData(Me.citizenId)
    End Function
    Public Function ReadData(rd As IDataReader) As List(Of clsCitizen)
        Dim lst As New List(Of clsCitizen)
        While rd.Read
            Dim row As New clsCitizen(connectType)
            SetValue(rd, row)
            lst.Add(row)
        End While
        Return lst
    End Function
    Public Sub LoadData(rd As IDataReader)
        If rd.Read() Then
            SetValue(rd, Me)
        End If
    End Sub
    Public Function FindData(pKey As String) As String
        Dim sql = String.Format(m_SQLSelect & m_SQLWhere, pKey)
        Return New CUtil(connectType).ReadData(sql, AddressOf LoadData).Message
    End Function
    Public Function GetData(Optional pSQLWhere As String = "") As List(Of clsCitizen)
        Dim sql = m_SQLSelect & pSQLWhere
        Select Case connectType
            Case DatabaseType.MSSQL
                Dim rd As SqlDataReader = New CUtil(connectType).ReadData(sql, AddressOf LoadData).Result
                Return ReadData(rd)
            Case DatabaseType.MYSQL
                Using cn As New MySqlConnection(New CUtil(DatabaseType.MYSQL).GetConnection())
                    cn.Open()
                    Dim rd As MySqlDataReader = New MySqlCommand(sql, cn).ExecuteReader()
                    Return ReadData(rd)
                End Using

            Case Else
                Return New List(Of clsCitizen)
        End Select
    End Function
    Function DeleteData(pSQLWhere As String) As String
        Dim msg = New CUtil(connectType).DBExecute(String.Format(m_SQLDelete, pSQLWhere)).Message
        If msg = "OK" Then
            msg = "Delete Complete"
        End If
        Return msg
    End Function
End Class