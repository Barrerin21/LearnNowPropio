using LearnNow.Class.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnNow.Class
{
    public class CourseRepository : ICourseRepository
    {
        private readonly LearnNowDB db;

        public CourseRepository(LearnNowDB db)
        {
            this.db = db;
        }

        public async Task<int> Create(CourseModel course)
        {
           if(course == null) throw new ArgumentNullException("Se requiere un curso.");
            await db.Courses.AddAsync(course);
            await db.SaveChangesAsync();
            return course.Id;
        }

        public void Delete(int id)
        {
            var c= new CourseModel { Id = id };
            db.Courses.Attach(c);
            db.Remove(c);
            db.SaveChanges();
        }

        public async Task<List<CourseModel>> GetAll()
        {
            return await db.Courses.ToListAsync();
        }

        public async Task<CourseModel> GetById(int id)
        {
            var courses = await db.Courses.FirstOrDefaultAsync(C=> C.Id == id);
            return courses!;
        }

        public void Update(CourseModel course)
        {
            var c = db.Courses.FirstOrDefault(c=> c.Id == course.Id);
            if(c == null)
            {
                throw new ArgumentException("El curso no existe.");
            }
            c.Title= course.Title; 
            c.Description= course.Description;
            c.Duration= course.Duration;
            c.Description=course.Description;
            db.SaveChanges();
        }
    }
}
