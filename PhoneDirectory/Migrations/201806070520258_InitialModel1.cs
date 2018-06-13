namespace PhoneDirectory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PhoneNumbers", "Details", c => c.String(nullable: false, maxLength: 11));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PhoneNumbers", "Details", c => c.String());
        }
    }
}
