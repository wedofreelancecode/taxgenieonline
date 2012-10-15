using System;
using TaxGenie_DAL;
using TaxGenie_DAL.TaxUpdateTableAdapters;

namespace TaxGenieOnline
{
    public partial class ViewTaxUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TaxUpdateImgTableAdapter contAdptr = new TaxUpdateImgTableAdapter();
            int id = int.Parse(Request.QueryString["Id"]);
            TaxUpdate.TaxUpdateImgDataTable data = contAdptr.GetDataByID(id);
            TaxUpdate.TaxUpdateImgRow dr = data.Rows[0] as TaxUpdate.TaxUpdateImgRow;
            if (dr.ImgPath == null || dr.ImgPath=="")
            {
                imgTU.Visible = false;
            }
            else
            {
                imgTU.Visible = true;
                imgTU.ImageUrl = dr.ImgPath;
            }
            
            lbldata.Text = dr.Data;
            lblTitle.Text = dr.Title;
        }
    }
}