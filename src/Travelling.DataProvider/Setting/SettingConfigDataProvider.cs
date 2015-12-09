using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.Setting;
using Travelling.TravelInterface.Data.Setting;

namespace Travelling.DataProvider.Setting
{
    public class SettingConfigDataProvider : BaseRecord<T_SettingConfig>, ISettingConfigDataProvider
    {
        public SettingConfigDataProvider()
        {
            this.defaultDatabase = TravelDatabase;
        }
    }
}
