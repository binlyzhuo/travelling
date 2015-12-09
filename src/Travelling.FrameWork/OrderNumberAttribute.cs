using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.FrameWork
{
    /// <summary>
    /// 设置排序序号
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class OrderNumberAttribute:Attribute
    {
        private int orderNum=0;
        public OrderNumberAttribute(int orderNumber)
        {
            if(orderNumber<0)
            {
                throw new Exception("ordernumber must more than zero!!");
            }
            this.orderNum = orderNumber;
        }

        public int OrderNumber
        {
            get
            {
                return this.orderNum;
            }

        }
    }
}
