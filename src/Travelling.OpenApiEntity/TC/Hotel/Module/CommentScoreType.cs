using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.TC.Hotel.Module
{
    /// <summary>
    /// 游客点评类型
    /// </summary>
    public enum CommentScoreType
    {
        //点评 1.好评,2.中评,3.差评
        /// <summary>
        /// 好评
        /// </summary>
        [Description("好评")]
        Nice=1,

        /// <summary>
        /// 中评
        /// </summary>
        [Description("中评")]
        Good=2,

        /// <summary>
        /// 差评
        /// </summary>
        [Description("差评")]
        Bad=3
    }
}
