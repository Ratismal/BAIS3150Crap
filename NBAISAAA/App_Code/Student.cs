using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;

/// <summary>
/// Summary description for Student
/// </summary>
public class Student
{
    public string StudentID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string ProgramCode { get; set; }

    public Student(string StudentID, string FirstName, string LastName, string Email, string ProgramCode)
    {
        this.StudentID = StudentID;
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.Email = Email;
        this.ProgramCode = ProgramCode;
    }

    public Student(SqlDataReader reader)
    {
        reader.Read();
        this.StudentID = reader.GetString(0);
        this.FirstName = reader.GetString(1);
        this.LastName = reader.GetString(2);
        if (!reader.IsDBNull(3))
            this.Email = reader.GetString(3);
        this.ProgramCode = reader.GetString(4);
    }
}