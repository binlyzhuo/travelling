using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel
{
    public class AjaxUploadFileViewResult : JsonViewResult
    {
        public string FileName { set; get; }

        public string FileExtend { set; get; }

        public string TempFile { set; get; }
    }
}
