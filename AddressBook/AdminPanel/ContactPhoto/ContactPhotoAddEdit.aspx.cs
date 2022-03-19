using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_ContactPhoto_ContactPhotoAddEdit : System.Web.UI.Page
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
        String ContactPhotoPath = "";
        if (fuContactPhotoPath.HasFile)
        {
            ContactPhotoPath = "~/UserContent/" + fuContactPhotoPath.FileName.ToString().Trim();

            fuContactPhotoPath.SaveAs(Server.MapPath(ContactPhotoPath));

            
        }

        

        #region Server Side Validation

        //Server side Validation 
        String strErrorMessage = "";

        
        if (txtContactName.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Contact Name <br/>";
        }

        if (!fuContactPhotoPath.HasFile)
        {
            strErrorMessage += "- Please Upload a file <br/>";
        }
        
        if (strErrorMessage.Trim() != "")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation


        #region Local Variable
        SqlString strContactName = SqlString.Null;

       

        //Gather the information



        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());
        #endregion Local Variable
        try
        {
            #region Set Connection & Command Object
            objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_ContactPhoto_InsertForPhoto";

            
            if (txtContactName.Text.Trim() != "")
            {
                strContactName = txtContactName.Text.Trim();
            }
            
            #endregion Set Connection & Command Objec t

            #region Gather Information


            objCmd.Parameters.AddWithValue("@ContactName", strContactName);
            objCmd.Parameters.AddWithValue("@ContactPhotoPath", ContactPhotoPath);
            

            #endregion Gather Information

                objCmd.ExecuteNonQuery();
                lblMessage.Text = "Date Inserted Successfully";
                txtContactName.Text = "";
                txtContactName.Focus();

            
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
        Response.Redirect("~/AdminPanel/ContactPhoto/ContactPhotoList.aspx");
    }
    #endregion Button : Cancel

    //#region Fill Country DropDown List
    //private void FillDropDownList()
    //{
    //    #region Local Variable
    //    SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim()); ;
    //    #endregion Local Variable
    //    try
    //    {
    //        #region Set Connection & Command Object
    //        objConn.Open();

    //        SqlCommand objCmd = objConn.CreateCommand();
    //        objCmd.CommandType = CommandType.StoredProcedure;
    //        objCmd.CommandText = "PR_Country_SelectForDropDownList";
    //        SqlDataReader objSDR = objCmd.ExecuteReader();

    //        if (objSDR.HasRows == true)
    //        {
    //            ddlCountryID.DataSource = objSDR;
    //            ddlCountryID.DataValueField = "CountryID";
    //            ddlCountryID.DataTextField = "CountryName";
    //            ddlCountryID.DataBind();
    //        }

    //        ddlCountryID.Items.Insert(0, new ListItem("Select Country", "-1"));
    //        #endregion Set Connection & Command Object
    //        objConn.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //        lblMessage.Text = ex.Message;
    //    }
    //    finally
    //    {
    //        if (objConn.State != ConnectionState.Closed)
    //        {
    //            objConn.Close();
    //        }
            
    //    }
       
    //}
    //#endregion Fill Country DropDown List

    //#region Fill State DropDown List
    //private void FillStateDropDownList()
    //{
    //    #region Local Variable
    //    SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());
    //    #endregion Local Variable
    //    try
    //    {
    //        #region Set Connection & Command Object
    //        objConn.Open();

    //        SqlCommand objCmd = objConn.CreateCommand();
    //        objCmd.CommandType = CommandType.StoredProcedure;
    //        objCmd.CommandText = "PR_State_SelectForDropDownList";
    //        SqlDataReader objSDR = objCmd.ExecuteReader();

    //        if (objSDR.HasRows == true)
    //        {
    //            ddlStateID.DataSource = objSDR;
    //            ddlStateID.DataValueField = "StateID";
    //            ddlStateID.DataTextField = "StateName";
    //            ddlStateID.DataBind();
    //        }

    //        ddlStateID.Items.Insert(0, new ListItem("Select State", "-1"));
    //        #endregion Set Connection & Command Object
    //        objConn.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //        lblMessage.Text = ex.Message;
    //    }
    //    finally
    //    {
    //        if (objConn.State != ConnectionState.Closed)
    //        {
    //            objConn.Close();
    //        }
            
    //    }
        
    //}
    //#endregion Fill State DropDown List

    //#region Fill City DropDown List
    //private void FillCityDropDownList()
    //{
    //    #region Local Variable
    //    SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());
    //    #endregion Local Variable
    //    try
    //    {
    //        #region Set Connection & Command Object
    //        objConn.Open();

    //        SqlCommand objCmd = objConn.CreateCommand();
    //        objCmd.CommandType = CommandType.StoredProcedure;
    //        objCmd.CommandText = "PR_City_SelectForDropDownList";
    //        SqlDataReader objSDR = objCmd.ExecuteReader();

    //        if (objSDR.HasRows == true)
    //        {
    //            ddlCityID.DataSource = objSDR;
    //            ddlCityID.DataValueField = "CityID";
    //            ddlCityID.DataTextField = "CityName";
    //            ddlCityID.DataBind();
    //        }

    //        ddlCityID.Items.Insert(0, new ListItem("Select City", "-1"));
    //        #endregion Set Connection & Command Object
    //        objConn.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //        lblMessage.Text = ex.Message;
    //    }
    //    finally
    //    {
    //        if (objConn.State != ConnectionState.Closed)
    //        {
    //            objConn.Close();
    //        }
            
    //    }
        
    //}
    //#endregion Fill City DropDown List

    //#region Fill Contact Category DropDown List
    //private void FillContactCategoryDropDownList()
    //{
    //    #region Local Variable
    //    SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());
    //    #endregion Local Variable
    //    try
    //    {
    //        #region Set Connection & Command Object
    //        objConn.Open();

    //        SqlCommand objCmd = objConn.CreateCommand();
    //        objCmd.CommandType = CommandType.StoredProcedure;
    //        objCmd.CommandText = "PR_ContactCategory_SelectForDropDownList";
    //        SqlDataReader objSDR = objCmd.ExecuteReader();

    //        if (objSDR.HasRows == true)
    //        {
    //            ddlContactCategoryID.DataSource = objSDR;
    //            ddlContactCategoryID.DataValueField = "ContactCategoryID";
    //            ddlContactCategoryID.DataTextField = "ContactCategoryName";
    //            ddlContactCategoryID.DataBind();
    //        }

    //        ddlContactCategoryID.Items.Insert(0, new ListItem("Select Contact Category", "-1"));
    //        #endregion Set Connection & Command Object
    //        objConn.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //        lblMessage.Text = ex.Message;
    //    }
    //    finally
    //    {
    //        if (objConn.State != ConnectionState.Closed)
    //        {
    //            objConn.Close();
    //        }
            
    //    }
        
    //}
    //#endregion Fill Contact Category DropDown List

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
            objCmd.CommandText = "PR_ContactPhoto_SelectByPK";
            objCmd.Parameters.AddWithValue("@ContactPhotoID", ContactID.ToString().Trim());

            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    
                    if (objSDR["ContactName"].Equals(DBNull.Value) != true)
                    {
                        txtContactName.Text = objSDR["ContactName"].ToString().Trim();
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
