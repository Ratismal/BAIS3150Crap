﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ABC_Default : System.Web.UI.Page
{
    ABCPos manager;
    protected void Page_Load(object sender, EventArgs e)
    {
        manager = new ABCPos();
    }
}