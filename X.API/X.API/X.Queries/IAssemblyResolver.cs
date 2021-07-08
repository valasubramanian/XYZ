using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace X.Infrastructure
{
    public interface IAssemblyResolver
    {
        Assembly[] GetAssemblies();
    }
}
