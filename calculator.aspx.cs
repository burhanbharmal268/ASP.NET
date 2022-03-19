using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class calculator : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(TextBox1.Text) && string.IsNullOrEmpty(TextBox2.Text) && string.IsNullOrEmpty(TextBox3.Text))
        {
            Label1.Text = "Please Enter no.1 , no.2 and operator";
        }
        else if(string.IsNullOrEmpty(TextBox1.Text) && string.IsNullOrEmpty(TextBox3.Text))
        {
            Label1.Text = "Please Enter no.1 and no.2";
        }
        else if (string.IsNullOrEmpty(TextBox1.Text))
        {
            Label1.Text = "Please Enter no.1";
        }
        else if (string.IsNullOrEmpty(TextBox2.Text))
        {
            Label1.Text = "Please Enter the operator";
        }
        else if (string.IsNullOrEmpty(TextBox3.Text))
        {
            Label1.Text = "Please Enter num.2";
        }


        else if (TextBox2.Text == "+" || TextBox2.Text == "-" || TextBox2.Text == "*" || TextBox2.Text == "/" || TextBox2.Text == "%")
        {
            if (TextBox2.Text == "+")
            {
                Label1.Text = Convert.ToString(Convert.ToDouble(TextBox1.Text) + Convert.ToDouble(TextBox3.Text));
            }
            if (TextBox2.Text == "-")
            {
                Label1.Text = Convert.ToString(Convert.ToDouble(TextBox1.Text) - Convert.ToDouble(TextBox3.Text));
            }
            if (TextBox2.Text == "*")
            {
                Label1.Text = Convert.ToString(Convert.ToDouble(TextBox1.Text) * Convert.ToDouble(TextBox3.Text));
            }
            if (TextBox2.Text == "/")
            {
                Label1.Text = Convert.ToString(Convert.ToDouble(TextBox1.Text) / Convert.ToDouble(TextBox3.Text));
            }
            if (TextBox2.Text == "%")
            {
                Label1.Text = Convert.ToString(Convert.ToDouble(TextBox1.Text) % Convert.ToDouble(TextBox3.Text));
            }
        }


        else
        {
            Label1.Text = "Enter Apropriate operator";
        }
    }
}