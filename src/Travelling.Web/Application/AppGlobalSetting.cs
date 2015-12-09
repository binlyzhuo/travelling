using System.Web.Caching;
using Travelling.Repository;

namespace Travelling.Web.Application
{
    /// <summary>
    /// 系统设置
    /// </summary>
    public class AppGlobalSetting
    {
        public static AppGlobalSetting Instance
        {
            get
            {
                return new AppGlobalSetting();
            }
        }

        private void ObjectMapper()
        {
            DtoMapper.AutoMapper();
        }

        private void LoadSceneryInfosToCache()
        {
        }

        public void LoadSetting()
        {
            ObjectMapper();
            LoadSceneryInfosToCache();
        }

        private void SqlCacheDependencyInit()
        {
            //SqlCacheDependencyAdmin.EnableTableForNotifications("","");
        }
    }
}