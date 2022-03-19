using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlTypes;

public partial class AdminPanel_Country_CountryList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillCountryGrid();
        }
        

    }
    #endregion Load Event

    #region FillCountryGrid
    private void FillCountryGrid()
    {
        #region Local Variable
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());
        #endregion Local Variable
        try
        {
            //Establish Connection
            //Create Blank Connection object
            

            //data source = source of data or server name
            //inital catalog = database name
            //Integrated Security = It true then consider as windows authentication / Else for false have SQL authemntication User ID = abc  Password = aaa
            //Initially userid is SA and password can be set 
            #region Set Connection & Command Object
            objConn.Open(); //Open the Connection  Step-1

            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_SelectAll";

            //objCmd.ExecuteReader();    -------------------//Select
            //objCmd.ExecuteNonQuery();  -------------------//Insert / Update / Delete
            //objCmd.ExecuteScalar();    -------------------//Only One Scalar value is being return
            //objCmd.ExecuteXmlReader(); -------------------//Xml type of data

            SqlDataReader objSDR = objCmd.ExecuteReader();
            gvCountry.DataSource = objSDR;
            gvCountry.DataBind();
            #endregion Set Connection & Command Object
            objConn.Close();//Close Connection at end of work
        }
        catch(Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            objConn.Close();
        }
        
    }
    #endregion FillCountryGrid

    #region Row Command : Country
    protected void gvCountry_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        #region Delete Record
        if (e.CommandName == "DeleteRecord")
        {
            
            if (e.CommandArgument != "")
            {
                DeleteCountry(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }
        #endregion Delete Record

        /*if (e.CommandName == "EditRecord")
        {
            lblMessage.Text = "Edit Button is Clicked";
            
            if (e.CommandArgument != "")
            {
                lblMessage.Text += ",CountryID = " + e.CommandArgument;
            }
        }*/
    }
    #endregion Row Command : Country

    #region Delete Country
    private void DeleteCountry(SqlInt32 CountryID)
    {
        #region Local Variable
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());
        #endregion Local Variable
        try
        {
            #region Set Connection & Command Object
            objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_DeleteByPK";
            objCmd.Parameters.AddWithValue("@CountryID", CountryID.ToString());
            objCmd.ExecuteNonQuery();
            #endregion Set Connection & Command Object


            objConn.Close();
            FillCountryGrid();
        }
        catch(Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            objConn.Close();
        }



    }
    #endregion Delete Country
}