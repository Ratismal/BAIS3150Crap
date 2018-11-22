using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/// <summary>
/// Summary description for Programs
/// </summary>
public class Programs
{
    public Programs()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Program FindProgram(string ProgramCode)
    {
        var conn = DatabaseHelper.GetDatabaseConnection("KMorrill2");
        conn.Open();
        var comm = DatabaseHelper.GetDatabaseProcedure("FindProgram", conn);
        var para = DatabaseHelper.GetDatabaseParameter("ProgramCode", ProgramCode, comm);

        try
        {
            return new Program(comm.ExecuteReader());
        }
        catch
        {
            return null;
        }
        finally
        {
            conn.Close();
        }
    }

    public bool CreateProgram(Program program)
    {
        var result = true;

        var conn = DatabaseHelper.GetDatabaseConnection("KMorrill2");
        conn.Open();
        var comm = DatabaseHelper.GetDatabaseProcedure("CreateProgram", conn);
        var codeParam = DatabaseHelper.GetDatabaseParameter("ProgramCode", program.ProgramCode, comm);
        var descParam = DatabaseHelper.GetDatabaseParameter("Description", program.Description, comm);

        try
        {
            comm.ExecuteNonQuery();
        } catch
        {
            result = false;
        }
        conn.Close();
        return result;
    }

}