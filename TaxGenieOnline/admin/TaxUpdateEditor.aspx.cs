using System;
using System.IO;
using TaxGenie_DAL.TaxUpdateTableAdapters;
using TaxGenie_DAL;


namespace TaxGenieOnline.admin
{
    public partial class TaxUpdateEditor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblimg.Visible = false;
            actImg.Visible = false;
            EditTaxUpdate epage = Context.Handler as EditTaxUpdate;
            if (epage != null)
            {
                hdnId.Value = epage.Id;
            }
            if (hdnId.Value.Length > 0)
            {
                int? id = Int32.Parse(hdnId.Value);
                if (btnUpload.Text != "Update")
                {
                    TaxUpdateImgTableAdapter adptr = new TaxUpdateImgTableAdapter();
                    TaxUpdate.TaxUpdateImgRow update = adptr.GetDataByID(id).Rows[0] as TaxUpdate.TaxUpdateImgRow;
                    txtTitle.Text = update.Title;
                    edtTaxUpdate.Content = update.Data;
                    lblimg.Visible = true;
                    actImg.Visible = true;
                    actImg.ImageUrl = update.ImgPath;
                    btnUpload.Text = "Update";
                }
            }
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            TaxUpdateImgTableAdapter hContent = new TaxUpdateImgTableAdapter();
            string filename = actImg.ImageUrl;
            if (fuImage.PostedFile != null && fuImage.PostedFile.ContentLength > 0)
            {
                filename = "/images/TaxUpdate/" + Path.GetFileName(fuImage.PostedFile.FileName);
                fuImage.SaveAs(Server.MapPath(filename));
            }

            if (hdnId.Value.Length > 0)
            {
                int? id = Int32.Parse(hdnId.Value);
                hContent.Update(edtTaxUpdate.Content, txtTitle.Text, filename, id);
                Server.Transfer("EditTaxUpdate.aspx");
            }
            else
            {
                hContent.Insert(edtTaxUpdate.Content, txtTitle.Text, filename, DateTime.Now);
                Server.Transfer("TaxUpdateEditor.aspx");
            } 
        }
    }
}