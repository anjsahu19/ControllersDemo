namespace ControllersDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDepartmentStudents : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departments", "DepartmentStudents_Id", c => c.Int());
            CreateIndex("dbo.Departments", "DepartmentStudents_Id");
            AddForeignKey("dbo.Departments", "DepartmentStudents_Id", "dbo.Students", "RollNo");
        }
        
        public override void Down()
        {
            AddForeignKey("dbo.Departments", "DepartmentStudents_Id", "dbo.Students", "RollNo");
            DropIndex("dbo.Departments", new[] { "DepartmentStudents_Id" });
            DropColumn("dbo.Departments", "DepartmentStudents_Id");
        }
    }
}
