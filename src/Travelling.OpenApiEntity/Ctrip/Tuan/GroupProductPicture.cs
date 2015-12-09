using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.Ctrip.Tuan
{
    public class GroupProductPicture
    {
        public int Category { set; get; }
        public string Title { set; get; }

        public List<GroupProductPictureContent> contents { set; get; }
    }
}
