using System;

namespace Travelling.DataLayer
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class ComputedColumnAttribute : ColumnAttribute
    {
        public ComputedColumnAttribute() { }
        public ComputedColumnAttribute(string name) : base(name) { }
    }
}