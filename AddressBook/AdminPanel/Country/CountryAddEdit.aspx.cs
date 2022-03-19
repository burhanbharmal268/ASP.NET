using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlTypes;
using System.Configuration;

public partial class AdminPanel_Country_CountryAddEdit : System.Web.UI.Page
{

    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {
            
            


        }
            
    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        
        
        String strErrorMessage = "";

        if (txtCountryName.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Contact Name <br/>";
        }
        if (txtCountryCode.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Country Code <br/>";
        }


        if (strErrorMessage != "")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }


        #endregion Server Side Validation

        

        //Validation of data
        //This is known as server side validation

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());
        
        try
        {
            

            

            if (objConn.State != ConnectionState.Open)
            {
                objConn.Open();
            }
            



            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[Pk_Country_Insert]";

            //SqlCommand ObjCmd = new SqlCommand();
            //ObjCmd.Connection = objConn;
            //OR
            //Prepare the Command
            //Pass The Parameters in the SP
            #region GatherInfromation
            objCmd.Parameters.AddWithValue("@CountryName", strCountryName);
            objCmd.Parameters.AddWithValue("@CountryCode", strCountryCode);
            #endregion Gather Information




            //if (Request.QueryString["CountryID"] != null)
            //{
            //    #region Update Record
            //    objCmd.Parameters.AddWithValue("@CountryID", Request.QueryString["CountryID"].ToString().Trim());
            //    objCmd.CommandText = "PK_Country_UpdateByPK";
            //    objCmd.ExecuteNonQuery();
            //    Response.Redirect("~/AdminPanel/Country/CountryList.aspx");
            //    #endregion Update Record
            //}
            //else
            //{
            //    #region Add Record
            //    objCmd.CommandText = "[dbo].[Pk_Country_Insert]";
                objCmd.ExecuteNonQuery();
                lblMessage.Text = "Date Inserted Successfully";
                txtCountryName.Text = "";
                txtCountryCode.Text = "";
                txtCountryName.Focus();
                #endregion Add Record
            }

            objConn.Close();

            
        }
        catch(Exception ex)
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
        //Save the country Data
        //Establishment of Connection
       
        //OR
        //objConn.ConnectionString = "data source=LAPTOP-HV667SQK\\SQLEXPRESS;initial catalog=AddressBook;Integrated Security=True;";

        
    }
    #endregion Button : Save

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Country/CountryList.aspx");
    }
    #endregion Button : Cancel

    #region Fill Country Grid

    private void FillCountryGrid()
    {
        #region Local Variable
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());
        #endregion Local Variable
        try
        {
            #region Set Connection & Command object
            objConn.Open(); //Open the Connection  Step-1

            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_SelectAll";

            //objCmd.ExecuteReader();    -------------------//Select
            //objCmd.ExecuteNonQuery();  -------------------//Insert / Update / Delete
            //objCmd.ExecuteScalar();    -------------------//Only One Scalar value is being return
            //objCmd.ExecuteXmlReader(); -------------------//Xml type of data
            #endregion Set Connection & Command object

            objConn.Close();//Close Connection at end of work
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            objConn.Close();
        }
        //Establish Connection
        //Create Blank Connection object
        

        //data source = source of data or server name
        //inital catalog = database name
        //Integrated Security = It true then consider as windows authentication / Else for false have SQL authemntication User ID = abc  Password = aaa
        //Initially userid is SA and password can be set 

        
    }
    #endregion Fill Country Grid

    #region Fill Controls
    private void FillControls(SqlInt32 CountryID)
    {
        #region Local Variable
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());
        #endregion Local Variable
        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_SelectByPK";
            objCmd.Parameters.AddWithValue("@CountryID", CountryID.ToString().Trim());

            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (objSDR["CountryName"].Equals(DBNull.Value) != true)
                    {
                        txtCountryName.Text = objSDR["CountryName"].ToString().Trim();
                    }

                    if (objSDR["CountryCode"].Equals(DBNull.Value) != true)
                    {
                        txtCountryCode.Text = objSDR["CountryCode"].ToString().Trim();
                    }

                    break;
                }
            }
            else
            {
                lblMessage.Text = "No Data available for the CountryID = " + CountryID.ToString();
            }
            #endregion Set Connection & Command Object
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {

        }
    }
    #endregion Fill Controls
 
}