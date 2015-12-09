using qiniudemo.Codes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace qiniudemo
{
    public partial class upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("just a test!!");
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string bucket = "zjkz78";
            string key = "77889900";
            string fname = @"E:\qiniu\dog.jpg";
            QiuniuHelper.PutFile(bucket,key,fname);
        }

        protected void btnGetFile_Click(object sender, EventArgs e)
        {
            string bucket = "zjkz78";
            QiuniuHelper.GetFile(bucket);
        }


    }
}