using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.Domain.Zhuna_Hotel
{
    /// <summary>
    /// 国内学校信息
    /// </summary>
    [Serializable]
    public partial class Zhuna_SchoolInfo
    {
        public Zhuna_SchoolInfo()
        { }
        #region Model
        private int _id;
        private string _name = "";
        private string _ecityid = "";
        private int _classid = 0;
        private DateTime _adddate = DateTime.Now;
        private int _schoolid = 0;
        /// <summary>
        /// 主键
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 学校名称
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 城市名称
        /// </summary>
        public string ecityid
        {
            set { _ecityid = value; }
            get { return _ecityid; }
        }
        /// <summary>
        /// 地标分类
        /// </summary>
        public int classid
        {
            set { _classid = value; }
            get { return _classid; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime adddate
        {
            set { _adddate = value; }
            get { return _adddate; }
        }
        /// <summary>
        /// 学校id
        /// </summary>
        public int schoolid
        {
            set { _schoolid = value; }
            get { return _schoolid; }
        }
        #endregion Model

    }
}
