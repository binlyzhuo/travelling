using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.ViewModel.Dto.User;

namespace Travelling.TravelInterface.Repository
{
    public interface IAccountBusinessLogic
    {
        AccountInfo GetAccountInfo(string name, string password);

        AccountInfo GetAccountInfo(int accountId);

        bool UpdateAccountPassword(AccountInfo accountDto);
    }
}
