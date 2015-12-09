using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain;
using Travelling.TravelInterface.Data;
using Travelling.ViewModel.Dto.User;
using Travelling.DataLayer;

namespace Travelling.DataProvider
{
    /// <summary>
    /// 系统用户数据访问
    /// </summary>
    public class AccountInfoDataProvider : BaseRecord<T_AccountInfo>, IAccountInfoDataProvider
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public AccountInfoDataProvider()
        {
            this.defaultDatabase = TravelDatabase;
        }

        /// <summary>
        /// 根据密码和用户名获取用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public T_AccountInfo GetAccountInfo(string userName,string password)
        {
            Sql where = Sql.Builder.Where("Name = @0 and Password=@1 and state=1",userName,password);
            var accountInfo = defaultDatabase.SingleOrDefault<T_AccountInfo>(where);
            return accountInfo;
        }
    }
}
