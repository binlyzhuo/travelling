using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Setting
{
    public class JobTaskSearchModel:BasePageQuery
    {
        public string JobName { set; get; }
        public int? JobState { set; get; }
    }
}
