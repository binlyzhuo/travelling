using System.Web.Mvc;
using Travelling.FrameWork;

namespace Travelling.Web.Helpers
{
    public class AceUIHelper
    {
        public static MvcHtmlString GetBoolZHState(int state)
        {
            string className = state == 0 ? "label arrowed" : "label label-warning arrowed arrowed-right";
            return new MvcHtmlString(string.Format("<span class=\"{0}\">{1}</span>", className, state.IntToZHState()));
        }
    }
}