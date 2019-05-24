Friend Module Main
    Public Enum DatabaseType
        MSSQL = 2
        MYSQL = 1
    End Enum
    Public Const DefaultDatabaseType As DatabaseType = DatabaseType.MYSQL
    Public Delegate Sub AssignValue(dr As DataRow)
    Public Delegate Sub ReadValue(rd As IDataReader)
End Module
