Imports System.Net
Imports System.Web.Http
Namespace Controllers
    Public Class CitizenController
        Inherits ApiController
        ' GET api/citizen
        Public Function GetValues() As IEnumerable(Of clsCitizen)
            Return New clsCitizen(DatabaseType.MSSQL).GetData().AsEnumerable()
        End Function

        ' GET api/citizen/5
        Public Function GetValue(ByVal id As String) As clsCitizen
            Dim oData = New clsCitizen(DatabaseType.MSSQL).GetData(String.Format(" WHERE citizenId='{0}'", id))
            Return oData.FirstOrDefault
        End Function

        ' POST api/citizen
        Public Sub PostValue(<FromBody()> ByVal data As clsCitizen)
            data.SetConnect(DatabaseType.MSSQL)
            data.SaveData()
        End Sub
    End Class
End Namespace