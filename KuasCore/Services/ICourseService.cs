using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KuasCore.Dao;
using KuasCore.Models;
using System.Collections.Generic;

namespace KuasCore.Services
{
    public interface ICourseService
    {
        /// <summary>
        ///     新增課程資料.
        /// </summary>
        /// <param name="Course">
        ///     課程資料.
        /// </param>
        void AddCourse(Course course);


        /// <summary>
        ///     依據 課程名稱 取得課程資料.
        /// </summary>
        /// <param name="CourseName">
        ///     課程 CourseName.
        /// </param>
        /// <returns>
        ///     該課程資料.
        /// </returns>
        Course GetCourseByCourseName(string CourseName);



    }
}
