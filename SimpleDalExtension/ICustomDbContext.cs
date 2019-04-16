using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SimpleDalExtension
{
    public interface ICustomDbContext
    {
        SqlConnection GetSqlConnection();
        int ExecuteStoredProcedure(string procedureName, CustomDbParameterList customParameters);
        int ExecuteStoredProcedure(string procedureName, List<SqlParameter> parameters);
        object GetEntity(IDataReader reader, Type t);
        T GetEntity<T>(IDataReader reader);
        List<T> RetrieveDataFromStordProcedure<T>(string procedureName, CustomDbParameterList customParameters);
        List<T> RetrieveDataFromStordProcedure<T>(string procedureName, List<SqlParameter> parameters);
        Dictionary<string, object> RetrieveMultiRecordSet(string procedureName, CustomDbParameterList customParameters, params Type[] types);
        Dictionary<string, object> RetrieveMultiRecordSet(string procedureName, List<SqlParameter> parameters, List<RecordSetDefinition> tepesDefinition);
        Dictionary<string, object> RetrieveMultiRecordSet(string procedureName, List<SqlParameter> parameters, params Type[] types);
        Dictionary<string, object> RetrieveMultiRecordSet(string procedureName, List<SqlParameter> parameters, Type[] types, List<string> names);
    }
}