using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain;
using Travelling.TravelInterface;


namespace Travelling.DataProvider
{
    public class UsersDataProvider : BaseRecord<T_Users>, IUserDataProvider
    {
        public UsersDataProvider()
        {
            this.defaultDatabase = TravelDatabase;
        }
    }
}
