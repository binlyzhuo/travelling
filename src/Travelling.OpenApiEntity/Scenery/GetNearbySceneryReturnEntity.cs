using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.OpenApiEntity.Scenery.Module;
using Travelling.OpenApiEntity.TC;

namespace Travelling.OpenApiEntity.Scenery
{
    /// <summary>
    /// 获取周边景点GetNearbyScenery
    /// </summary>
    public class GetNearbySceneryReturnEntity : TongChengBaseReturnEntity
    {
        /// <summary>
        /// 周边热门景点列表
        /// </summary>
        public List<SceneryNearInfo> SceneryList { set; get; }
    }
}
