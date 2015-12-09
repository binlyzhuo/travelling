using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Ticket
{
    /// <summary>
    /// 图片尺寸
    /// 完整图片的地址按如下方式拼接而成
    /// imageUrl = imageBaseUrl + sizeCode + "/" + imagePath
    /// </summary>
    public class SceneryImgSizeCode
    {
        /// <summary>
        /// 
        /// </summary>
        public int Size { set; get; }
        public string SizeValue { set; get; }

        /// <summary>
        /// 是否是默认图片
        /// </summary>
        public string IsDefault { set; get; }
    }
}
