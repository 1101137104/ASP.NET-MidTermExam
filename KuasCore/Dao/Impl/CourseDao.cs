
using KuasCore.Dao.Base;
using KuasCore.Dao.Mapper;
using KuasCore.Models;
using Spring.Data.Common;
using Spring.Data.Generic;
using System.Collections.Generic;
using System.Data;

namespace KuasCore.Dao.Impl
{
    public class CourseDao : GenericDao<Course>, ICourseDao
    {

        override protected IRowMapper<Course> GetRowMapper()
        {
            return new CourseRowMapper();
        }

        public void AddCourse(Course course)
        {
            string command = @"INSERT INTO Course_Table (CourseID, CourseName, CourseDescription (@CourseID, @CourseName, @CourseDescription);";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("CourseID", DbType.String).Value = course.CourseId;
            parameters.Add("CourseName", DbType.String).Value = course.CourseName;
            parameters.Add("CourseDescription", DbType.String).Value = course.CourseDescription;

            ExecuteNonQuery(command, parameters);
        }


        public Course GetCourseByCourseName(string CourseName)
        {
            string command = @"SELECT * FROM Course_Table WHERE CourseName = @CourseName";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("CourseName", DbType.String).Value = CourseName;

            IList<Course> course = ExecuteQueryWithRowMapper(command, parameters);
            if (course.Count > 0)
            {
                return course[0];
            }

            return null;
        }

    }
}
