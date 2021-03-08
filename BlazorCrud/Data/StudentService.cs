using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCrud.Data
{
    public class StudentService
    {
       
        private DbContextOptions<BlazorDbContext> _dbContextOptions;
      
        public StudentService(DbContextOptions<BlazorDbContext> dbContextOptions)
        {
            _dbContextOptions = dbContextOptions;
        }

        /// <summary>
        /// returns a list of students
        /// </summary>
        /// <returns></returns>
        public async Task<List<Students>> GetAllStudentsAsync()
        {
            using (var db = new BlazorDbContext(_dbContextOptions))
            {
                return await db.Students.ToListAsync();
            }
        }

        /// <summary>
        /// returns a list of students
        /// </summary>
        /// <returns></returns>
        public List<Students> ReloadAllStudents()
        {
            using (var db = new BlazorDbContext(_dbContextOptions))
            {
                return  db.Students.ToList();
            }
        }

        /// <summary>
        /// Returns a student whose id matches the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Students GetStudent(int id)
        {
            using (var db = new BlazorDbContext(_dbContextOptions))
            {
                return db.Students.Where(a=>a.Id==id).FirstOrDefault();
            }
        }

        /// <summary>
        /// Updates a selected student
        /// </summary>
        /// <param name="student"></param>
        public void UpdateStudent(Students student)
        {
           
            using (var db = new BlazorDbContext(_dbContextOptions))
            {
                var dbStudent =  db.Students.Where(a => a.Id == student.Id).FirstOrDefault();
                dbStudent.FirstName = student.FirstName;
                dbStudent.LastName = student.LastName;
                dbStudent.Gender = student.Gender;
                dbStudent.DateOfBirth = student.DateOfBirth;
                db.SaveChanges();
            }
            
        }
        /// <summary>
        /// Deletes a student by Id
        /// </summary>
        /// <param name="id"></param>
        public void RemoveStudent(int id)
        {
            using (var db = new BlazorDbContext(_dbContextOptions))
            {
                var student= db.Students.Where(a => a.Id == id).FirstOrDefault();
                db.Remove(student);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Creates a new Student Entity
        /// </summary>
        /// <param name="student"></param>
        public void CreateStudent(Students student)
        {
            using (var db = new BlazorDbContext(_dbContextOptions))
            {
                db.Students.Add(student);
                db.SaveChanges();
            }
        }
    }
}
