using KuasCore.Models;
using KuasCore.Services;
using KuasCore.Services.Impl;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace KuasWebApp.Controllers
{
    public class CourseController : ApiController
    {


        public ICourseService CourseService { get; set; }


        [HttpPost]
        public Course AddECourse(Course course)
        {

            CheckCourseIsNotNullThrowException(course);

            try
            {
                CourseService.AddCourse(course);
                return CourseService.GetCourseByCourseName(course.CourseName);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        //[HttpPut]
        //public Employee UpdateEmployee(Employee employee)
        //{
        //    CheckEmployeeIsNullThrowException(employee);

        //    try
        //    {
        //        EmployeeService.UpdateEmployee(employee);
        //        return EmployeeService.GetEmployeeById(employee.Id);
        //    }
        //    catch (Exception)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.InternalServerError);
        //    }
        //}

        //[HttpDelete]
        //public void DeleteEmployee(Employee employee)
        //{
        //    try
        //    {
        //        EmployeeService.DeleteEmployee(employee);
        //    }
        //    catch (Exception)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.InternalServerError);
        //    }
        //}

        //[HttpGet]
        //public IList<Employee> GetAllEmployees()
        //{
        //    return EmployeeService.GetAllEmployees();
        //}

        //[HttpGet]
        //[ActionName("byId")]
        //public Employee GetEmployeeById(string id)
        //{
        //    var employee = EmployeeService.GetEmployeeById(id);

        //    if (employee == null)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }

        //    return employee;
        //}

        /// <summary>
        ///     檢查員工資料是否存在，如果不存在則拋出錯誤.
        /// </summary>
        /// <param name="employee">
        ///     員工資料.
        /// </param>
        private void CheckCourseIsNullThrowException(Course course)

        {
            Course dbCourse = CourseService.GetCourseByCourseName(course.CourseId);


            if (dbCourse == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        /// <summary>
        ///     檢查課程資料是否存在，如果存在則拋出錯誤.
        /// </summary>
        /// <param name="course">
        ///     課程資料.
        /// </param>
        private void CheckCourseIsNotNullThrowException(Course course)
        {
            Course dbCourse = CourseService.GetCourseByCourseName(course.CourseId);

            if (dbCourse != null)
            {
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }
        }

    }

}
