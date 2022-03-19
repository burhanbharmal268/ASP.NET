using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_ContactCategory_ContactCategoryAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["ContactCategoryID"] != null)
            {
                lblMessage.Text = "Edit Mode | ContactCategoryID = " + Request.QueryString["ContactCategoryID"].ToString();
                FillControls(Convert.ToInt32(Request.QueryString["ContactCategoryID"]));
            }
            else
            {
                lblMessage.Text = "Add Mode";
            }
        }
    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Local Variable
        //Declare Local Variables to Insert Data
        SqlString strContactCategoryName = SqlString.Null;
        SqlDateTime DTCreationDate = SqlDateTime.Null;

        //Validation of data
        //This is known as server side validation
        #region ServerSide Validation
        String strErrorMessage = "";

        if (txtContactCategoryName.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Contact Category Name <br/>";
        }

        if (strErrorMessage != "")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion ServerSide Validation

        //Save the country Data
        //Establishment of Connection
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());
        //OR
        //objConn.ConnectionString = "data source=LAPTOP-HV667SQK\\SQLEXPRESS;initial catalog=AddressBook;Integrated Security=True;";
        #endregion Local Variable
        try
        {
            #region Set Connection & Command Object
            objConn.Open();

            //SqlCommand ObjCmd = new SqlCommand();
            //ObjCmd.Connection = objConn;
            //OR
            //Prepare the Command
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_ContactCategory_Insert";
            #endregion Set Connection & Command Object

            #region Gather Information

            strContactCategoryName = txtContactCategoryName.Text.Trim();

            //Pass The Parameters in the SP
            objCmd.Parameters.AddWithValue("@ContactCategoryName", strContactCategoryName);
            objCmd.Parameters.AddWithValue("@CreationDate", DTCreationDate);

            #endregion Gather Information

            if (Request.QueryString["ContactCategoryID"] != null)
            {
                #region Update Record
                objCmd.Parameters.AddWithValue("@ContactCategoryID", Request.QueryString["ContactCategoryID"].ToString().Trim());
                objCmd.CommandText = "PR_ContactCategory_UpdateByPK";
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/ContactCategory/ContactCategoryList.aspx");
                #endregion Update Record
            }
            else
            {
                #region Add Record
                objCmd.CommandText = "PR_ContactCategory_Insert";
                objCmd.ExecuteNonQuery();
                lblMessage.Text = "Date Inserted Successfully";
                txtContactCategoryName.Text = "";
                txtContactCategoryName.Focus();
                #endregion Add Record


            }

            

            objConn.Close();

            
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
    #endregion Button : Save

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/ContactCategory/ContactCategoryList.aspx");
    }
    #endregion Button : Cancel

    #region Fill Controls
    private void FillControls(SqlInt32 ContactCategoryID)
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
            objCmd.CommandText = "PR_ContactCategory_SelectByPK";
            objCmd.Parameters.AddWithValue("@ContactCategoryID", ContactCategoryID.ToString().Trim());

            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (objSDR["ContactCategoryName"].Equals(DBNull.Value) != true)
                    {
                        txtContactCategoryName.Text = objSDR["ContactCategoryName"].ToString().Trim();
                    }

                    
                    break;
                }
            }
            else
            {
                lblMessage.Text = "No Data available for the ContactCategoryID = " + ContactCategoryID.ToString();
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