using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.Zhuna_Hotel;

namespace Travelling.TravelInterface.Data.Zhuna
{
    public interface IZhuna_CityLableDataProvider : IDataProvider<Zhuna_CityLable>
    {
        List<Zhuna_CityLable> GetLablesToIndex();

        void UpdateIndexState(List<int> idList);

        void InitIndexState();

        int GetIndexStateCount(int indexstate);
    }
}
