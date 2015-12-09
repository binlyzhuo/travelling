using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.Zhuna_Hotel;
using Travelling.ViewModel.Travel;

namespace Travelling.TravelInterface.Data.Zhuna
{
    public interface IZhuna_SchoolInfoDataProvider : IDataProvider<Zhuna_SchoolInfo>
    {
        Tuple<List<SchoolSummaryInfo>, List<SchoolCityInfo>> SchoolSummaryInfos();
    }
}
