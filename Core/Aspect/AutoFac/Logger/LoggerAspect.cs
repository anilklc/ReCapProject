using Castle.Core.Logging;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspect.AutoFac.Logger
{
    public class LoggerAspect : MethodInterception
    {
        //private readonly ILogger logger;
        NLog.Logger logger = LogManager.GetCurrentClassLogger();
   
        protected override void OnAfter(IInvocation invocation)
        {
            //Debug.WriteLine($"Log : {DateTime.Now+"---->"+invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}");
            logger.Info($"Log : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}");
        }

    }
}
