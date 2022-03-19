using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class AdminPanel_State_StateAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {
            FillDropDownList();
            if (Request.QueryString["StateID"] != null)
            {
                lblMessage.Text = "Edit Mode | StateID = " + Request.QueryString["StateID"].ToString();
                FillControls(Convert.ToInt32(Request.QueryString["StateID"]));
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
        #region Loacal Variable
        SqlInt32 strCountryID = SqlInt32.Null;
        SqlString strStateName = SqlString.Null;
        SqlString strStateCode = SqlString.Null;
        SqlDateTime DTCreationDate = SqlDateTime.Null;

        //Server side Validation 
        String strErrorMessage = "";

        if (ddlCountryID.SelectedIndex == 0)
        {
            strErrorMessage += "- Select Country <br/>";
        }
        if (txtStateName.Text.Trim() == "")
        {
            strErrorMessage += "- Enter State Name <br/>";
        }
        if (txtStateCode.Text.Trim() == "")
        {
            strErrorMessage += "-Enter State Code <br/>";
        }

        if (strErrorMessage.Trim() != "")
        {
            lblMessage.Text= strErrorMessage;
            return;
        }

        //Gather the information

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());
        #endregion Loacal Variable
        try
        {
            #region Set Connection & Command Object
            objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_State_Insert";

            if (ddlCountryID.SelectedIndex > 0)
            {
                strCountryID = Convert.ToInt32(ddlCountryID.SelectedValue);
            }
            if (txtStateName.Text.Trim() != "")
            {
                strStateName = txtStateName.Text.Trim();
            }
            if (txtStateCode.Text.Trim() != "")
            {
                strStateCode = txtStateCode.Text.Trim();
            }
            #endregion Set Connection & Command Object

            #region Gather Information 
            objCmd.Parameters.AddWithValue("@CountryID", strCountryID);
            objCmd.Parameters.AddWithValue("@StateName", strStateName);
            objCmd.Parameters.AddWithValue("@StateCode", strStateCode);
            #endregion Gather Information

            if (Request.QueryString["StateID"] != null)
            {
                #region Update Record
                objCmd.Parameters.AddWithValue("@StateID", Request.QueryString["StateID"].ToString().Trim());
                objCmd.CommandText = "PR_State_UpdateByPK";
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/State/StateList.aspx");
                #endregion Update Record
            }
            else
            {
                #region Add Record
                objCmd.CommandText = "PR_State_Insert";
                objCmd.ExecuteNonQuery();
                lblMessage.Text = "Date Inserted Successfully";
                ddlCountryID.SelectedIndex = 0;
                txtStateName.Text = "";
                txtStateCode.Text = "";
                ddlCountryID.Focus();
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
        Response.Redirect("~/AdminPanel/State/StateList.aspx");
    }
    #endregion Button : Cancel

    #region Fill Drop Down List
    private void FillDropDownList()
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
            objConn.Close();
        }

            
    }
    #endregion Fill Drop Down List

    #region Fill Controls
    private void FillControls(SqlInt32 StateID)
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
            objCmd.CommandText = "PR_State_SelectByPK";
            objCmd.Parameters.AddWithValue("@StateID", StateID.ToString().Trim());

            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (objSDR["StateName"].Equals(DBNull.Value) != true)
                    {
                        txtStateName.Text = objSDR["StateName"].ToString().Trim();
                    }

                    if (objSDR["StateCode"].Equals(DBNull.Value) != true)
                    {
                        txtStateCode.Text = objSDR["StateCode"].ToString().Trim();
                    }
                    if (objSDR["CountryID"].Equals(DBNull.Value) != true)
                    {
                        ddlCountryID.SelectedValue = objSDR["CountryID"].ToString().Trim();
                    }
                    break;
                }
            }
            else
            {
                lblMessage.Text = "No Data available for the StateID = " + StateID.ToString();
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
