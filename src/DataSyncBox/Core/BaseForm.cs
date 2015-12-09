using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataSyncBox.Core
{
    public class BaseForm:Form
    {
        public readonly StandardKernel kernel;
        public BaseForm()
        {
            kernel = new StandardKernel(new DependencyResolver());
        }
    }
}
