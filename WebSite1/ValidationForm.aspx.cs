using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ValidationForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (chkAgree.Checked == true)
        {
            lblMessage.Text = "Data is saved Successfully";
        }
        else
        {
            lblMessage.Text = "You must Agree Terms & Conditions";
        }
        
    }
    protected void chkAgree_CheckedChanged(object sender, EventArgs e)
    {
        
    }
}