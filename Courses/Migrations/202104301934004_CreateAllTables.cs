namespace Courses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAllTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admissions",
                c => new
                    {
                        TermCode = c.String(nullable: false, maxLength: 9, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.TermCode);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Byte(nullable: false),
                        CourseName = c.String(),
                        Credits = c.Int(nullable: false),
                        DepartmentId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Majors",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        FirstName = c.String(maxLength: 60),
                        LastName = c.String(maxLength: 60),
                        AdmissionTermCode = c.String(maxLength: 9, fixedLength: true, unicode: false),
                        DateOfBirth = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        MajorId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admissions", t => t.AdmissionTermCode)
                .ForeignKey("dbo.Majors", t => t.MajorId, cascadeDelete: true)
                .Index(t => t.AdmissionTermCode)
                .Index(t => t.MajorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "MajorId", "dbo.Majors");
            DropForeignKey("dbo.Students", "AdmissionTermCode", "dbo.Admissions");
            DropForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Students", new[] { "MajorId" });
            DropIndex("dbo.Students", new[] { "AdmissionTermCode" });
            DropIndex("dbo.Courses", new[] { "DepartmentId" });
            DropTable("dbo.Students");
            DropTable("dbo.Majors");
            DropTable("dbo.Departments");
            DropTable("dbo.Courses");
            DropTable("dbo.Admissions");
        }
    }
}
