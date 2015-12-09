using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.Setting;
using Travelling.TravelInterface.Data.Setting;
using Travelling.DataLayer;
using Travelling.ViewModel.Admin;

namespace Travelling.DataProvider.Setting
{
    public class FriendLinkDataProvider : BaseRecord<T_FriendLink>, IFriendLinkDataProvider
    {
        public FriendLinkDataProvider()
        {
            this.defaultDatabase = TravelDatabase;
        }

        public Page<T_FriendLink> FriendLinkGetPageResult(FriendLinkSearchModel searchModel)
        {
            Sql where = Sql.Builder.Where("1=1");
            return defaultDatabase.Page<T_FriendLink>(searchModel.PageIndex,searchModel.PageSize,where);
        }
    }
}
