using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Travelling.TravelInterface.Repository;
using Travelling.ViewModel;
using Travelling.ViewModel.Dto.HotelSyncRecord;
using Travelling.ViewModel.Dto.User;

namespace DataSyncBox.Core
{
    public class BaseAdminForm : Form
    {
        protected static AccountInfo accountinfo;
        protected static string ClientIP;
        protected static ISystemLogBusinessLogic logBusiness;
        

        protected int SaveLog(LogProjectType project,string content)
        {
            OperatingLog log = new OperatingLog();
            log.AddDate = DateTime.Now;
            log.Content = content;
            log.Creator = accountinfo.Name;
            log.CreatorId = accountinfo.ID;
            log.EndDate = DateTime.Parse("1900-1-1");
            log.IP = ClientIP;
            log.ProjectType = (int)project;
            log.StartDate = DateTime.Now;
            int logid = logBusiness.AddSystemLog(log);
            return logid;
        }

        protected bool UpdateLogEndDate(int logid)
        {
            return logBusiness.UpdateLogEndDate(logid);
        }
    }
}
