namespace ControllersDemo
{
    using ControllersDemo.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class StudentModel : DbContext
    {
        // Your context has been configured to use a 'StudentModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ControllersDemo.StudentModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'StudentModel' 
        // connection string in the application configuration file.
        public StudentModel()
            : base("name=StudentModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public DbSet<Student> StudentsDb { get; set; }
        public DbSet<Department> DepartmentsDb { get; set; }
        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            Database.SetInitializer<StudentModel>(null);

            //modelBuilder.Entity<Student>()
            //    .HasRequired(x => x.StudentDepartment)
            //    .WithMany(s => s.DepartmentStudents);
            // .HasForeignKey<int>(s => s.StudentDepartment_Id);

            //modelBuilder.Entity<Department>()
            //   .HasMany(x => x.DepartmentStudents)
            //   .WithRequired(x => x.StudentDepartment);
        }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}