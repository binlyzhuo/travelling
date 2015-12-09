using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.DataLayer;
using Travelling.Domain.Setting;
using Travelling.ViewModel.Admin;

namespace Travelling.TravelInterface.Data.Setting
{
    public interface IFriendLinkDataProvider : IDataProvider<T_FriendLink>
    {
        Page<T_FriendLink> FriendLinkGetPageResult(FriendLinkSearchModel searchModel);
    }
}
