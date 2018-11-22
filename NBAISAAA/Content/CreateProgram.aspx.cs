using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Content_CreateProgram : System.Web.UI.Page
{
    BCS BCS;
    protected void Page_Load(object sender, EventArgs e)
    {
        BCS = new BCS();
    }

    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        var success = BCS.CreateProgram(new Program(ProgramCode.Text, Description.Text));

        if (success)
        {
            ResultMessage.Text = "Successfully created a program.";
        }
        else
        {
            ResultMessage.Text = "Could not create the program.";
        }
    }
}