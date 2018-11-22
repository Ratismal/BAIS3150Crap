using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Content_FindStudent : System.Web.UI.Page
{
    BCS BCS;
    protected void Page_Load(object sender, EventArgs e)
    {
        BCS = new BCS();
    }

    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        var student = BCS.FindStudent(StudentID.Text);

        if (student != null)
        {
            ResultMessage.Text = string.Format("{0}: {1} {2}, {3} | {4}", student.StudentID, student.FirstName, student.LastName, student.Email, student.ProgramCode);
        }
        else
        {
            ResultMessage.Text = "No results were found.";
        }
    }
}