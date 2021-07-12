namespace BigSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppliedChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Followings", "FolloweeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followings", "FollowerId", "dbo.AspNetUsers");
            RenameColumn(table: "dbo.Followings", name: "FolloweeId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.Followings", name: "FollowerId", newName: "FolloweeId");
            RenameColumn(table: "dbo.Followings", name: "__mig_tmp__0", newName: "FollowerId");
            RenameIndex(table: "dbo.Followings", name: "IX_FolloweeId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.Followings", name: "IX_FollowerId", newName: "IX_FolloweeId");
            RenameIndex(table: "dbo.Followings", name: "__mig_tmp__0", newName: "IX_FollowerId");
            AddForeignKey("dbo.Followings", "FollowerId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Followings", "FolloweeId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Followings", "FolloweeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followings", "FollowerId", "dbo.AspNetUsers");
            RenameIndex(table: "dbo.Followings", name: "IX_FollowerId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.Followings", name: "IX_FolloweeId", newName: "IX_FollowerId");
            RenameIndex(table: "dbo.Followings", name: "__mig_tmp__0", newName: "IX_FolloweeId");
            RenameColumn(table: "dbo.Followings", name: "FollowerId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.Followings", name: "FolloweeId", newName: "FollowerId");
            RenameColumn(table: "dbo.Followings", name: "__mig_tmp__0", newName: "FolloweeId");
            AddForeignKey("dbo.Followings", "FolloweeId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Followings", "FollowerId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
