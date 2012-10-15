using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaxGenie_DAL.HomeContentsTableAdapters;
using System.IO;
using TaxGenie_DAL;

namespace TaxGenieOnline.admin
{
    public partial class HomeContentEditor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblimg.Visible = false;
            actImg.Visible = false;
            EditHomeContents epage = Context.Handler as EditHomeContents;
            if (epage != null)
            {
                hdnId.Value = epage.Id;
            }
            if (hdnId.Value.Length > 0)
            {
                int? id = Int32.Parse(hdnId.Value);
                if (btnUpload.Text != "Update")
                {
                    HomeContentsTableAdapter adptr = new HomeContentsTableAdapter();

                    HomeContents.HomeContentsRow update = adptr.GetContent(id).Rows[0] as HomeContents.HomeContentsRow;
                    ddlContentType.SelectedValue = update.ContentType;
                    txtTitle.Text = update.Title;
                    edtHomeContent.Content = update.Data;
                    lblimg.Visible = true;
                    actImg.Visible = true;
                    actImg.ImageUrl = update.ImgPath;
                    btnUpload.Text = "Update";
                }
            }

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            HomeContentsTableAdapter hContent = new HomeContentsTableAdapter();
            string filename=actImg.ImageUrl;
            if (fuImage.PostedFile != null && fuImage.PostedFile.ContentLength>0)
            {
                filename = "/images/HomeContents/" + Path.GetFileName(fuImage.PostedFile.FileName);
                fuImage.SaveAs(Server.MapPath(filename));
            }

            if (hdnId.Value.Length > 0)
            {
                int? id = Int32.Parse(hdnId.Value);
                hContent.Update(ddlContentType.SelectedValue, txtTitle.Text, edtHomeContent.Content, filename, id);
                Server.Transfer("EditHomeContents.aspx");
            }
            else
            {
                hContent.Insert(ddlContentType.SelectedValue, txtTitle.Text, edtHomeContent.Content, DateTime.Now, filename);
                Server.Transfer("HomeContentEditor.aspx");
            } 
        }

        protected void ddlContentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlContentType.SelectedValue == "Department News" || ddlContentType.SelectedValue == "Case Analysis")
            {
                pnlimg.Visible = false;


            }

            else
            {
                pnlimg.Visible = true;
            }
          
        }
    }
}