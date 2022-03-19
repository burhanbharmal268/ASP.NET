using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class checkbox : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnClickMe_Click(object sender, EventArgs e)
    {
        if ((chkDiet.Checked == true && chkDietDS.Checked == true))
        {
            lblSelectDIETDS.Visible = true;
            chkdce.Visible = true;
            chkdme.Visible = true;
            chkdee.Visible = true;
            chkdci.Visible = true;
            chkselectall.Visible = true;
            chkresetall.Visible = true;
            chkinverse.Visible = true;


            lblSelectDiet.Visible = true;
            chkce.Visible = true;
            chkme.Visible = true;
            chkee.Visible = true;
            chkci.Visible = true;

            btnClickMe1.Visible = true;
        }
        else if (chkDiet.Checked == true && chkDietDS.Checked == false)
        {
            lblSelectDIETDS.Visible = false;
            chkdce.Visible = false;
            chkdme.Visible = false;
            chkdee.Visible = false;
            chkdci.Visible = false;
            chkselectall.Visible = true;
            chkresetall.Visible = true;
            chkinverse.Visible = true;

            lblSelectDiet.Visible = true;
            chkce.Visible = true;
            chkme.Visible = true;
            chkee.Visible = true;
            chkci.Visible = true;

            btnClickMe1.Visible = true;

        }
        else if (chkDiet.Checked == false && chkDietDS.Checked == true)
        {
            lblSelectDIETDS.Visible = true;
            chkdce.Visible = true;
            chkdme.Visible = true;
            chkdee.Visible = true;
            chkdci.Visible = true;
            chkselectall.Visible = true;
            chkresetall.Visible = true;
            chkinverse.Visible = true;

            lblSelectDiet.Visible = false;
            chkce.Visible = false;
            chkme.Visible = false;
            chkee.Visible = false;
            chkci.Visible = false;

            btnClickMe1.Visible = true;

        }
        else if (chkDiet.Checked == true)
        {
            lblSelectDiet.Visible = true;
            chkce.Visible = true;
            chkme.Visible = true;
            chkee.Visible = true;
            chkci.Visible = true;
            btnClickMe1.Visible = true;
            chkselectall.Visible = true;
            chkresetall.Visible = true;
            chkinverse.Visible = true;

            lblSelectDIETDS.Visible = false;
            chkdce.Visible = false;
            chkdme.Visible = false;
            chkdee.Visible = false;
            chkdci.Visible = false;
        }
        else if (chkDietDS.Checked == true)
        {
            lblSelectDIETDS.Visible = true;
            chkdce.Visible = true;
            chkdme.Visible = true;
            chkdee.Visible = true;
            chkdci.Visible = true;
            btnClickMe1.Visible = true;
            chkselectall.Visible = true;
            chkresetall.Visible = true;
            chkinverse.Visible = true;

            lblSelectDiet.Visible = false;
            chkce.Visible = false;
            chkme.Visible = false;
            chkee.Visible = false;
            chkci.Visible = false;
        }
        else
        {
            lblMessage.Text = "Kindly Select an appropriate Option";
        }
    }
    protected void btnClickMe1_Click(object sender, EventArgs e)
    {
        String strBranch = "";

        if (chkDiet.Checked == true || chkDietDS.Checked == true)
        {
            if (chkce.Checked)
            {
                strBranch = strBranch + "Computer Engineering - Degree" + "<br />";
            }
            if (chkme.Checked)
            {
                strBranch += "Mechanical Engineering - Degree" + "<br />";
            }
            if (chkee.Checked)
            {
                strBranch += "Electrical Engineering - Degree" + "<br />";
            }
            if (chkci.Checked)
            {
                strBranch += "Cvil Engineering - Degree" + "<br />";
            }
            if (chkdce.Checked)
            {
                strBranch += "Diploma in Computer Engineering" + "<br />";
            }
            if (chkdme.Checked)
            {
                strBranch += "Diploma in Mechanical Engineering" + "<br />";
            }
            if (chkdee.Checked)
            {
                strBranch += "Diploma in Electrical Engineering" + "<br />";
            }
            if (chkdci.Checked)
            {
                strBranch += "Diploma in Civil Engineering" + "<br />";
            }
            lblMessage.Text = "You have selected Options as :<br/>" + strBranch;
        }
    }
}