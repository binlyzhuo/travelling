using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.Domain.Setting
{
    /// <summary>
    /// 联盟信息
    /// </summary>
    [Serializable]
    public partial class T_UnionDetailInfo
    {
        public T_UnionDetailInfo()
        { }
        #region Model
        private int _id;
        private string _unionname;
        private string _hotel;
        /// <summary>
        /// 联盟ID
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 联盟名称
        /// </summary>
        public string UnionName
        {
            set { _unionname = value; }
            get { return _unionname; }
        }
        /// <summary>
        /// 酒店联系方式
        /// </summary>
        public string Hotel
        {
            set { _hotel = value; }
            get { return _hotel; }
        }
        #endregion Model

    }
}
