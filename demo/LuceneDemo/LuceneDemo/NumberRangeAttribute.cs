using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LuceneDemo
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class NumberRangeAttribute : Attribute
    {
        private int min;
        private int max;

        public NumberRangeAttribute(int min, int max)
        {
            this.min = min;
            this.max = max;


            if (min > max)
            {
                throw new Exception("min is more than max");
            }
        }


        public int Min
        {
            get
            {
                return this.min;
            }
        }

        public int Max
        {
            get
            {
                return this.max;
            }
        }
    }
}
