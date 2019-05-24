Imports System.Net
Imports System.Web.Http

Public Class ValuesController
    Inherits ApiController

    ' GET api/values
    Public Function GetValues() As IEnumerable(Of clsCitizen)
        Return New clsCitizen().GetData().AsEnumerable()
    End Function

    ' GET api/values/5
    Public Function GetValue(ByVal id As String) As clsCitizen
        Dim oData = New clsCitizen().GetData(String.Format(" WHERE citizenId='{0}'", id))
        Return oData.FirstOrDefault
    End Function

    ' POST api/values
    Public Sub PostValue(<FromBody()> ByVal data As clsCitizen)
        data.SetConnect()
        data.SaveData()
    End Sub

End Class
