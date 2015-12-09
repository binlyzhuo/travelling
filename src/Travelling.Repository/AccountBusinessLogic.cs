using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.TravelInterface.Data;
using Travelling.TravelInterface.Repository;
using Travelling.ViewModel.Dto.User;
using Ninject;
using Travelling.Domain;

namespace Travelling.Repository
{
    public class AccountBusinessLogic : BaseUserInfoLogic, IAccountBusinessLogic
    {
        private readonly IAccountInfoDataProvider accountInfoData;
        public AccountBusinessLogic()
        {
            accountInfoData = kernel.Get<IAccountInfoDataProvider>();
        }

        public AccountInfo GetAccountInfo(string name,string password)
        {
            var accountInfoDomain = accountInfoData.GetAccountInfo(name,password);
            var accountInfoDto = AutoMapper.Mapper.Map<T_AccountInfo, AccountInfo>(accountInfoDomain);
            return accountInfoDto;
        }

        public AccountInfo GetAccountInfo(int accountId)
        {
            var accountInfoDomain = accountInfoData.SingleOrDefault(accountId);
            var accountInfoDto = AutoMapper.Mapper.Map<T_AccountInfo, AccountInfo>(accountInfoDomain);
            return accountInfoDto;
        }

        public bool UpdateAccountPassword(AccountInfo accountDto)
        {
            var accountInfoDomain = accountInfoData.SingleOrDefault(accountDto.ID);
            accountInfoDomain.Password = accountDto.Password;
            accountInfoDomain.UpdateTime = DateTime.Now;
            return accountInfoData.Update(accountInfoDomain)>0;
        }
    }
}
