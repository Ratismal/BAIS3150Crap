using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Content_EnrollStudent : System.Web.UI.Page
{
    BCS BCS;
    protected void Page_Load(object sender, EventArgs e)
    {
        BCS = new BCS();
    }

    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        var student = new Student(
            StudentID.Text,
            FirstName.Text,
            LastName.Text,
            Email.Text,
            ProgramCode.Text
        );

        var success = BCS.EnrollStudent(student);

        if (success)
        {
            ResultMessage.Text = "Student successfully enrolled.";
        } else
        {
            ResultMessage.Text = "Failed to enroll student.";
        }
    }
}