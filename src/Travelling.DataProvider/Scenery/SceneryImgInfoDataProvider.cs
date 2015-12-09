using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.Scenery;
using Travelling.DataLayer;
using Travelling.TravelInterface.Data.SceneryTicket;

namespace Travelling.DataProvider.Scenery
{
    /// <summary>
    /// 景区图片相关数据源
    /// </summary>
    public class SceneryImgInfoDataProvider : BaseRecord<T_SceneryImgInfo>, ISceneryImgInfoDataProvider
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SceneryImgInfoDataProvider()
        {
            this.defaultDatabase = sceneryDb;
        }

        /// <summary>
        /// 获取景区图片信息
        /// </summary>
        /// <param name="sceneryid"></param>
        /// <returns></returns>
        public List<T_SceneryImgInfo> GetSceneryImgs(int sceneryid)
        {
            Sql where = Sql.Builder.Where("SceneryID=@0", sceneryid);
            return defaultDatabase.Query<T_SceneryImgInfo>(where).ToList();
        }
    }
}
