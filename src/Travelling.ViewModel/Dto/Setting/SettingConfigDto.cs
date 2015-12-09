using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Dto.Setting
{
    public class SettingConfigDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int ID
        {
            set;
            get;
        }
        /// <summary>
        /// 设置代码
        /// </summary>
        public string SettingCode
        {
            get;
            set;
        }
        /// <summary>
        /// 设置值
        /// </summary>
        public string SettingValue
        {
            get;
            set;
        }
        /// <summary>
        /// 上次修改时间
        /// </summary>
        public DateTime LastUpdate
        {
            get;
            set;
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddDate
        {
            get;
            set;
        }
        /// <summary>
        /// 备注信息
        /// </summary>
        public string Remark
        {
            get;
            set;
        }
    }
}
