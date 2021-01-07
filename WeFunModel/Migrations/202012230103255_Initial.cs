namespace WeFunModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SysPopedoms", "RolePopedom_RPID", "dbo.RolePopedoms");
            DropIndex("dbo.SysPopedoms", new[] { "RolePopedom_RPID" });
            DropColumn("dbo.SysPopedoms", "RolePopedom_RPID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SysPopedoms", "RolePopedom_RPID", c => c.Int());
            CreateIndex("dbo.SysPopedoms", "RolePopedom_RPID");
            AddForeignKey("dbo.SysPopedoms", "RolePopedom_RPID", "dbo.RolePopedoms", "RPID");
        }
    }
}
