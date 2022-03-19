using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DarshanUni : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        imgDarshanUniversity.ImageUrl = "~/Images/Du2.jfif";

        hlDarshanCollege.Text = ".net sessions for semester 6";
        hlDarshanCollege.NavigateUrl = "~/DarshanHomePage.aspx";
    }
    protected void lbtnClickMe_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "Link Button is clicked";
    }
    protected void imgbtnClickMe_Click(object sender, ImageClickEventArgs e)
    {
        lblMessage.Text = "Image button is clicked";
    }
    protected void btnClickMe_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "Click button is clicked";
    }
    protected void rdbtnMale_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void rdbtnFemale_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void btnGender_Click(object sender, EventArgs e)
    {
        if(rdbtnMale.Checked== true)
        {
            lblGender.Text = "Male is selected";
        }
        else if(rdbtnFemale.Checked==true)
        {
            lblGender.Text = "Female is selected";
        }
        else
        {
            lblGender.Text = "Select any appropriate Gender"; 
        }
    }
}