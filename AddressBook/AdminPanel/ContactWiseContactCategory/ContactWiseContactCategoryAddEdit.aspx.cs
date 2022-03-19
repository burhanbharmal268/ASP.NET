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

public partial class AdminPanel_ContactWiseContactCategory_ContactWiseContactCategoryAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack){
            FillCBLContactWiseContactCategoryID();
        }
    }

    private void FillCBLContactWiseContactCategoryID()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

        try
        {
            objConn.Open();


            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_ContactCategory_SelectAll";

            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                cblContactWiseContactCategoryID.DataSource = objSDR;
                cblContactWiseContactCategoryID.DataValueField = "ContactCategoryID";
                cblContactWiseContactCategoryID.DataTextField = "ContactCategoryName";
                cblContactWiseContactCategoryID.DataBind();
                
            }

        }
        catch(Exception e)
        {
            lblMessage.Text = e.Message;
        }
        finally
        {
            if (objConn.State != ConnectionState.Closed)
            {
                objConn.Close();
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlString strContactWiseName = SqlString.Null;

        String ContactWisePhotoPath = "";
        if (fuContactWisePhotoPath.HasFile)
        {
            ContactWisePhotoPath = "~/UserContent1/" + fuContactWisePhotoPath.FileName.ToString().Trim();

            fuContactWisePhotoPath.SaveAs(Server.MapPath(ContactWisePhotoPath));


        }

        String strErrorMessage = "";

        if (txtContactWiseName.Text.Trim() == "")
        {
            strErrorMessage += "Enter Contact Name</br>";
        }
        //if (!fuContactWisePhotoPath.HasFile)
        //{
        //    strErrorMessage += "Please Upload a file";
        //}

        if (strErrorMessage.Trim() != "")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }

        if (txtContactWiseName.Text.Trim() !="")
        {
            strContactWiseName = txtContactWiseName.Text.Trim();
        }

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

        try
        {
            objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_ContactDummy_Insert";

            objCmd.Parameters.AddWithValue("@ContactName", strContactWiseName);
            objCmd.Parameters.AddWithValue("@ContactPhotoPath", ContactWisePhotoPath);

            objCmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

            objCmd.ExecuteNonQuery();

            txtContactWiseName.Text = "";
            txtContactWiseName.Focus();
            

            SqlInt32 ContactID = 0;
            ContactID = Convert.ToInt32(objCmd.Parameters["@ContactID"].Value);


            foreach (ListItem liContactCategoryID in cblContactWiseContactCategoryID.Items)
            {
                if (liContactCategoryID.Selected)
                {
                    SqlCommand objCmdCategory = objConn.CreateCommand();
                    objCmdCategory.CommandType = CommandType.StoredProcedure;
                    objCmdCategory.CommandText = "PR_ContactWiseContactCategory_Insert";

                    objCmdCategory.Parameters.AddWithValue("@ContactID", ContactID.ToString());
                    objCmdCategory.Parameters.AddWithValue("@ContactCategoryID", liContactCategoryID.Value.ToString());
                    objCmdCategory.ExecuteNonQuery();
                  
                }
                
            }
            cblContactWiseContactCategoryID.ClearSelection();
            objConn.Close();

            lblMessage.Text = "Data Inserted Successfully With ContactID  = " + ContactID.ToString();

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
}