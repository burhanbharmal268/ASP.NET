using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FileUpload_FileUploadDemo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (fuFile.HasFile)
        {
            

            String FolderPath = "~/UserContent/";
            String AbsolutePath = Server.MapPath(FolderPath);

            lblMessage.Text = "File Inserted  " + AbsolutePath;

            if(!Directory.Exists(AbsolutePath))
                Directory.CreateDirectory(AbsolutePath);

            fuFile.SaveAs(AbsolutePath + fuFile.FileName.ToString()); 
        }
        else
        {
            lblMessage.Text = "Please Upload a file";
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        String FilePath = "~/UserContent/imgbur.jpeg";

        FileInfo file = new FileInfo(Server.MapPath(FilePath));

        if (file.Exists)
        {
            file.Delete();
        }
        else
        {
            lblMessage.Text = "File Not Available";
        }
    }
}