namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'03b18bdd-870f-4789-9232-df3803d5d8cd', N'guest@vidly.com', 0, N'ALCzOz6M/nh091IGLNfzso4zE9infbe3EoNjy6ANkavDky6sc30ApVj4vIp1cIY2sg==', N'749e7e87-6958-4731-b9a3-f0faa03a0757', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2df6b18d-aba3-485c-b51a-dfab03654eae', N'admin@vidly.com', 0, N'AA0KovLRr8oxSCHMsVPgSdNwU0R/CbehEE+7gdEvsmLLj6mJEMUD5iczVt9M3FHHPw==', N'72cb834d-3e25-49fe-9d62-3b6ab6729cc9', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'26895d2c-5939-447a-9f32-4c1a17f73172', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2df6b18d-aba3-485c-b51a-dfab03654eae', N'26895d2c-5939-447a-9f32-4c1a17f73172')
");
        }

        public override void Down()
        {
        }
    }
}
