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

public partial class AdminPanel_Contact_ContactAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDownList();
            FillStateDropDownList();
            FillCityDropDownList();
            FillContactCategoryDropDownList();

            if (Request.QueryString["ContactID"] != null)
            {
                lblMessage.Text = "Edit Mode | ContactID = " + Request.QueryString["ContactID"].ToString();
                FillControls(Convert.ToInt32(Request.QueryString["ContactID"]));
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
        #region Server Side Validation

        //Server side Validation 
        String strErrorMessage = "";

        if (ddlCountryID.SelectedIndex == 0)
        {
            strErrorMessage += "- Select Country <br/>";
        }
        if (ddlStateID.SelectedIndex == 0)
        {
            strErrorMessage += "- Select State <br/>";
        }
        if (ddlCityID.SelectedIndex == 0)
        {
            strErrorMessage += "- Select City <br/>";
        }
        if (ddlContactCategoryID.SelectedIndex == 0)
        {
            strErrorMessage += "- Select Contact Category <br/>";
        }
        if (txtContactName.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Contact Name <br/>";
        }
        if (txtContactNo.Text.Trim() == "")
        {
            strErrorMessage += "-Enter Contact No <br/>";
        }
        if (txtEmail.Text.Trim() == "")
        {
            strErrorMessage += "-Enter Email <br/>";
        }
        if (txtAddress.Text.Trim() == "")
        {
            strErrorMessage += "-Enter Address <br/>";
        }

        if (strErrorMessage.Trim() != "")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation


        #region Local Variable
        SqlInt32 strCountryID = SqlInt32.Null;
        SqlInt32 strStateID = SqlInt32.Null;
        SqlInt32 strCityID = SqlInt32.Null;
        SqlInt32 strContactCategoryID = SqlInt32.Null;
        SqlString strContactName = SqlString.Null;
        SqlString strContactNo = SqlString.Null;
        SqlString strEmail = SqlString.Null;
        SqlString strAddress = SqlString.Null;
        SqlDateTime DTCreationDate = SqlDateTime.Null;

       

        //Gather the information



        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());
        #endregion Local Variable
        try
        {
            #region Set Connection & Command Object
            objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Contact_InsertForForm";

            if (ddlCountryID.SelectedIndex > 0)
            {
                strCountryID = Convert.ToInt32(ddlCountryID.SelectedValue);
            }
            if (ddlStateID.SelectedIndex > 0)
            {
                strStateID = Convert.ToInt32(ddlStateID.SelectedValue);
            }
            if (ddlCityID.SelectedIndex > 0)
            {
                strCityID = Convert.ToInt32(ddlCityID.SelectedValue);
            }
            if (ddlContactCategoryID.SelectedIndex > 0)
            {
                strContactCategoryID = Convert.ToInt32(ddlContactCategoryID.SelectedValue);
            }
            if (txtContactName.Text.Trim() != "")
            {
                strContactName = txtContactName.Text.Trim();
            }
            if (txtContactNo.Text.Trim() != "")
            {
                strContactNo = txtContactNo.Text.Trim();
            }
            if (txtEmail.Text.Trim() != "")
            {
                strEmail = txtEmail.Text.Trim();
            }
            if (txtAddress.Text.Trim() != "")
            {
                strAddress = txtAddress.Text.Trim();
            }
            #endregion Set Connection & Command Object

            #region Gather Information

            objCmd.Parameters.AddWithValue("@CountryID", strCountryID);
            objCmd.Parameters.AddWithValue("@StateID", strStateID);
            objCmd.Parameters.AddWithValue("@CityID", strCityID);
            objCmd.Parameters.AddWithValue("@ContactCategoryID", strContactCategoryID);
            objCmd.Parameters.AddWithValue("@ContactName", strContactName);
            objCmd.Parameters.AddWithValue("@ContactNo", strContactNo);
            objCmd.Parameters.AddWithValue("@Email", strEmail);
            objCmd.Parameters.AddWithValue("@Address", strAddress);
            

            #endregion Gather Information

            if (Request.QueryString["ContactID"] != null)
            {
                #region Update Record
                objCmd.Parameters.AddWithValue("@ContactID", Request.QueryString["ContactID"].ToString().Trim());
                objCmd.CommandText = "PR_Contact_UpdateByPK";
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/City/CityList.aspx");
                #endregion Update Record
            }
            else
            {
                #region Add Region
                objCmd.Parameters.AddWithValue("@CreationDate", DTCreationDate);
                objCmd.CommandText = "PR_Contact_InsertForForm";
                objCmd.ExecuteNonQuery();
                lblMessage.Text = "Date Inserted Successfully";
                ddlStateID.SelectedIndex = 0;
                ddlCountryID.SelectedIndex = 0;
                ddlCityID.SelectedIndex = 0;
                ddlContactCategoryID.SelectedIndex = 0;
                txtContactName.Text = "";
                txtContactNo.Text = "";
                txtEmail.Text = "";
                txtAddress.Text = "";
                ddlCountryID.Focus();
                #endregion Add Region

            }
            

            
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
    #endregion Button : Save

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Contact/ContactList.aspx");
    }
    #endregion Button : Cancel

    #region Fill Country DropDown List
    private void FillDropDownList()
    {
        #region Local Variable
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim()); ;
        #endregion Local Variable
        try
        {
            #region Set Connection & Command Object
            objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_SelectForDropDownList";
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows == true)
            {
                ddlCountryID.DataSource = objSDR;
                ddlCountryID.DataValueField = "CountryID";
                ddlCountryID.DataTextField = "CountryName";
                ddlCountryID.DataBind();
            }

            ddlCountryID.Items.Insert(0, new ListItem("Select Country", "-1"));
            #endregion Set Connection & Command Object
            objConn.Close();
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
    #endregion Fill Country DropDown List

    #region Fill State DropDown List
    private void FillStateDropDownList()
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
            objCmd.CommandText = "PR_State_SelectForDropDownList";
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows == true)
            {
                ddlStateID.DataSource = objSDR;
                ddlStateID.DataValueField = "StateID";
                ddlStateID.DataTextField = "StateName";
                ddlStateID.DataBind();
            }

            ddlStateID.Items.Insert(0, new ListItem("Select State", "-1"));
            #endregion Set Connection & Command Object
            objConn.Close();
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
    #endregion Fill State DropDown List

    #region Fill City DropDown List
    private void FillCityDropDownList()
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
            objCmd.CommandText = "PR_City_SelectForDropDownList";
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows == true)
            {
                ddlCityID.DataSource = objSDR;
                ddlCityID.DataValueField = "CityID";
                ddlCityID.DataTextField = "CityName";
                ddlCityID.DataBind();
            }

            ddlCityID.Items.Insert(0, new ListItem("Select City", "-1"));
            #endregion Set Connection & Command Object
            objConn.Close();
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
    #endregion Fill City DropDown List

    #region Fill Contact Category DropDown List
    private void FillContactCategoryDropDownList()
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
            objCmd.CommandText = "PR_ContactCategory_SelectForDropDownList";
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows == true)
            {
                ddlContactCategoryID.DataSource = objSDR;
                ddlContactCategoryID.DataValueField = "ContactCategoryID";
                ddlContactCategoryID.DataTextField = "ContactCategoryName";
                ddlContactCategoryID.DataBind();
            }

            ddlContactCategoryID.Items.Insert(0, new ListItem("Select Contact Category", "-1"));
            #endregion Set Connection & Command Object
            objConn.Close();
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
    #endregion Fill Contact Category DropDown List

    #region Fill Controls
    private void FillControls(SqlInt32 ContactID)
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
            objCmd.CommandText = "PR_Contact_SelectByPK";
            objCmd.Parameters.AddWithValue("@ContactID", ContactID.ToString().Trim());

            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (objSDR["CountryID"].Equals(DBNull.Value) != true)
                    {
                        ddlCountryID.SelectedValue = objSDR["CountryID"].ToString().Trim();
                    }
                    if (objSDR["StateID"].Equals(DBNull.Value) != true)
                    {
                        ddlStateID.SelectedValue = objSDR["StateID"].ToString().Trim();
                    }
                    if (objSDR["CityID"].Equals(DBNull.Value) != true)
                    {
                        ddlCityID.SelectedValue = objSDR["CityID"].ToString().Trim();
                    }
                    if (objSDR["ContactCategoryID"].Equals(DBNull.Value) != true)
                    {
                        ddlContactCategoryID.SelectedValue = objSDR["ContactCategoryID"].ToString().Trim();
                    }
                    if (objSDR["ContactName"].Equals(DBNull.Value) != true)
                    {
                        txtContactName.Text = objSDR["ContactName"].ToString().Trim();
                    }

                    if (objSDR["ContactNo"].Equals(DBNull.Value) != true)
                    {
                        txtContactNo.Text = objSDR["ContactNo"].ToString().Trim();
                    }
                    if (objSDR["Address"].Equals(DBNull.Value) != true)
                    {
                        txtAddress.Text = objSDR["Address"].ToString().Trim();
                    }
                    if (objSDR["Email"].Equals(DBNull.Value) != true)
                    {
                        txtEmail.Text = objSDR["Email"].ToString().Trim();
                    }
                    
                    break;
                }
            }
            else
            {
                lblMessage.Text = "No Data available for the ContactID = " + ContactID.ToString();
            }
            #endregion Set Connection & Command Object
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
    #endregion Fill Controls
   
}
