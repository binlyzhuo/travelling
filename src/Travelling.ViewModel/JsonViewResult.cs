using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel
{
    /// <summary>
    /// Json对象
    /// </summary>
    public class JsonViewResult
    {
        /// <summary>
        /// 操作结果
        /// </summary>
        public bool Success { set; get; }

        /// <summary>
        /// 描述信息
        /// </summary>
        public string Message { set; get; }
    }

    public class JsonViewResult<T>
        where T:class
    {
        public bool Success { set; get; }
        public string Message { set; get; }
        public object Data { set; get; }
        public dynamic Data2 { set; get; }
        public T obj { set; get; }
    }
}
