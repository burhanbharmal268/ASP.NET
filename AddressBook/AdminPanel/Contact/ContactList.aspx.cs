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

public partial class AdminPanel_Contact_ContactList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillContactGrid();
        }
    }
    #endregion Load Event

    #region Fill Contact Grid
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
            objCmd.CommandText = "PR_Contact_SelectAll";

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
    #endregion Fill Contact Grid

    #region Row Command : Delete
    protected void gvContact_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {

            if (e.CommandArgument != "")
            {
                DeleteContact(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }
    }
    #endregion Row Command : Delete

    #region Delete Contact
    private void DeleteContact(SqlInt32 ContactID)
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
            objCmd.CommandText = "PR_Contact_DeleteByPK";
            objCmd.Parameters.AddWithValue("@ContactID", ContactID.ToString());
            objCmd.ExecuteNonQuery();
            #endregion Set Connection & Command Object



            objConn.Close();
            FillContactGrid();
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
    #endregion Delete Contact
}