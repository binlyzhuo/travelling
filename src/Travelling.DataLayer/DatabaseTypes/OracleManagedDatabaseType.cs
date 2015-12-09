using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.DataLayer.DatabaseTypes
{
    public class OracleManagedDatabaseType : OracleDatabaseType
    {
        public override string GetProviderName()
        {
            return "Oracle.ManagedDataAccess.Client";
        }
    }
}
