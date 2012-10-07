﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaxGenie_DAL.HomeContentsTableAdapters;
using System.IO;

namespace TaxGenieOnline.admin
{
    public partial class HomeContentEditor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            HomeContentsTableAdapter hContent = new HomeContentsTableAdapter();
            string filename ="/images/HomeContents/"+ Path.GetFileName(fuImage.PostedFile.FileName);
            fuImage.SaveAs(Server.MapPath(filename));
            hContent.Insert(ddlContentType.SelectedValue, txtTitle.Text, edtHomeContent.Content, DateTime.Now, filename);
            Server.Transfer("HomeContentEditor.aspx");
        }

        protected void ddlContentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ddlContentType.SelectedValue == "Department News")
            //{
            //    lblTitle.Visible = true;
            //    txtTitle.Visible = true;
            //}
            //else
            //{
            //    lblTitle.Visible = false;
            //    txtTitle.Visible = false;
            //}
        }
    }
}