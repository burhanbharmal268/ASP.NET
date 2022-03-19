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

public partial class AdminPanel_State_StateList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillStateGrid();
        }
         
    }
    #endregion Load Event

    #region Fill State Grid
    private void FillStateGrid()
    {
        #region Loacal Variable
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());
        #endregion Loacal Variable
        try
        {
            #region Set Connection & Command Object
            objConn.Open(); //Open the Connection  Step-1

            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_State_SelectAll";

            //objCmd.ExecuteReader();    -------------------//Select
            //objCmd.ExecuteNonQuery();  -------------------//Insert / Update / Delete
            //objCmd.ExecuteScalar();    -------------------//Only One Scalar value is being return
            //objCmd.ExecuteXmlReader(); -------------------//Xml type of data

            SqlDataReader objSDR = objCmd.ExecuteReader();
            gvState.DataSource = objSDR;
            gvState.DataBind();
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
        

        //data source = source of data or server name
        //inital catalog = database name
        //Integrated Security = It true then consider as windows authentication / Else for false have SQL authemntication User ID = abc  Password = aaa
        //Initially userid is SA and password can be set


        
    }
    #endregion Fill State Grid

    #region Row Command : Delete
    protected void gvState_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "DeleteRecord")
        {

            if (e.CommandArgument != "")
            {
                DeleteState(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }

        /*if (e.CommandName == "EditRecord")
        {
            lblMessage.Text = "Edit Button is Clicked";
            
            if (e.CommandArgument != "")
            {
                lblMessage.Text += ",CountryID = " + e.CommandArgument;
            }
        }*/
    }
    #endregion Row Command : Delete

    #region Delete State
    private void DeleteState(SqlInt32 StateID)
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
            objCmd.CommandText = "PR_State_DeleteByPK";
            objCmd.Parameters.AddWithValue("@StateID", StateID.ToString());
            objCmd.ExecuteNonQuery();

            #endregion Set Connection & Command Object

            objConn.Close();
            FillStateGrid();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            objConn.Close();
        }



    }
    #endregion Delete State
}