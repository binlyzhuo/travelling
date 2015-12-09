using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Qiniu;
using Qiniu.IO;
using Qiniu.RS;
using Qiniu.RSF;

namespace qiniudemo.Codes
{
    public class QiuniuHelper
    {
        public static bool PutFile(string bucket,string key,string fname)
        {
            var policy = new PutPolicy(bucket,3600);
            string upToken = policy.Token();
            PutExtra extra = new PutExtra();
            IOClient client = new IOClient();
            var putFile=client.PutFile(upToken,key,fname,extra);
            return putFile.OK;
        }

        public static DumpRet GetFile(string bucket)
        {
            var policy = new PutPolicy(bucket, 3600);
            RSFClient client = new RSFClient(bucket);
            
            var picColl = client.ListPrefix(bucket, DateTime.Now.ToString("yyyyMMdd"), "");
            return picColl;
        }

        public static void MakeGetToken(string domain, string key)
        {
            string baseUrl = GetPolicy.MakeBaseUrl(domain, key);
            string private_url = GetPolicy.MakeRequest(baseUrl);
        }

        
    }
}