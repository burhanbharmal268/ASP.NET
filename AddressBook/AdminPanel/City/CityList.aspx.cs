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

public partial class AdminPanel_City_CityList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillCityGrid();
        }
    }
    #endregion Load Event

    #region Fill City Grid
    private void FillCityGrid()
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
            objCmd.CommandText = "PR_City_SelectAll";

            //objCmd.ExecuteReader();    -------------------//Select
            //objCmd.ExecuteNonQuery();  -------------------//Insert / Update / Delete
            //objCmd.ExecuteScalar();    -------------------//Only One Scalar value is being return
            //objCmd.ExecuteXmlReader(); -------------------//Xml type of data

            SqlDataReader objSDR = objCmd.ExecuteReader();
            gvCity.DataSource = objSDR;
            gvCity.DataBind();
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
    #endregion Fill City Grid

    #region Row Command : Delete
    protected void gvCity_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {

            if (e.CommandArgument != "")
            {
                DeleteCity(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }
    }
    #endregion Row Command : Delete

    #region Delete City
    private void DeleteCity(SqlInt32 CityID)
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
            objCmd.CommandText = "PR_City_DeleteByPK";
            objCmd.Parameters.AddWithValue("@CityID", CityID.ToString());
            objCmd.ExecuteNonQuery();

            #endregion Set Connection & Command Object

            objConn.Close();
            FillCityGrid();
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
    #endregion Delete City
}