using System;

namespace Travelling.DataLayer
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class VersionColumnAttribute : ColumnAttribute
    {
        public VersionColumnAttribute() {}
        public VersionColumnAttribute(string name) : base(name) { }
    }
}