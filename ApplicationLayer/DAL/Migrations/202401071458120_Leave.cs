namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Leave : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LeaveRequests", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.LeaveSheets", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.LeaveRequests", "LeaveType_Id", "dbo.LeaveTypes");
            DropIndex("dbo.LeaveRequests", new[] { "Employee_Id" });
            DropIndex("dbo.LeaveRequests", new[] { "LeaveType_Id" });
            DropIndex("dbo.LeaveSheets", new[] { "Employee_Id" });
            RenameColumn(table: "dbo.LeaveRequests", name: "Employee_Id", newName: "EmployeeId");
            RenameColumn(table: "dbo.LeaveSheets", name: "Employee_Id", newName: "EmployeeId");
            RenameColumn(table: "dbo.LeaveRequests", name: "LeaveType_Id", newName: "LeaveTypeId");
            AddColumn("dbo.LeaveRequests", "LeaveStartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.LeaveRequests", "LeaveEndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.LeaveRequests", "TotalDays", c => c.Int(nullable: false));
            AddColumn("dbo.LeaveRequests", "Detail", c => c.String(nullable: false));
            AddColumn("dbo.LeaveRequests", "Status", c => c.String(nullable: false));
            AddColumn("dbo.LeaveSheets", "Month", c => c.DateTime(nullable: false));
            AddColumn("dbo.LeaveSheets", "Sick", c => c.Int(nullable: false));
            AddColumn("dbo.LeaveSheets", "Vacation", c => c.Int(nullable: false));
            AddColumn("dbo.LeaveSheets", "Personal", c => c.Int(nullable: false));
            AddColumn("dbo.LeaveSheets", "Marriage", c => c.Int(nullable: false));
            AddColumn("dbo.LeaveSheets", "TotalLeave", c => c.Int(nullable: false));
            AlterColumn("dbo.LeaveRequests", "EmployeeId", c => c.Int(nullable: false));
            AlterColumn("dbo.LeaveRequests", "LeaveTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.LeaveSheets", "EmployeeId", c => c.Int(nullable: false));
            CreateIndex("dbo.LeaveRequests", "EmployeeId");
            CreateIndex("dbo.LeaveRequests", "LeaveTypeId");
            CreateIndex("dbo.LeaveSheets", "EmployeeId");
            AddForeignKey("dbo.LeaveRequests", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LeaveSheets", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LeaveRequests", "LeaveTypeId", "dbo.LeaveTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LeaveRequests", "LeaveTypeId", "dbo.LeaveTypes");
            DropForeignKey("dbo.LeaveSheets", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.LeaveRequests", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.LeaveSheets", new[] { "EmployeeId" });
            DropIndex("dbo.LeaveRequests", new[] { "LeaveTypeId" });
            DropIndex("dbo.LeaveRequests", new[] { "EmployeeId" });
            AlterColumn("dbo.LeaveSheets", "EmployeeId", c => c.Int());
            AlterColumn("dbo.LeaveRequests", "LeaveTypeId", c => c.Int());
            AlterColumn("dbo.LeaveRequests", "EmployeeId", c => c.Int());
            DropColumn("dbo.LeaveSheets", "TotalLeave");
            DropColumn("dbo.LeaveSheets", "Marriage");
            DropColumn("dbo.LeaveSheets", "Personal");
            DropColumn("dbo.LeaveSheets", "Vacation");
            DropColumn("dbo.LeaveSheets", "Sick");
            DropColumn("dbo.LeaveSheets", "Month");
            DropColumn("dbo.LeaveRequests", "Status");
            DropColumn("dbo.LeaveRequests", "Detail");
            DropColumn("dbo.LeaveRequests", "TotalDays");
            DropColumn("dbo.LeaveRequests", "LeaveEndDate");
            DropColumn("dbo.LeaveRequests", "LeaveStartDate");
            RenameColumn(table: "dbo.LeaveRequests", name: "LeaveTypeId", newName: "LeaveType_Id");
            RenameColumn(table: "dbo.LeaveSheets", name: "EmployeeId", newName: "Employee_Id");
            RenameColumn(table: "dbo.LeaveRequests", name: "EmployeeId", newName: "Employee_Id");
            CreateIndex("dbo.LeaveSheets", "Employee_Id");
            CreateIndex("dbo.LeaveRequests", "LeaveType_Id");
            CreateIndex("dbo.LeaveRequests", "Employee_Id");
            AddForeignKey("dbo.LeaveRequests", "LeaveType_Id", "dbo.LeaveTypes", "Id");
            AddForeignKey("dbo.LeaveSheets", "Employee_Id", "dbo.Employees", "Id");
            AddForeignKey("dbo.LeaveRequests", "Employee_Id", "dbo.Employees", "Id");
        }
    }
}
