using AopAlliance.Intercept;
using KuasCore.Models;
using System;
using System.Diagnostics;

namespace KuasCore.Interceptors 
{
    class CourseInterceptor : IMethodInterceptor
    {

        public object Invoke(IMethodInvocation invocation)
        {

            Console.WriteLine("CourseInterceptor 攔截到一個方法呼叫 = [{0}]", invocation);
            Debug.Print("CourseInterceptor 攔截到一個方法呼叫 = [{0}]", invocation);

            object result = invocation.Proceed();

            if (result is Course)
            {
                Course course = (Course)result;
                
                course.CourseName = course.CourseName + " 一直跑不出來";
                result = course;
            }

            return result;
        }
    }
}
