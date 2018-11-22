using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Content_FindProgram : System.Web.UI.Page
{
    BCS BCS;
    protected void Page_Load(object sender, EventArgs e)
    {
        BCS = new BCS();
    }

    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        var program = BCS.FindProgram(ProgramCode.Text);

        if (program != null)
        {
            ResultMessage.Text = program.ProgramCode + ": " + program.Description;
        } else
        {
            ResultMessage.Text = "No results were found.";
        }

    }
}