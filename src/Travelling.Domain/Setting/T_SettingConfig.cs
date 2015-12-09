using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.Domain.Setting
{
    /// <summary>
    /// 网站设置
    /// </summary>
    [Serializable]
    public partial class T_SettingConfig
    {
        public T_SettingConfig()
        { }
        #region Model
        private int _id;
        private string _settingcode = "";
        private string _settingvalue = "";
        private DateTime _lastupdate = Convert.ToDateTime("1900-1-1");
        private DateTime _adddate = DateTime.Now;
        private string _remark;
        /// <summary>
        /// 主键
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 设置代码
        /// </summary>
        public string SettingCode
        {
            set { _settingcode = value; }
            get { return _settingcode; }
        }
        /// <summary>
        /// 设置值
        /// </summary>
        public string SettingValue
        {
            set { _settingvalue = value; }
            get { return _settingvalue; }
        }
        /// <summary>
        /// 上次修改时间
        /// </summary>
        public DateTime LastUpdate
        {
            set { _lastupdate = value; }
            get { return _lastupdate; }
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
        /// 备注信息
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model

    }
}
