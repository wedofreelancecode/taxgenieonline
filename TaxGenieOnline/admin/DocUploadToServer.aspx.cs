using System;
using System.IO;
using TaxGenie_DAL.TaxUpdateTableAdapters;
using System.Data;


namespace TaxGenieOnline.admin
{
    public partial class DocUploadToServer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(Server.MapPath("~/TGOL/Documents"));
            FileInfo[] fileInfo = dirInfo.GetFiles("*.*", SearchOption.AllDirectories);
            DataTable dtFiles = new DataTable();
            dtFiles.Columns.Add("href");
            for(int i=0;i<fileInfo.Length && i<50;i++)
            {
                dtFiles.Rows.Add(this.ResolveClientUrl("~/TGOL/Documents/" + fileInfo[i].Name));
            }
            dlDocs.DataSource = dtFiles;
            dlDocs.DataBind();
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string filename = "/TGOL/Documents/" + Path.GetFileName(fuDoc.PostedFile.FileName);
            fuDoc.SaveAs(Server.MapPath(filename));
        }
    }
}