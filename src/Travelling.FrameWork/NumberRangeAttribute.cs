using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.FrameWork
{
    /// <summary>
    /// 设置数值区间
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false,Inherited=false)]
    public class NumberRangeAttribute : Attribute
    {
        private int min;
        private int max;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public NumberRangeAttribute(int min, int max)
        {
            this.min = min;
            this.max = max;


            if (min > max)
            {
                throw new Exception("min is more than max");
            }
        }

        /// <summary>
        /// 最小值
        /// </summary>
        public int Min
        {
            get
            {
                return this.min;
            }
        }

        /// <summary>
        /// 最大值
        /// </summary>
        public int Max
        {
            get
            {
                return this.max;
            }
        }
    }
}
