namespace FlexSoft.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(maxLength: 100));
            AddColumn("dbo.AspNetUsers", "RfidCardNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "RfidCardNumber");
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
