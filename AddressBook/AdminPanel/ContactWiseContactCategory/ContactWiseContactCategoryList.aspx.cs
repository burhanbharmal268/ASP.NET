using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_ContactWiseContactCategory_ContactWiseContactCategoryList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FillContactGrid();
    }

    private void FillContactGrid()
    {
        #region Local Variable
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());
        #endregion Local Variable
        try
        {
            #region Set Connection & Command Object
            //data source = source of data or server name
            //inital catalog = database name
            //Integrated Security = It true then consider as windows authentication / Else for false have SQL authemntication User ID = abc  Password = aaa
            //Initially userid is SA and password can be set


            objConn.Open(); //Open the Connection  Step-1

            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_ContactDummy_SelectAll";

            //objCmd.ExecuteReader();    -------------------//Select
            //objCmd.ExecuteNonQuery();  -------------------//Insert / Update / Delete
            //objCmd.ExecuteScalar();    -------------------//Only One Scalar value is being return
            //objCmd.ExecuteXmlReader(); -------------------//Xml type of data

            SqlDataReader objSDR = objCmd.ExecuteReader();
            gvContact.DataSource = objSDR;
            gvContact.DataBind();
            #endregion Set Connection & Command Object

            objConn.Close();//Close Connection at end of work
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State != ConnectionState.Closed)
            {
                objConn.Close();
            }

        }

    }
}