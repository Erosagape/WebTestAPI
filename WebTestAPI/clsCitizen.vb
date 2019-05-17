'-----Class Definition-----
Imports System.Data.SqlClient
Public Class clsCitizen
    Private m_ConnStr As String
    Public Sub New()

    End Sub
    Public Sub New(pConnStr As String)
        m_ConnStr = pConnStr
    End Sub
    Public Sub SetConnect(pConnStr As String)
        m_ConnStr = pConnStr
    End Sub

    Private m_citizenId As String
    Public Property citizenId As String
        Get
            Return m_citizenId
        End Get
        Set(value As String)
            m_citizenId = value
        End Set
    End Property
    Private m_citizenTitle As String
    Public Property citizenTitle As String
        Get
            Return m_citizenTitle
        End Get
        Set(value As String)
            m_citizenTitle = value
        End Set
    End Property
    Private m_citizenName As String
    Public Property citizenName As String
        Get
            Return m_citizenName
        End Get
        Set(value As String)
            m_citizenName = value
        End Set
    End Property
    Private m_citizenHouseno As String
    Public Property citizenHouseno As String
        Get
            Return m_citizenHouseno
        End Get
        Set(value As String)
            m_citizenHouseno = value
        End Set
    End Property
    Private m_citizenRoad As String
    Public Property citizenRoad As String
        Get
            Return m_citizenRoad
        End Get
        Set(value As String)
            m_citizenRoad = value
        End Set
    End Property
    Private m_citizenSubdistrict As String
    Public Property citizenSubdistrict As String
        Get
            Return m_citizenSubdistrict
        End Get
        Set(value As String)
            m_citizenSubdistrict = value
        End Set
    End Property
    Private m_citizenDistrict As String
    Public Property citizenDistrict As String
        Get
            Return m_citizenDistrict
        End Get
        Set(value As String)
            m_citizenDistrict = value
        End Set
    End Property
    Private m_citizenProvince As String
    Public Property citizenProvince As String
        Get
            Return m_citizenProvince
        End Get
        Set(value As String)
            m_citizenProvince = value
        End Set
    End Property
    Private m_citizenCountry As String
    Public Property citizenCountry As String
        Get
            Return m_citizenCountry
        End Get
        Set(value As String)
            m_citizenCountry = value
        End Set
    End Property
    Private m_citizenZipcode As String
    Public Property citizenZipcode As String
        Get
            Return m_citizenZipcode
        End Get
        Set(value As String)
            m_citizenZipcode = value
        End Set
    End Property
    Private m_citizenMarriage As String
    Public Property citizenMarriage As String
        Get
            Return m_citizenMarriage
        End Get
        Set(value As String)
            m_citizenMarriage = value
        End Set
    End Property
    Private m_citizenSex As String
    Public Property citizenSex As String
        Get
            Return m_citizenSex
        End Get
        Set(value As String)
            m_citizenSex = value
        End Set
    End Property
    Private m_citizenStatus As String
    Public Property citizenStatus As String
        Get
            Return m_citizenStatus
        End Get
        Set(value As String)
            m_citizenStatus = value
        End Set
    End Property
    Public Function SaveData(pSQLWhere As String) As String
        Dim msg As String = ""
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()

                Using da As New SqlDataAdapter("SELECT * FROM citizen " & pSQLWhere, cn)
                    Using cb As New SqlCommandBuilder(da)
                        Using dt As New DataTable
                            da.Fill(dt)
                            Dim dr As DataRow = dt.NewRow
                            If dt.Rows.Count > 0 Then dr = dt.Rows(0)
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
                            If dr.RowState = DataRowState.Detached Then dt.Rows.Add(dr)
                            da.Update(dt)
                            msg = "Save Complete"
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                msg = ex.Message
            End Try
        End Using
        Return msg
    End Function
    Public Sub AddNew()

        m_citizenId = ""
        m_citizenTitle = ""
        m_citizenName = ""
        m_citizenHouseno = ""
        m_citizenRoad = ""
        m_citizenSubdistrict = ""
        m_citizenDistrict = ""
        m_citizenProvince = ""
        m_citizenCountry = ""
        m_citizenZipcode = ""
        m_citizenMarriage = ""
        m_citizenSex = ""
        m_citizenStatus = ""
    End Sub
    Public Sub LoadData(pKey As String)
        Dim lst As New List(Of clsCitizen)
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()
                Dim rd As SqlDataReader = New SqlCommand(String.Format("SELECT * FROM citizen WHERE citizenId='{0}'", pKey), cn).ExecuteReader()
                If rd.Read() Then
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("citizenId"))) = False Then
                        Me.citizenId = rd.GetString(rd.GetOrdinal("citizenId")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("citizenTitle"))) = False Then
                        Me.citizenTitle = rd.GetString(rd.GetOrdinal("citizenTitle")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("citizenName"))) = False Then
                        Me.citizenName = rd.GetString(rd.GetOrdinal("citizenName")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("citizenHouseno"))) = False Then
                        Me.citizenHouseno = rd.GetString(rd.GetOrdinal("citizenHouseno")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("citizenRoad"))) = False Then
                        Me.citizenRoad = rd.GetString(rd.GetOrdinal("citizenRoad")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("citizenSubdistrict"))) = False Then
                        Me.citizenSubdistrict = rd.GetString(rd.GetOrdinal("citizenSubdistrict")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("citizenDistrict"))) = False Then
                        Me.citizenDistrict = rd.GetString(rd.GetOrdinal("citizenDistrict")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("citizenProvince"))) = False Then
                        Me.citizenProvince = rd.GetString(rd.GetOrdinal("citizenProvince")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("citizenCountry"))) = False Then
                        Me.citizenCountry = rd.GetString(rd.GetOrdinal("citizenCountry")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("citizenZipcode"))) = False Then
                        Me.citizenZipcode = rd.GetString(rd.GetOrdinal("citizenZipcode")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("citizenMarriage"))) = False Then
                        Me.citizenMarriage = rd.GetString(rd.GetOrdinal("citizenMarriage")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("citizenSex"))) = False Then
                        Me.citizenSex = rd.GetString(rd.GetOrdinal("citizenSex")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("citizenStatus"))) = False Then
                        Me.citizenStatus = rd.GetString(rd.GetOrdinal("citizenStatus")).ToString()
                    End If
                End If
            Catch ex As Exception
            End Try
        End Using
    End Sub
    Public Function GetData(pSQLWhere As String) As List(Of clsCitizen)
        Dim lst As New List(Of clsCitizen)
        Using cn As New SqlConnection(m_ConnStr)
            Dim row As clsCitizen
            Try
                cn.Open()
                Dim rd As SqlDataReader = New SqlCommand("SELECT * FROM citizen" & pSQLWhere, cn).ExecuteReader()
                While rd.Read()
                    row = New clsCitizen(m_ConnStr)
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("citizenId"))) = False Then
                        row.citizenId = rd.GetString(rd.GetOrdinal("citizenId")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("citizenTitle"))) = False Then
                        row.citizenTitle = rd.GetString(rd.GetOrdinal("citizenTitle")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("citizenName"))) = False Then
                        row.citizenName = rd.GetString(rd.GetOrdinal("citizenName")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("citizenHouseno"))) = False Then
                        row.citizenHouseno = rd.GetString(rd.GetOrdinal("citizenHouseno")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("citizenRoad"))) = False Then
                        row.citizenRoad = rd.GetString(rd.GetOrdinal("citizenRoad")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("citizenSubdistrict"))) = False Then
                        row.citizenSubdistrict = rd.GetString(rd.GetOrdinal("citizenSubdistrict")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("citizenDistrict"))) = False Then
                        row.citizenDistrict = rd.GetString(rd.GetOrdinal("citizenDistrict")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("citizenProvince"))) = False Then
                        row.citizenProvince = rd.GetString(rd.GetOrdinal("citizenProvince")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("citizenCountry"))) = False Then
                        row.citizenCountry = rd.GetString(rd.GetOrdinal("citizenCountry")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("citizenZipcode"))) = False Then
                        row.citizenZipcode = rd.GetString(rd.GetOrdinal("citizenZipcode")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("citizenMarriage"))) = False Then
                        row.citizenMarriage = rd.GetString(rd.GetOrdinal("citizenMarriage")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("citizenSex"))) = False Then
                        row.citizenSex = rd.GetString(rd.GetOrdinal("citizenSex")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("citizenStatus"))) = False Then
                        row.citizenStatus = rd.GetString(rd.GetOrdinal("citizenStatus")).ToString()
                    End If
                    lst.Add(row)
                End While
            Catch ex As Exception
            End Try
        End Using
        Return lst
    End Function
    Public Function DeleteData(pSQLWhere As String) As String
        Dim msg As String = ""
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()

                Using cm As New SqlCommand("DELETE FROM citizen " + pSQLWhere, cn)
                    cm.CommandTimeout = 0
                    cm.CommandType = CommandType.Text
                    cm.ExecuteNonQuery()
                End Using
                cn.Close()
                msg = "Delete Complete"
            Catch ex As Exception
                msg = ex.Message
            End Try
        End Using
        Return msg
    End Function
End Class