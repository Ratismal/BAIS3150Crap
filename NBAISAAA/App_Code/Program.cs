using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;

/// <summary>
/// Summary description for Program
/// </summary>
public class Program
{
    public string ProgramCode { get; set; }
    public string Description { get; set; }

    public Program(string ProgramCode, string Description)
    {
        this.ProgramCode = ProgramCode;
        this.Description = Description;
    }

    public Program(SqlDataReader reader)
    {
        reader.Read();

        this.ProgramCode = reader.GetString(0);
        this.Description = reader.GetString(1);
    }
}