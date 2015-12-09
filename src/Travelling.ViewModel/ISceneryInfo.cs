using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel
{
    public interface ISceneryInfo
    {
        int SceneryID { set; get; }
        string SceneryName { set; get; }

        string Address { set; get; }
    }
}
