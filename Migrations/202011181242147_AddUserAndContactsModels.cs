namespace PhonesBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserAndContactsModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        contactID = c.Int(nullable: false, identity: true),
                        contactName = c.String(),
                        phoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.contactID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        userID = c.Int(nullable: false, identity: true),
                        userName = c.String(),
                        isAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.userID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Contacts");
        }
    }
}
