using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;

/// <summary>
/// Summary description for DatabaseHelper
/// </summary>
public static class DatabaseHelper
{
    public static SqlConnection GetDatabaseConnection(string DBName)
    {
        var connection = new SqlConnection();
        connection.ConnectionString = string.Format("Persist Security Info=False;Integrated Security=True;Database={0};server=(localdb)\\MSSQLLocalDB;", DBName);
        return connection;
    }

    public static SqlCommand GetDatabaseProcedure(string name, SqlConnection conn)
    {
        var command = new SqlCommand();
        command.Connection = conn;
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.CommandText = name;

        return command;
    }

    public static SqlParameter GetDatabaseParameter(string name, string value, SqlCommand command)
    {
        var param = GetDatabaseParameter(name, value);
        command.Parameters.Add(param);
        return param;
    }

    public static SqlParameter GetDatabaseParameter(string name, string value)
    {
        var param = new SqlParameter();
        param.ParameterName = name;
        param.SqlDbType = System.Data.SqlDbType.VarChar;
        param.Direction = System.Data.ParameterDirection.Input;
        param.SqlValue = value;
        return param;
    }
}