using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for CommonDropDownFillMethods
/// </summary>
public static class CommonDropDownFillMethods
{
    public static void FillDropDownListCountry(DropDownList ddl, string UserID)
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
            if ("UserID" != null)
                objCmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataReader objSDR = objCmd.ExecuteReader();
            #endregion Set Connection & Commend Object

            #region Fill Data Value In DropDownList
            if (objSDR.HasRows == true)
            {
                ddl.DataSource = objSDR;
                ddl.DataValueField = "CountryID";
                ddl.DataTextField = "CountryName";
                ddl.DataBind();
            }

            ddl.Items.Insert(0, new ListItem("Select Country", "-1"));
            #endregion Fill Data Value In DropDownList

            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }

        catch (Exception ex)
        {
            
        }

        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }


    public static void FillDropDownListState(DropDownList ddl, string UserID)
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
            objCmd.CommandText = "PR_State_SelectForDropDownList";
            if (UserID != null)
                objCmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataReader objSDR = objCmd.ExecuteReader();
            #endregion Set Connection & Commend Object

            #region Fill Data Value In DropDownList
            if (objSDR.HasRows == true)
            {
                ddl.DataSource = objSDR;
                ddl.DataValueField = "StateID";
                ddl.DataTextField = "StateName";
                ddl.DataBind();
            }

            ddl.Items.Insert(0, new ListItem("Select State", "-1"));
            #endregion Fill Data Value In DropDownList

            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }

        catch (Exception ex)
        {
            
        }

        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }

    //public static void FillDropDownCityByState(DropDownList ddl, SqlInt32 StateID)
    //{
    //    #region Local Variables
    //    SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
    //    #endregion Local Variables

    //    try
    //    {
    //        #region Set Connection & Commend Object
    //        if (objConn.State != ConnectionState.Open)
    //            objConn.Open();

    //        SqlCommand objCmd = objConn.CreateCommand();
    //        objCmd.CommandType = CommandType.StoredProcedure;
    //        objCmd.CommandText = "PR_City_SelectDropDownByUserID";
    //        if (Session["UserID"] != null)
    //            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
    //        objCmd.Parameters.AddWithValue("@StateID", ddlState.SelectedValue.ToString());
    //        SqlDataReader objSDR = objCmd.ExecuteReader();
    //        #endregion Set Connection & Commend Object

    //        #region Fill Data Value In DropDownList
    //        if (objSDR.HasRows == true)
    //        {
    //            ddlCity.DataSource = objSDR;
    //            ddlCity.DataValueField = "CityID";
    //            ddlCity.DataTextField = "CityName";
    //            ddlCity.DataBind();
    //        }

    //        ddlCity.Items.Insert(0, new ListItem("Select City", "-1"));
    //        #endregion Fill Data Value In DropDownList

    //        if (objConn.State == ConnectionState.Open)
    //            objConn.Close();
    //    }

    //    catch (Exception ex)
    //    {
    //        lblMessage.Text = ex.Message;
    //    }

    //    finally
    //    {
    //        if (objConn.State == ConnectionState.Open)
    //            objConn.Close();
    //    }
    //}
}