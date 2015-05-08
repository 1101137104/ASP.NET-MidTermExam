using KuasCore.Models;
using System;
using System.Collections.Generic;

namespace KuasCore.Dao
{
    public interface ICourseDao
    {

        void AddCourse(Course course);


        Course GetCourseByCourseName(string CourseName);

    }
}
