using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.TC.Hotel.Module
{
    /// <summary>
    /// 同程酒店游客评论
    /// </summary>
    public class HotelCommentInfo
    {
        /// <summary>
        /// 点评
        /// 1.好评,2.中评,3.差评
        /// </summary>
        public int overallRating { set; get; }

        /// <summary>
        /// 评论内容
        /// </summary>
        public string content { set; get; }

        /// <summary>
        /// 评论时间
        /// </summary>
        public string createDate { set; get; }
    }
}
