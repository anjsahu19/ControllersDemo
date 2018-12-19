namespace ControllersDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStudentDepartment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "StudentDepartment_Id", c => c.Int());
            CreateIndex("dbo.Students", "StudentDepartment_Id");
            AddForeignKey("dbo.Students", "StudentDepartment_Id", "dbo.Departments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "StudentDepartment_Id", "dbo.Departments");
            DropIndex("dbo.Students", new[] { "StudentDepartment_Id" });
            DropColumn("dbo.Students", "StudentDepartment_Id");
        }
    }
}
