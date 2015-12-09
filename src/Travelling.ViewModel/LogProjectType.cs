using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel
{
    public enum LogProjectType
    {
        [Description("酒店")]
        Hotel = 0,

        [Description("景区门票")]
        Ticket = 1,

        [Description("系统操作")]
        System = 2
    }
}
