using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain;
using Travelling.ViewModel.Dto.User;

namespace Travelling.TravelInterface.Data
{
    /// <summary>
    /// 用户信息数据接口
    /// </summary>
    public interface IAccountInfoDataProvider : IDataProvider<T_AccountInfo>
    {
        /// <summary>
        /// 根据密码和用户名获取用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        T_AccountInfo GetAccountInfo(string userName, string password);
    }
}
