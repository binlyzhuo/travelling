using qiniudemo.Codes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace qiniudemo
{
    public partial class qiniueditor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            QiuniuHelper.GetFile("zjkz78");
        }
    }
}