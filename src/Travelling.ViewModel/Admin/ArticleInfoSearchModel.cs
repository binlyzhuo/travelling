using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Admin
{
    public class ArticleInfoSearchModel : BasePageQuery
    {
        public DateTime? AddDateBegin { set; get; }
        public DateTime? AddDateEnd { set; get; }
        public int? ArticleType { set; get; }
        public int? State { set; get; }
    }
}
