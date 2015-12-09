using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain;
using Travelling.TravelInterface.Data;

namespace Travelling.DataProvider
{
    /// <summary>
    /// 管理员日志管理
    /// </summary>
    public class AccountLogDataProvider:BaseRecord<T_AccountLog>,IAccountLogDataProvider
    {
        public AccountLogDataProvider()
        {
            this.defaultDatabase = TravelDatabase;
        }
    }
}
