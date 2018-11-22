using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BCS
/// </summary>
public class BCS
{
    Students StudentManager;
    Programs ProgramManager;
    public BCS()
    {
        StudentManager = new Students();
        ProgramManager = new Programs();
    }

    public Program FindProgram(string ProgramCode)
    {
        return ProgramManager.FindProgram(ProgramCode);
    }

    public bool CreateProgram(Program program)
    {
        return ProgramManager.CreateProgram(program);
    }

    public Student FindStudent(string StudentID)
    {
        return StudentManager.FindStudent(StudentID);
    }

    public bool EnrollStudent(Student student)
    {
        return StudentManager.EnrollStudent(student);
    }

    public bool ModifyStudent(Student student)
    {
        return StudentManager.ModifyStudent(student);
    }

    public bool RemoveStudent(string StudentID)
    {
        return StudentManager.RemoveStudent(StudentID);
    }
}