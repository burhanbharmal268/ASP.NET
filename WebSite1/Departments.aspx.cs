using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Departments : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnClickMe_Click(object sender, EventArgs e)
    {
        if (rdbtnDiet.Checked == true)
        {
            lblSelectDiet.Visible = true;
            rdbtnce.Visible = true;
            rdbtnme.Visible = true;
            rdbtnee.Visible = true;
            rdbtnci.Visible = true;
            btnClickMe1.Visible = true;

            lblSelectDIETDS.Visible = false;
            rdbtndce.Visible = false;
            rdbtndme.Visible = false;
            rdbtndee.Visible = false;
            rdbtndci.Visible = false;

            /*if (rdbtnce.Checked == true)
            {
                lblMessage.Text = "Computer Engineering Selected";
            }
            else if (rdbtnme.Checked == true)
            {
                lblMessage.Text = "Mechanical Engineering Selected";
            }
            else if (rdbtnee.Checked == true)
            {
                lblMessage.Text = "Electrical Engineering Selected";
            }
            else if(rdbtnci.Checked == true)
            {
                lblMessage.Text = "Civil Engineering Selected";
            }*/
        }
        else if (rdbtnDietDS.Checked == true)
        {
            lblSelectDIETDS.Visible = true;
            rdbtndce.Visible = true;
            rdbtndme.Visible = true;
            rdbtndee.Visible = true;
            rdbtndci.Visible = true;
            btnClickMe1.Visible = true;

            lblSelectDiet.Visible = false;
            rdbtnce.Visible = false;
            rdbtnme.Visible = false;
            rdbtnee.Visible = false;
            rdbtnci.Visible = false;

            /*if (rdbtndce.Checked == true)
            {
                lblMessage.Text = "Diploma in Computer Engineering Selected";
            }
            else if (rdbtndme.Checked == true)
            {
                lblMessage.Text = "Diploma in Mechanical Engineering Selected";
            }
            else if (rdbtndee.Checked == true)
            {
                lblMessage.Text = "Diploma in Electrical Engineering Selected";
            }
            else if (rdbtndci.Checked == true)
            {
                lblMessage.Text = "Diploma in Civil Engineering Selected";
            }*/
        }
        else if (rdbtnDiet.Checked == true && rdbtnDietDS.Checked == false)
        {
            lblSelectDIETDS.Visible = false;
            rdbtndce.Visible = false;
            rdbtndme.Visible = false;
            rdbtndee.Visible = false;
            rdbtndci.Visible = false;

            lblSelectDiet.Visible = true;
            rdbtnce.Visible = true;
            rdbtnme.Visible = true;
            rdbtnee.Visible = true;
            rdbtnci.Visible = true;

            btnClickMe1.Visible = true;

        }
        else if (rdbtnDiet.Checked == false && rdbtnDietDS.Checked == true)
        {
            lblSelectDIETDS.Visible = true;
            rdbtndce.Visible = true;
            rdbtndme.Visible = true;
            rdbtndee.Visible = true;
            rdbtndci.Visible = true;

            lblSelectDiet.Visible = false;
            rdbtnce.Visible = false;
            rdbtnme.Visible = false;
            rdbtnee.Visible = false;
            rdbtnci.Visible = false;

            btnClickMe1.Visible = true;

        }
        else if (rdbtnDiet.Checked == false && rdbtnDietDS.Checked == false)
        {
            lblSelectDIETDS.Visible = false;
            rdbtndce.Visible = false;
            rdbtndme.Visible = false;
            rdbtndee.Visible = false;
            rdbtndci.Visible = false;

            lblSelectDiet.Visible = false;
            rdbtnce.Visible = false;
            rdbtnme.Visible = false;
            rdbtnee.Visible = false;
            rdbtnci.Visible = false;

            btnClickMe1.Visible = false;

            lblMessage.Text = "Kindly Select an appropriate Option";

        }
        else
        {
            lblMessage.Text = "Kindly Select an appropriate Option";
        }
    }

    protected void btnClickMe1_Click(object sender, EventArgs e)
    {
        if (rdbtnDiet.Checked == true)
        {
            if (rdbtnce.Checked == true)
            {
                lblMessage.Text = "Computer Engineering Selected";
            }
            else if (rdbtnme.Checked == true)
            {
                lblMessage.Text = "Mechanical Engineering Selected";
            }
            else if (rdbtnee.Checked == true)
            {
                lblMessage.Text = "Electrical Engineering Selected";
            }
            else if (rdbtnci.Checked == true)
            {
                lblMessage.Text = "Civil Engineering Selected";
            }
        }
        else if (rdbtnDietDS.Checked == true)
        {
            if (rdbtndce.Checked == true)
            {
                lblMessage.Text = "Diploma in Computer Engineering Selected";
            }
            else if (rdbtndme.Checked == true)
            {
                lblMessage.Text = "Diploma in Mechanical Engineering Selected";
            }
            else if (rdbtndee.Checked == true)
            {
                lblMessage.Text = "Diploma in Electrical Engineering Selected";
            }
            else if (rdbtndci.Checked == true)
            {
                lblMessage.Text = "Diploma in Civil Engineering Selected";
            }
        }
        else
        {
            lblMessage.Text = "Kindly Select an appropriate Option";
        }
    }
}