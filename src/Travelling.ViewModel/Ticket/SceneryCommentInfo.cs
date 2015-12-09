using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Ticket
{
    /// <summary>
    /// 景区点评信息
    /// </summary>
    public class SceneryCommentInfo
    {
        /// <summary>
        /// 评价
        /// 1.好评,2.中评,3.差评
        /// </summary>
        public int OverallRating { set; get; }

        /// <summary>
        /// 点评内容
        /// </summary>
        public string Content { set; get; }

        /// <summary>
        /// 点评时间
        /// </summary>
        public DateTime CreateDate { set; get; }
    }
}
