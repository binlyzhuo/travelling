using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain;
using Travelling.TravelInterface.Data;
using Travelling.ViewModel.Travel;

namespace Travelling.DataProvider
{
    public class SceneryThemeDataProvider : BaseRecord<T_SceneryTheme>, ISceneryThemeDataProvider
    {
        public SceneryThemeDataProvider()
        {
            this.defaultDatabase = sceneryDb;
        }

    }
}
