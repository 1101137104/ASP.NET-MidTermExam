using KuasCore.Dao;
using KuasCore.Models;
using KuasCore.Services;
using KuasCore.Services.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Testing.Microsoft;
using System;

namespace KuasCoreTests.Services
{
    [TestClass]
    public class CourseServiceUnitTest : AbstractDependencyInjectionSpringContextTests
    {


        #region Spring 單元測試必寫的內容

        override protected string[] ConfigLocations
        {
            get
            {
                return new String[] { 
                    //assembly://MyAssembly/MyNamespace/ApplicationContext.xml
                    "~/Config/KuasCoreDatabase.xml",
                    "~/Config/KuasCorePointcut.xml",
                    "~/Config/KuasCoreTests.xml" 
                };
            }
        }

        #endregion

        public ICourseService CourseService { get; set; }

        [TestMethod]
        public void TestCourseService_AddCourse()
        {
            Course course = new Course();
            course.CourseId= "UnitTests";
            course.CourseName = "單元測試";
            course.CourseDescription = "拜託測試成功";
            CourseService.AddCourse(course);

            Course dbCourse = CourseService.GetCourseByCourseName(course.CourseName);

            Assert.IsNotNull(dbCourse);
            Assert.AreEqual(course.CourseName, dbCourse.CourseName);

            Console.WriteLine("課程編號為 = " + dbCourse.CourseId);
            Console.WriteLine("課程名稱為 = " + dbCourse.CourseName);
            Console.WriteLine("課程描述為 = " + dbCourse.CourseDescription);


            //CourseService.DeleteEmployee(dbCourse);
            dbCourse = CourseService.GetCourseByCourseName(course.CourseName);
            Assert.IsNull(dbCourse);
        }

        //[TestMethod]
        //public void TestEmployeeService_UpdateEmployee()
        //{
        //    // 取得資料
        //    Employee empolyee = EmployeeService.GetEmployeeById("dennis_yen");
        //    Assert.IsNotNull(empolyee);

        //    // 更新資料
        //    empolyee.Name = "單元測試";
        //    EmployeeService.UpdateEmployee(empolyee);

        //    // 再次取得資料
        //    Employee dbEmpolyee = EmployeeService.GetEmployeeById(empolyee.Id);
        //    Assert.IsNotNull(dbEmpolyee);
        //    Assert.AreEqual(empolyee.Name, dbEmpolyee.Name);

        //    Console.WriteLine("員工編號為 = " + dbEmpolyee.Id);
        //    Console.WriteLine("員工姓名為 = " + dbEmpolyee.Name);
        //    Console.WriteLine("員工年齡為 = " + dbEmpolyee.Age);

        //    Console.WriteLine("================================");

        //    // 將資料改回來
        //    empolyee.Name = "嚴志和";
        //    EmployeeService.UpdateEmployee(empolyee);

        //    // 再次取得資料
        //    dbEmpolyee = EmployeeService.GetEmployeeById(empolyee.Id);
        //    Assert.IsNotNull(dbEmpolyee);
        //    Assert.AreEqual(empolyee.Name, dbEmpolyee.Name);

        //    Console.WriteLine("員工編號為 = " + dbEmpolyee.Id);
        //    Console.WriteLine("員工姓名為 = " + dbEmpolyee.Name);
        //    Console.WriteLine("員工年齡為 = " + dbEmpolyee.Age);
        //}


        //[TestMethod]
        //public void TestEmployeeService_DeleteEmployee()
        //{
        //    Employee newEmpolyee = new Employee();
        //    newEmpolyee.Id = "UnitTests";
        //    newEmpolyee.Name = "單元測試";
        //    newEmpolyee.Age = 15;
        //    EmployeeService.AddEmployee(newEmpolyee);

        //    Employee dbEmpolyee = EmployeeService.GetEmployeeById(newEmpolyee.Id);
        //    Assert.IsNotNull(dbEmpolyee);

        //    EmployeeService.DeleteEmployee(dbEmpolyee);
        //    dbEmpolyee = EmployeeService.GetEmployeeById(newEmpolyee.Id);
        //    Assert.IsNull(dbEmpolyee);
        //}

        //[TestMethod]
        //public void TestEmployeeService_GetEmployeeById()
        //{
        //    Employee empolyee = EmployeeService.GetEmployeeById("dennis_yen");
        //    Assert.IsNotNull(empolyee);

        //    Console.WriteLine("員工編號為 = " + empolyee.Id);
        //    Console.WriteLine("員工姓名為 = " + empolyee.Name);
        //    Console.WriteLine("員工年齡為 = " + empolyee.Age);
        //}
        [TestMethod]
        public void TestCourseService_GetCourseByCourseName()
        {
            Course course = CourseService.GetCourseByCourseName("apple");
            Assert.IsNotNull(course);

            Console.WriteLine("課程編號為 = " + course.CourseId);
            Console.WriteLine("課程名稱為 = " + course.CourseName);
            Console.WriteLine("課程描述為 = " + course.CourseDescription);
        }

    }
}
