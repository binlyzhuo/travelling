using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.Ctrip.Tuan
{
    public class CategoryInfo
    {
        public string Name { set; get; }
        public int ID { set; get; }

        public List<CategoryAttr> CategoryAttrs { set; get; }
    }
}
