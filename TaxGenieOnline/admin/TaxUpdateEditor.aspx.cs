using System;
using System.IO;
using TaxGenie_DAL.TaxUpdateTableAdapters;


namespace TaxGenieOnline.admin
{
    public partial class TaxUpdateEditor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            TaxUpdateImgTableAdapter TUContent = new TaxUpdateImgTableAdapter();
            string filename ="/images/TaxUpdate/"+ Path.GetFileName(fuImage.PostedFile.FileName);
            fuImage.SaveAs(Server.MapPath(filename));
            TUContent.Insert(edtTaxUpdate.Content, filename, DateTime.Now);
            Server.Transfer("TaxUpdateEditor.aspx");
        }
    }
}