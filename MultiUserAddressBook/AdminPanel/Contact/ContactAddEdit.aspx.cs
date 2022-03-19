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
public partial class MultiUserAddressBook_AdminPanel_Contact_ContactAddEdit : System.Web.UI.Page
{
    #region Page Lode
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillCountryDropDownList();
            //FillStateDropDownList();
            //FillCityDropDownList();
            FillContactCategoryDropDownList();
            if (Page.RouteData.Values["ContactID"] != null)
            {
                lblHeader.Text = "Edit Contact | ContactID = " + Page.RouteData.Values["ContactID"].ToString();
                FillControls(Convert.ToInt32(Page.RouteData.Values["ContactID"]));
            }
            else
            {
                lblHeader.Text = "Add Contact";
            }
        }
    }
    #endregion Page Lode

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        addContactData();

    }
    #endregion Button : Save

    #region Fill Country DropDown List
    private void FillCountryDropDownList()
    {
        #region Local Variables
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        #endregion Local Variables

        try
        {
            #region Set Connection & Commend Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_SelectForDropDownList";
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            SqlDataReader objSDR = objCmd.ExecuteReader();
            #endregion Set Connection & Commend Object

            #region Fill Data Value In DropDownList
            if (objSDR.HasRows == true)
            {
                ddlCountry.DataSource = objSDR;
                ddlCountry.DataValueField = "CountryID";
                ddlCountry.DataTextField = "CountryName";
                ddlCountry.DataBind();
            }

            ddlCountry.Items.Insert(0, new ListItem("Select Country", "-1"));
            #endregion Fill Data Value In DropDownList

            if (objConn.State == ConnectionState.Open)
                objConn.Close();
            
        }

        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }

        finally
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion Fill Country DropDown List

    #region Fill State DropDown List
    private void FillStateDropDownList()
    {
        #region Local Variables
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        #endregion Local Variables
        try
        {
            #region Set Connection & Commend Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_State_SelectForDropDownListUserID";
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            SqlDataReader objSDR = objCmd.ExecuteReader();
            #endregion Set Connection & Commend Object

            #region Fill Data Value In DropDownList
            if (objSDR.HasRows == true)
            {
                ddlState.DataSource = objSDR;
                ddlState.DataValueField = "StateID";
                ddlState.DataTextField = "StateName";
                ddlState.DataBind();
            }

            ddlState.Items.Insert(0, new ListItem("Select State", "-1"));
            #endregion Fill Data Value In DropDownList

            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }

        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }

        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion Fill State DropDown List

    #region Fill City DropDown List
    private void FillCityDropDownList()
    {
        #region Local Variables
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        #endregion Local Variables

        try
        {
            #region Set Connection & Commend Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_City_SelectForDropDownListUserID";
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            SqlDataReader objSDR = objCmd.ExecuteReader();
            #endregion Set Connection & Commend Object

            #region Fill Data Value In DropDownList
            if (objSDR.HasRows == true)
            {
                ddlCity.DataSource = objSDR;
                ddlCity.DataValueField = "CityID";
                ddlCity.DataTextField = "CityName";
                ddlCity.DataBind();
            }

            ddlCity.Items.Insert(0, new ListItem("Select City", "-1"));
            #endregion Fill Data Value In DropDownList

            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }

        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }

        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion Fill City DropDown List

    #region Fill ContactCategory DropDown List
    private void FillContactCategoryDropDownList()
    {
        #region Local Variables
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        #endregion Local Variables

        try
        {
            #region Set Connection & Commend Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_ContactCategory_SelectForDropDownListUserID";
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            SqlDataReader objSDR = objCmd.ExecuteReader();
            #endregion Set Connection & Commend Object

            #region Fill Data Value In DropDownList
            if (objSDR.HasRows == true)
            {
                ddlContactCategory.DataSource = objSDR;
                ddlContactCategory.DataValueField = "ContactCategoryID";
                ddlContactCategory.DataTextField = "ContactCategoryName";
                ddlContactCategory.DataBind();
            }

            ddlContactCategory.Items.Insert(0, new ListItem("Select ContactCategory", "-1"));
            #endregion Fill Data Value In DropDownList

            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }

        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }

        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion Fill ContactCategory DropDown List

    #region Add Contact Data
    private void  addContactData()
    {

        String ContactPhotoPath = "";
        if (fuContactPhotoPath.HasFile)
        {
            ContactPhotoPath = "~/UserContent/" + fuContactPhotoPath.FileName.ToString().Trim();

            fuContactPhotoPath.SaveAs(Server.MapPath(ContactPhotoPath));

            System.Drawing.Image img = System.Drawing.Image.FromStream(fuContactPhotoPath.PostedFile.InputStream);

            decimal size = Math.Round(((decimal)fuContactPhotoPath.PostedFile.ContentLength / (decimal)1024), 2);

            string FileExt = System.IO.Path.GetExtension(fuContactPhotoPath.PostedFile.FileName);
            string ext = Path.GetExtension(FileExt);

            int ActualWidth = img.Width;


            String Attribute = "";

            Attribute = "FileSize " + size + " KB <br/>" +
                "File Extension" + ext;

            if(!Directory.Exists(Server.MapPath("~/UserContent/")))
            {
                Directory.CreateDirectory(Server.MapPath("~/UserContent/"));
            }


        }
        #region Local Variables
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        SqlInt32 StrCountryId = SqlInt32.Null;
        SqlInt32 StrStateId = SqlInt32.Null;
        SqlInt32 StrCityId = SqlInt32.Null;
        SqlInt32 StrContactCategoryId = SqlInt32.Null;
        SqlString StrContactName = SqlString.Null;
        SqlString StrContactNo = SqlString.Null;
        SqlString StrEmail = SqlString.Null;
        SqlInt32 StrAge = SqlInt32.Null;
        SqlString StrAddress = SqlString.Null;
        #endregion Local Variables

        try
        {
            #region Server Side Validation
            string StrErrorMessage = "";

            if (ddlCountry.SelectedIndex == 0)
            {
                StrErrorMessage += "- Select Country <br /><br />";
            }
            if (ddlState.SelectedIndex == 0)
            {
                StrErrorMessage += "- Select State <br /><br />";
            }
            if (ddlCity.SelectedIndex == 0)
            {
                StrErrorMessage += "- Select City <br /><br />";
            }
            if (ddlContactCategory.SelectedIndex == 0)
            {
                StrErrorMessage += "- Select Contact Category <br /><br />";
            }
            if (txtContactName.Text.Trim() == "")
            {
                StrErrorMessage += "- Enter Contact Name <br /><br />";
            }
            if (txtContactNo.Text.Trim() == "")
            {
                StrErrorMessage += "- Enter Contact No. <br /><br />";
            }
            if (txtEmail.Text.Trim() == "")
            {
                StrErrorMessage += "- Enter Email ID <br /><br />";
            }
            if (txtAddress.Text.Trim() == "")
            {
                StrErrorMessage += "- Enter Address <br /><br />";
            }
            if (txtAge.Text.Trim() == "")
            {
                StrErrorMessage += "- Enter Age <br /><br />";
            }

            if (StrErrorMessage != "")
            {
                lblMessage.Text = StrErrorMessage;
                return;
            }
            #endregion Server Side Validation

            #region Gather Information
            if (ddlCountry.SelectedIndex > 0)
                StrCountryId = Convert.ToInt32(ddlCountry.SelectedValue);

            if (ddlState.SelectedIndex > 0)
                StrStateId = Convert.ToInt32(ddlState.SelectedValue);

            if (ddlCity.SelectedIndex > 0)
                StrCityId = Convert.ToInt32(ddlCity.SelectedValue);

            if (ddlContactCategory.SelectedIndex > 0)
                StrContactCategoryId = Convert.ToInt32(ddlContactCategory.SelectedValue);

            if (txtContactName.Text.Trim() != "")
                StrContactName = txtContactName.Text.Trim();

            if (txtContactNo.Text.Trim() != "")
                StrContactNo = txtContactNo.Text.Trim();

            if (txtEmail.Text.Trim() != "")
                StrEmail = txtEmail.Text.Trim();

            if (txtAge.Text.Trim() != "")
                StrAge = Convert.ToInt32(txtAge.Text.Trim());

            if (txtAddress.Text.Trim() != "")
                StrAddress = txtAddress.Text.Trim();

            #endregion Gather Information

            #region Set Connection & Commend Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;

            if (Session["UserId"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserId"]);
            objCmd.Parameters.AddWithValue("@CountryID", StrCountryId);
            objCmd.Parameters.AddWithValue("@StateID", StrStateId);
            objCmd.Parameters.AddWithValue("@CityID", StrCityId);
            objCmd.Parameters.AddWithValue("@ContactCategoryID", StrContactCategoryId);
            objCmd.Parameters.AddWithValue("@ContactName", StrContactName);
            objCmd.Parameters.AddWithValue("@ContactNo", StrContactNo);
            objCmd.Parameters.AddWithValue("@Email", StrEmail);
            objCmd.Parameters.AddWithValue("@Age", StrAge);
            objCmd.Parameters.AddWithValue("@Address", StrAddress);
            objCmd.Parameters.AddWithValue("@ContactPhotoPath", ContactPhotoPath);
            #endregion Set Connection & Commend Object

            if (Page.RouteData.Values["ContactID"] != null)
            {
                #region Update Record

                objCmd.CommandText = "PR_Contact_UpdateByUserID";

                objCmd.Parameters.AddWithValue("ContactID", Page.RouteData.Values["ContactID"].ToString().Trim());
                //if (fuContactPhotoPath == null)
                //{
                //    //using (ClearanceModels dbModel = new ClearanceModels())
                //    //{
                //    //    dbModel.Entry(clearanceDB).State = EntityState.Modified;
                //    //    dbModel.Entry(clearanceDB).Property(p => p.picture).IsModified = false;
                //    //    dbModel.SaveChanges();
                //    //}
                    
                //}
                objCmd.ExecuteNonQuery();
                Response.Redirect("/AdminPanel/Contact/List");
                #endregion Update Record
            }
            else
            {
                #region Insert Record
                objCmd.CommandText = "PR_Contact_Insert";
                objCmd.ExecuteNonQuery();
                lblMessage.Text = "Data Inserted Successfully <br /><br />";
                ddlCountry.SelectedIndex = 0;
                ddlState.SelectedIndex = 0;
                ddlCity.SelectedIndex = 0;
                ddlContactCategory.SelectedIndex = 0;
                txtContactName.Text = "";
                txtContactNo.Text = "";
                txtEmail.Text = "";
                txtAge.Text = "";
                txtAddress.Text = "";
                ddlCountry.Focus();
                #endregion Insert Record
            }

            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }

        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion Add Contact Data

    #region Fill Controls
    private void FillControls(SqlInt32 ContactID)
    {
        #region Local Variables
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        #endregion Local Variables

        try
        {
            #region Set Connection & Commend Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();

            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Contact_SelectByUserIDContactID";
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            objCmd.Parameters.AddWithValue("@ContactID", Page.RouteData.Values["ContactID"].ToString().Trim());
            #endregion Set Connection & Commend Object

            #region Read the value and set the controls
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["CountryID"].Equals(DBNull.Value))
                    {
                        ddlCountry.SelectedValue = objSDR["CountryID"].ToString().Trim();
                    }
                    FillStateDropDownList();
                    if (!objSDR["StateID"].Equals(DBNull.Value))
                    {
                        ddlState.SelectedValue = objSDR["StateID"].ToString().Trim();
                    }
                    FillCityDropDownList();
                    if (!objSDR["CityID"].Equals(DBNull.Value))
                    {
                        ddlCity.SelectedValue = objSDR["CityID"].ToString().Trim();
                    }
                    if (!objSDR["ContactCategoryID"].Equals(DBNull.Value))
                    {
                        ddlContactCategory.SelectedValue = objSDR["ContactCategoryID"].ToString().Trim();
                    }
                    if (!objSDR["ContactName"].Equals(DBNull.Value))
                    {
                        txtContactName.Text = objSDR["ContactName"].ToString().Trim();
                    }
                    if (!objSDR["ContactNo"].Equals(DBNull.Value))
                    {
                        txtContactNo.Text = objSDR["ContactNo"].ToString().Trim();
                    }
                    if (!objSDR["ContactNo"].Equals(DBNull.Value))
                    {
                        txtContactNo.Text = objSDR["ContactNo"].ToString().Trim();
                    } 
                    if (!objSDR["Email"].Equals(DBNull.Value))
                    {
                        txtEmail.Text = objSDR["Email"].ToString().Trim();
                    }
                    if (!objSDR["Age"].Equals(DBNull.Value))
                    {
                        txtAge.Text = objSDR["Age"].ToString().Trim();
                    }
                    if (!objSDR["Address"].Equals(DBNull.Value))
                    {
                        txtAddress.Text = objSDR["Address"].ToString().Trim();
                    } 
                    
                    break;
                }
            }
            else
            {
                lblMessage.Text = "No data available for the ContactID = " + ContactID.ToString();
            }
            #endregion Read the value and set the controls

            if (objConn.State == ConnectionState.Open)
                objConn.Close();

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }

        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion Fill Controls

    #region Bind State
    private void BindState()
    {
        #region Local Variables
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        #endregion Local Variables
        try
        {
            #region Set Connection & Commend Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_State_SelectDropDownByUserID";
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            objCmd.Parameters.AddWithValue("@CountryID", ddlCountry.SelectedValue.ToString());
            SqlDataReader objSDR = objCmd.ExecuteReader();
            #endregion Set Connection & Commend Object

            #region Fill Data Value In DropDownList
            if (objSDR.HasRows == true)
            {
                ddlState.DataSource = objSDR;
                ddlState.DataValueField = "StateID";
                ddlState.DataTextField = "StateName";
                ddlState.DataBind();
            }

            ddlState.Items.Insert(0, new ListItem("Select State", "-1"));
            #endregion Fill Data Value In DropDownList

            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }

        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }

        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion Bind State

    #region Bind City
    private void BindCity()
    {
        #region Local Variables
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        #endregion Local Variables

        try
        {
            #region Set Connection & Commend Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_City_SelectDropDownByUserID";
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            objCmd.Parameters.AddWithValue("@StateID", ddlState.SelectedValue.ToString());
            SqlDataReader objSDR = objCmd.ExecuteReader();
            #endregion Set Connection & Commend Object

            #region Fill Data Value In DropDownList
            if (objSDR.HasRows == true)
            {
                ddlCity.DataSource = objSDR;
                ddlCity.DataValueField = "CityID";
                ddlCity.DataTextField = "CityName";
                ddlCity.DataBind();
            }

            ddlCity.Items.Insert(0, new ListItem("Select City", "-1"));
            #endregion Fill Data Value In DropDownList

            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }

        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }

        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }

    #endregion Bind City

    #region Selected Index Change | Country
    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlState.Items.Clear();
        BindState();
    }
    #endregion Selected Index Change | Country

    #region Selected Index Change | State
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCity.Items.Clear();
        BindCity();
    }
    #endregion Selected Index Change | State
}