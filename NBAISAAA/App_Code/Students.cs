using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for Students
/// </summary>
public class Students
{
    public Student FindStudent(string StudentID)
    {
        var conn = DatabaseHelper.GetDatabaseConnection("KMorrill2");
        conn.Open();
        var comm = DatabaseHelper.GetDatabaseProcedure("FindStudent", conn);
        var para = DatabaseHelper.GetDatabaseParameter("StudentID", StudentID, comm);

        try
        {
            return new Student(comm.ExecuteReader());
        }
        catch (Exception e)
        {
            System.Diagnostics.Debug.WriteLine(e.StackTrace);
            return null;
        }
        finally
        {
            conn.Close();
        }
    }

    public bool EnrollStudent(Student student)
    {
        var result = true;

        var conn = DatabaseHelper.GetDatabaseConnection("KMorrill2");
        conn.Open();
        var comm = DatabaseHelper.GetDatabaseProcedure("EnrollStudent", conn);
        DatabaseHelper.GetDatabaseParameter("StudentID", student.StudentID, comm);
        DatabaseHelper.GetDatabaseParameter("FirstName", student.FirstName, comm);
        DatabaseHelper.GetDatabaseParameter("LastName", student.LastName, comm);
        DatabaseHelper.GetDatabaseParameter("Email", student.Email, comm);
        DatabaseHelper.GetDatabaseParameter("ProgramCode", student.ProgramCode, comm);

        try
        {
            comm.ExecuteNonQuery();
        }
        catch
        {
            result = false;
        }
        conn.Close();
        return result;
    }
    public bool ModifyStudent(Student student)
    {
        var result = true;

        var conn = DatabaseHelper.GetDatabaseConnection("KMorrill2");
        conn.Open();
        var comm = DatabaseHelper.GetDatabaseProcedure("ModifyStudent", conn);
        DatabaseHelper.GetDatabaseParameter("StudentID", student.StudentID, comm);
        DatabaseHelper.GetDatabaseParameter("FirstName", student.FirstName, comm);
        DatabaseHelper.GetDatabaseParameter("LastName", student.LastName, comm);
        DatabaseHelper.GetDatabaseParameter("Email", student.Email, comm);
        DatabaseHelper.GetDatabaseParameter("ProgramCode", student.ProgramCode, comm);

        try
        {
            comm.ExecuteNonQuery();
        }
        catch
        {
            result = false;
        }
        conn.Close();
        return result;
    }

    public bool RemoveStudent(string StudentID)
    {
        var result = true;

        var conn = DatabaseHelper.GetDatabaseConnection("KMorrill2");
        conn.Open();
        var comm = DatabaseHelper.GetDatabaseProcedure("RemoveStudent", conn);
        DatabaseHelper.GetDatabaseParameter("StudentID", StudentID, comm);

        try
        {
            comm.ExecuteNonQuery();
        }
        catch
        {
            result = false;
        }
        conn.Close();
        return result;
    }
}