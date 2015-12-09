using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.DataLayer;

namespace Travelling.Domain
{
    /// <summary>
    /// 景区主题
    /// </summary>
    [Serializable]
    [PrimaryKey("ID",AutoIncrement=false)]
    public partial class T_SceneryTheme
    {
        public T_SceneryTheme()
        { }
        #region Model
        private int _id;
        private string _name;
        /// <summary>
        /// 主题ID
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 主题名称
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        #endregion Model

    }
}
