using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ListControls : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnDisplay_Click(object sender, EventArgs e)
    {
        /*lblMessage.Text = ddlCountry.SelectedItem.Text.Trim() + "-"+ ddlCountry.SelectedIndex.ToString().Trim() + "-" + ddlCountry.SelectedValue.Trim();*/

        foreach(ListItem li in ddlCountry.Items){

            if (li.Selected == true)
            {
                lblMessage.Text += "<strong>" + li.Value.Trim() + "-" + li.Text.Trim() + "</strong><br/>";
            }
            else
            {
                lblMessage.Text += li.Value.Trim() + "-" + li.Text.Trim() + "<br/>";
            }

            
        }
    }
}