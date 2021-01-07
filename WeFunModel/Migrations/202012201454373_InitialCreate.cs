namespace WeFunModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Announcers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        UserName = c.String(maxLength: 50),
                        UserPwd = c.String(maxLength: 50),
                        NickName = c.String(maxLength: 200),
                        Sex = c.Int(),
                        Age = c.Int(),
                        CDCard = c.String(maxLength: 18),
                        Phone = c.String(maxLength: 11),
                        Address = c.String(maxLength: 200),
                        QQ = c.String(maxLength: 20),
                        WetChat = c.String(maxLength: 50),
                        Other = c.String(maxLength: 200),
                        BankName = c.String(maxLength: 200),
                        BanCard = c.String(maxLength: 50),
                        Vitae = c.String(),
                        Remake = c.String(),
                        State = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AnnouncerMedals",
                c => new
                    {
                        AMID = c.Int(nullable: false, identity: true),
                        ID = c.Int(nullable: false),
                        MedalID = c.Int(),
                        State = c.Int(),
                    })
                .PrimaryKey(t => t.AMID);
            
            CreateTable(
                "dbo.AnnouncerStudios",
                c => new
                    {
                        ASID = c.Int(nullable: false, identity: true),
                        ID = c.Int(nullable: false),
                        RoomID = c.Int(),
                        State = c.Int(),
                    })
                .PrimaryKey(t => t.ASID);
            
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        ARID = c.Int(nullable: false, identity: true),
                        ARName = c.String(nullable: false, maxLength: 50),
                        ARParent = c.Int(),
                        ARIndex = c.Int(),
                        ARState = c.Int(),
                        ARReamle = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.ARID);
            
            CreateTable(
                "dbo.BlackRooms",
                c => new
                    {
                        BRID = c.Int(nullable: false, identity: true),
                        ID = c.Int(nullable: false),
                        Remake = c.String(maxLength: 200),
                        BeginDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        State = c.Int(),
                    })
                .PrimaryKey(t => t.BRID);
            
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        ConID = c.Int(nullable: false, identity: true),
                        ID = c.Int(nullable: false),
                        JoinDate = c.DateTime(nullable: false),
                        LeaveDate = c.DateTime(nullable: false),
                        ConBeginDate = c.DateTime(nullable: false),
                        ConEndDate = c.DateTime(nullable: false),
                        ConRemake = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.ConID);
            
            CreateTable(
                "dbo.LivePeriods",
                c => new
                    {
                        LPID = c.Int(nullable: false, identity: true),
                        RoomID = c.Int(nullable: false),
                        TimeLong = c.Single(nullable: false),
                        TimeBegin = c.DateTime(nullable: false),
                        TimeEnd = c.DateTime(nullable: false),
                        Remake = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.LPID);
            
            CreateTable(
                "dbo.Medals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MedalName = c.String(nullable: false, maxLength: 50),
                        MedalLevel = c.Int(),
                        Remake = c.String(maxLength: 200),
                        State = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RolePopedoms",
                c => new
                    {
                        RPID = c.Int(nullable: false, identity: true),
                        RoleID = c.Int(nullable: false),
                        PopID = c.Int(),
                        PopType = c.Int(),
                    })
                .PrimaryKey(t => t.RPID)
                .ForeignKey("dbo.SysRoles", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.SysPopedoms",
                c => new
                    {
                        PopID = c.Int(nullable: false, identity: true),
                        PopName = c.String(nullable: false, maxLength: 100),
                        Parent = c.Int(),
                        PopIndex = c.Int(),
                        PopPath = c.String(maxLength: 1000),
                        PopArea = c.String(maxLength: 100),
                        PopControll = c.String(maxLength: 100),
                        PopState = c.Int(),
                        PopDesc = c.String(maxLength: 500),
                        RolePopedom_RPID = c.Int(),
                    })
                .PrimaryKey(t => t.PopID)
                .ForeignKey("dbo.RolePopedoms", t => t.RolePopedom_RPID)
                .Index(t => t.RolePopedom_RPID);
            
            CreateTable(
                "dbo.SysRoles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false, maxLength: 50),
                        RoleDesc = c.String(maxLength: 500),
                        RoleState = c.Int(),
                        UsersRole_ARID = c.Int(),
                    })
                .PrimaryKey(t => t.RoleID)
                .ForeignKey("dbo.UsersRoles", t => t.UsersRole_ARID)
                .Index(t => t.UsersRole_ARID);
            
            CreateTable(
                "dbo.UsersRoles",
                c => new
                    {
                        ARID = c.Int(nullable: false, identity: true),
                        ID = c.Int(nullable: false),
                        RoleID = c.Int(),
                    })
                .PrimaryKey(t => t.ARID)
                .ForeignKey("dbo.Users", t => t.ID, cascadeDelete: true)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50, unicode: false),
                        UserPwd = c.String(nullable: false, maxLength: 50, unicode: false),
                        NickName = c.String(nullable: false, maxLength: 50, unicode: false),
                        State = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Studios",
                c => new
                    {
                        RoomID = c.Int(nullable: false, identity: true),
                        RoomName = c.String(nullable: false, maxLength: 100),
                        Remake = c.String(maxLength: 200),
                        State = c.Int(),
                    })
                .PrimaryKey(t => t.RoomID);
            
            CreateTable(
                "dbo.Suggestions",
                c => new
                    {
                        SugID = c.Int(nullable: false, identity: true),
                        SugUser = c.String(nullable: false, maxLength: 20),
                        SugContent = c.String(maxLength: 500),
                        SugProcess = c.String(maxLength: 500),
                        SugState = c.Int(),
                    })
                .PrimaryKey(t => t.SugID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersRoles", "ID", "dbo.Users");
            DropForeignKey("dbo.SysRoles", "UsersRole_ARID", "dbo.UsersRoles");
            DropForeignKey("dbo.RolePopedoms", "RoleID", "dbo.SysRoles");
            DropForeignKey("dbo.SysPopedoms", "RolePopedom_RPID", "dbo.RolePopedoms");
            DropIndex("dbo.UsersRoles", new[] { "ID" });
            DropIndex("dbo.SysRoles", new[] { "UsersRole_ARID" });
            DropIndex("dbo.SysPopedoms", new[] { "RolePopedom_RPID" });
            DropIndex("dbo.RolePopedoms", new[] { "RoleID" });
            DropTable("dbo.Suggestions");
            DropTable("dbo.Studios");
            DropTable("dbo.Users");
            DropTable("dbo.UsersRoles");
            DropTable("dbo.SysRoles");
            DropTable("dbo.SysPopedoms");
            DropTable("dbo.RolePopedoms");
            DropTable("dbo.Medals");
            DropTable("dbo.LivePeriods");
            DropTable("dbo.Contracts");
            DropTable("dbo.BlackRooms");
            DropTable("dbo.Areas");
            DropTable("dbo.AnnouncerStudios");
            DropTable("dbo.AnnouncerMedals");
            DropTable("dbo.Announcers");
        }
    }
}
