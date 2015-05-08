using KuasCore.Dao;
using KuasCore.Dao.Impl;
using KuasCore.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Testing.Microsoft;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace KuasCoreTests.Dao
{

    [TestClass]
    public class CourseDaoUnitTest : AbstractDependencyInjectionSpringContextTests
    {
        #region 單元測試 Spring 必寫的內容 
        
        override protected string[] ConfigLocations
        {
            get
            {
                return new String[] { 
                    // assembly://MyAssembly/MyNamespace/ApplicationContext.xml
                    "~/Config/KuasCoreDatabase.xml",
                    "~/Config/KuasCoreTests.xml" 
                };
            }
        }

        #endregion

        public ICourseDao CourseDao { get; set; }


        [TestMethod]
        public void TestCourseDao_AddCourse()
        {
            Course course = new Course();

            course.CourseId = "UnitTests";
            course.CourseName = "單元測試";
            course.CourseDescription = "拜託測試成功";
            CourseDao.AddCourse(course);

            Course dbCourse = CourseDao.GetCourseByCourseName(course.CourseName);
            Assert.IsNotNull(dbCourse);
            Assert.AreEqual(course.CourseName, dbCourse.CourseName);

            Console.WriteLine("課程編號為 = " + dbCourse.CourseId);
            Console.WriteLine("課程名稱為 = " + dbCourse.CourseName);
            Console.WriteLine("課程描述為 = " + dbCourse.CourseDescription);

            //CourseDao.DeleteCourse(dbCourse);
            dbCourse = CourseDao.GetCourseByCourseName(course.CourseName);
            Assert.IsNull(dbCourse);
        }

        //[TestMethod]
        //public void TestEmployeeDao_UpdateEmployee()
        //{
        //    // 取得資料
        //    Employee employee = EmployeeDao.GetEmployeeById("dennis_yen");
        //    Assert.IsNotNull(employee);
            
        //    // 更新資料
        //    employee.Name = "單元測試";
        //    EmployeeDao.UpdateEmployee(employee);

        //    // 再次取得資料
        //    Employee dbEmployee = EmployeeDao.GetEmployeeById(employee.Id);
        //    Assert.IsNotNull(dbEmployee);
        //    Assert.AreEqual(employee.Name, dbEmployee.Name);
            
        //    Console.WriteLine("員工編號為 = " + dbEmployee.Id);
        //    Console.WriteLine("員工姓名為 = " + dbEmployee.Name);
        //    Console.WriteLine("員工年齡為 = " + dbEmployee.Age);

        //    Console.WriteLine("================================");

        //    // 將資料改回來
        //    employee.Name = "嚴志和";
        //    EmployeeDao.UpdateEmployee(employee);

        //    // 再次取得資料
        //    dbEmployee = EmployeeDao.GetEmployeeById(employee.Id);
        //    Assert.IsNotNull(dbEmployee);
        //    Assert.AreEqual(employee.Name, dbEmployee.Name);

        //    Console.WriteLine("員工編號為 = " + dbEmployee.Id);
        //    Console.WriteLine("員工姓名為 = " + dbEmployee.Name);
        //    Console.WriteLine("員工年齡為 = " + dbEmployee.Age);
        //}


        //[TestMethod]
        //public void TestEmployeeDao_DeleteEmployee()
        //{
        //    Employee newEmployee = new Employee();
        //    newEmployee.Id = "UnitTests";
        //    newEmployee.Name = "單元測試";
        //    newEmployee.Age = 15;
        //    EmployeeDao.AddEmployee(newEmployee);

        //    Employee dbEmployee = EmployeeDao.GetEmployeeById(newEmployee.Id);
        //    Assert.IsNotNull(dbEmployee);

        //    EmployeeDao.DeleteEmployee(dbEmployee);
        //    dbEmployee = EmployeeDao.GetEmployeeById(newEmployee.Id);
        //    Assert.IsNull(dbEmployee);
        //}

        //[TestMethod]
        //public void TestEmployeeDao_GetEmployeeById()
        //{
        //    Employee employee = EmployeeDao.GetEmployeeById("dennis_yen");
        //    Assert.IsNotNull(employee);
        //    Console.WriteLine("員工編號為 = " + employee.Id);
        //    Console.WriteLine("員工姓名為 = " + employee.Name);
        //    Console.WriteLine("員工年齡為 = " + employee.Age);
        //}

        [TestMethod]
        public void TestCourseDao_GetCourseByCourseName()
        {
            Course course =  CourseDao.GetCourseByCourseName("apple");
            Assert.IsNotNull(course);
            Console.WriteLine("課程編號為 = " + course.CourseId);
            Console.WriteLine("課程名稱為 = " + course.CourseName);
            Console.WriteLine("課程描述為 = " + course.CourseDescription);
        }

    }
}
