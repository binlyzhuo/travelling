using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.Scenery;

namespace Travelling.TravelInterface.Data.SceneryTicket
{
    /// <summary>
    /// 景区图片数据接口
    /// </summary>
    public interface ISceneryImgInfoDataProvider : IDataProvider<T_SceneryImgInfo>
    {
        /// <summary>
        /// 获取景区图片信息
        /// </summary>
        /// <param name="sceneryid"></param>
        /// <returns></returns>
        List<T_SceneryImgInfo> GetSceneryImgs(int sceneryid);
    }
}
