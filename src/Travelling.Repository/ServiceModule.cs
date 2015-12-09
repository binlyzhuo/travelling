using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Data;
using Travelling.Interface;

namespace Travelling.Repository
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IDataProvider<>)).To(typeof(UsersDataProvider));
        }
    }
}
