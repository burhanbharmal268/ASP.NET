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

public partial class AdminPanel_City_CityAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillStateDropDownList();

            if (Request.QueryString["CityID"] != null)
            {
                lblMessage.Text = "Edit Mode | CityID = " + Request.QueryString["CityID"].ToString();
                //FillControls(Convert.ToInt32(Request.QueryString["CityID"]));
                FillControls(Convert.ToInt32(Request.QueryString["CityID"]));
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
        SqlInt32 strStateID = SqlInt32.Null;
        SqlString strCityName = SqlString.Null;
        SqlString strSTDCode = SqlString.Null;
        SqlString strPINCode = SqlString.Null;
        SqlDateTime DTCreationDate = SqlDateTime.Null;

        //Server side Validation 
        

        //Gather the information

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());
        #endregion Local Variable
        try
        {
            #region ServerSide Validaton
            String strErrorMessage = "";

            if (ddlStateID.SelectedIndex == 0)
            {
                strErrorMessage += "- Select State <br/>";
            }
            if (txtCityName.Text.Trim() == "")
            {
                strErrorMessage += "- Enter City Name <br/>";
            }
            if (txtSTDCode.Text.Trim() == "")
            {
                strErrorMessage += "-Enter STD Code <br/>";
            }
            if (txtPINCode.Text.Trim() == "")
            {
                strErrorMessage += "-Enter PIN Code <br/>";
            }

            if (strErrorMessage.Trim() != "")
            {
                lblMessage.Text = strErrorMessage;
                return;
            }
            #endregion ServerSide Validaton

            #region Set Connection & Command Object
            objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_City_Insert";
            #endregion Set Connection & Command Object

            #region Gather Information
            if (ddlStateID.SelectedIndex > 0)
            {
                strStateID = Convert.ToInt32(ddlStateID.SelectedValue);
            }
            if (txtCityName.Text.Trim() != "")
            {
                strCityName = txtCityName.Text.Trim();
            }
            if (txtSTDCode.Text.Trim() != "")
            {
                strSTDCode = txtSTDCode.Text.Trim();
            }
            if (txtPINCode.Text.Trim() != "")
            {
                strPINCode = txtPINCode.Text.Trim();
            }

            objCmd.Parameters.AddWithValue("@StateID", strStateID);
            objCmd.Parameters.AddWithValue("@CityName", strCityName);
            objCmd.Parameters.AddWithValue("@STDCode", strSTDCode);
            objCmd.Parameters.AddWithValue("@PINCode", strPINCode);
            #endregion Gather Information

            if (Request.QueryString["CityID"] != null)
            {
                #region Update Record
                objCmd.Parameters.AddWithValue("@CityID", Request.QueryString["CityID"].ToString().Trim());
                objCmd.CommandText = "[dbo].[PR_City_UpdateByPK]";
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/City/CityList.aspx");
                #endregion Update Record
            }
            else
            {
                #region Add Record
                objCmd.Parameters.AddWithValue("@CreationDate", DTCreationDate);
                objCmd.CommandText = "PR_City_Insert";
                objCmd.ExecuteNonQuery();
                lblMessage.Text = "Date Inserted Successfully";
                ddlStateID.SelectedIndex = 0;
                txtCityName.Text = "";
                txtSTDCode.Text = "";
                txtPINCode.Text = "";
                ddlStateID.Focus();
                #endregion Add Record

            }
            
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
        

        
    }

    #endregion Button : Save

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/City/CityList.aspx");
    }
    #endregion Button : Cancel

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
            objConn.Close();
        }
        
    }
    #endregion Fill State DropDown List

    #region Fill Controls
    private void FillControls(SqlInt32 CityID)
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
            objCmd.CommandText = "PR_City_SelectByPK";
            objCmd.Parameters.AddWithValue("@CityID", CityID.ToString().Trim());

            SqlDataReader objSDR = objCmd.ExecuteReader();
            #endregion Set Connection & Command Object

            #region Gather Information
            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {

                    if (objSDR["StateID"].Equals(DBNull.Value) != true)
                    {
                        ddlStateID.SelectedValue = objSDR["StateID"].ToString().Trim();
                    }

                    if (objSDR["CityName"].Equals(DBNull.Value) != true)
                    {
                        txtCityName.Text = objSDR["CityName"].ToString().Trim();
                    }

                    if (objSDR["STDCode"].Equals(DBNull.Value) != true)
                    {
                        txtSTDCode.Text = objSDR["STDCode"].ToString().Trim();
                    }
                    if (objSDR["PINCode"].Equals(DBNull.Value) != true)
                    {
                        txtPINCode.Text = objSDR["PINCode"].ToString().Trim();
                    }
                    
                    break;
                    
                }
            }
            else
            {
                lblMessage.Text = "No Data available for the CityID = " + CityID.ToString();
            }
            #endregion Gather Information
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