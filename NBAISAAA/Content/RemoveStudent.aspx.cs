using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Content_RemoveStudent : System.Web.UI.Page
{
    BCS BCS;
    protected void Page_Load(object sender, EventArgs e)
    {
        BCS = new BCS();
    }

    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        var student = BCS.RemoveStudent(StudentID.Text);

        if (student)
        {
            ResultMessage.Text = "Student has been eliminated.";
        }
        else
        {
            ResultMessage.Text = "Student could not be removed.";
        }
    }
}