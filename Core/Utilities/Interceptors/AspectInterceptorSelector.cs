﻿using Castle.DynamicProxy;
using Core.Aspects.AutoFac.Performance;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public Castle.DynamicProxy.IInterceptor[] SelectInterceptors(Type type, MethodInfo method, Castle.DynamicProxy.IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            // classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));  logger eklemek istersek
            classAttributes.Add(new PerformanceAspect(0));


            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }

}
