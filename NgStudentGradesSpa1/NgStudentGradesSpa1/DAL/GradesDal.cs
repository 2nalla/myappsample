using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using NgStudentGradesSpa1.Models;

namespace NgStudentGradesSpa1.DAL
{
    public class GradesDal:DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SGradesModel>().ToTable("tbStudentANGApp1");
        }
        public DbSet<SGradesModel> dbSGrades { get; set; }
    }
}