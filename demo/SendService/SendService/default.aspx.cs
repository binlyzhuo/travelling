using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CodeScales;
using CodeScales.Http;
using CodeScales.Http.Methods;
using CodeScales.Http.Entity;
using CodeScales.Http.Entity.Mime;
using System.Text;

namespace SendService
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Send();
            try
            {
                int num = 1;
                int num2 = 0;
                int num3 = num / num2;
            }
            catch(Exception ex)
            {
                Send(ex.Message,ex.StackTrace);
            }
        }

        public void Send(string error,string errorstack)
        {
            HttpClient client = new HttpClient();
            HttpPost postMethod = new HttpPost(new Uri("http://sendcloud.sohu.com/webapi/mail.send_template.xml"));
            MultipartEntity multipartEntity = new MultipartEntity();
            postMethod.Entity = multipartEntity;
            multipartEntity.AddBody(new StringBody(Encoding.UTF8, "template_invoke_name", "zjkz78_error_report"));
            multipartEntity.AddBody(new StringBody(Encoding.UTF8, "substitution_vars", "{\"to\": [\"qq111@outlook.com\"], \"sub\" : { \"%errormsg%\" : [\"" + error + "\"],\"%errorstack%\":[\"" + errorstack + "\"]}}"));
            multipartEntity.AddBody(new StringBody(Encoding.UTF8, "api_user", "aaa"));
            multipartEntity.AddBody(new StringBody(Encoding.UTF8, "api_key", "aaa"));
            multipartEntity.AddBody(new StringBody(Encoding.UTF8, "from", "aa@zjkz78.com"));
            multipartEntity.AddBody(new StringBody(Encoding.UTF8, "fromname", "卓家客栈"));
            multipartEntity.AddBody(new StringBody(Encoding.UTF8, "subject", "卓家客栈系统报错"));
            CodeScales.Http.Methods.HttpResponse response = client.Execute(postMethod);

            //Console.WriteLine("Response Code: " + response.ResponseCode);
            //Console.WriteLine("Response Content: " + EntityUtils.ToString(response.Entity));

            Response.Write("Response Code: " + response.ResponseCode);
            Response.Write("<br/>");
            Response.Write("Response Content: " + EntityUtils.ToString(response.Entity));

        }
    }
}