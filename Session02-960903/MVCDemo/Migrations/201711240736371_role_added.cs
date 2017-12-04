namespace MVCDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class role_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Role", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Role");
        }
    }
}
