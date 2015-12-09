using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.TravelInterface.Repository
{
    /// <summary>
    /// 酒店lucene相关接口
    /// </summary>
    public interface IHotelLuceneIndexBusinessLogic
    {
        /// <summary>
        /// 酒店Lucene创建
        /// </summary>
        /// <param name="action"></param>
        [Obsolete("废弃")]
        void IndexHotelDescriptionCreate(Action<string> action);

        /// <summary>
        /// 初始化
        /// </summary>
        [Obsolete("废弃")]
        void InitHotelInfoLuceneIndex();

        void InitHotelIndexState();

        void HotelInfoLuceneIndexAction(Action<string> action);
    }
}
