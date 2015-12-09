using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.Domain.Scenery
{
    /// <summary>
    /// 景区相关图片信息
    /// </summary>
    [Serializable]
    public partial class T_SceneryImgInfo
    {
        public T_SceneryImgInfo()
        { }
        #region Model
        private int _id;
        private int _sceneryid = 0;
        private string _imgbaseurl = "";
        private string _imgurl;
        private string _sizeinfo = "";
        private DateTime _adddate = DateTime.Now;
        private int _isvalid = 1;
        /// <summary>
        /// 主键
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 景区ID
        /// </summary>
        public int SceneryID
        {
            set { _sceneryid = value; }
            get { return _sceneryid; }
        }
        /// <summary>
        /// 图片根路径
        /// </summary>
        public string ImgBaseUrl
        {
            set { _imgbaseurl = value; }
            get { return _imgbaseurl; }
        }
        /// <summary>
        /// 图片名称
        /// </summary>
        public string ImgUrl
        {
            set { _imgurl = value; }
            get { return _imgurl; }
        }
        /// <summary>
        /// 图片大小信息
        /// </summary>
        public string SizeInfo
        {
            set { _sizeinfo = value; }
            get { return _sizeinfo; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddDate
        {
            set { _adddate = value; }
            get { return _adddate; }
        }
        /// <summary>
        /// 有效状态
        /// </summary>
        public int IsValid
        {
            set { _isvalid = value; }
            get { return _isvalid; }
        }
        #endregion Model

    }
}
