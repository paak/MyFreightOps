using FluentMigrator;
using FreightOps.DbTableSchema;

namespace FreightOps.DbMigration
{
    [Migration(1)]
    public class M001_Create_Table_Countries : MigrationBase
    {
        public override void Up()
        {
            #region _Role
            // Table schema
            Create.Table(RolesTableSchema.TableName)
                .WithColumn(RolesTableSchema.Columns.RoleId)
                    .AsByte()
                    .Identity()
                    .PrimaryKey(RolesTableSchema.Keys.PK_Role)
                .WithColumn(RolesTableSchema.Columns.Name)
                    .AsAnsiString(16)
                    .NotNullable()
                .WithColumn(RolesTableSchema.Columns.Description)
                    .AsAnsiString(32)
                    .NotNullable();

            // Indexes
            Create.Index(RolesTableSchema.Indexes.IX_Role)
                    .OnTable(RolesTableSchema.TableName)
                        .OnColumn(RolesTableSchema.Columns.Name)
                        .Ascending();

            // Default data
            Insert.IntoTable(RolesTableSchema.TableName)
                .Row(new { Name = "root", Description = "Root" })
                .Row(new { Name = "superuser", Description = "Super user" });
            #endregion

            #region Users
            // Table schema
            Create.Table("Users")
                .WithColumn("UserId").AsInt32().Identity().PrimaryKey("PK_Users")
                .WithColumn("AgentId").AsInt32().ForeignKey("FK_Users_AgentId", "Agents", "AgentId")
                .WithColumn("FirstName").AsString(35).NotNullable()
                .WithColumn("LastName").AsString(35).NotNullable()
                .WithColumn("Email").AsString(128).NotNullable()
                .WithColumn("CreatedAt").AsDateTime().WithDefaultValue(SystemMethods.CurrentUTCDateTime)
                .WithColumn("UpdatedAt").AsDateTime().WithDefaultValue(SystemMethods.CurrentUTCDateTime);
            #endregion

            Create.Table("Users_Memberships")
                .WithColumn("UserId").AsInt32().ForeignKey("FK_Users_Memberships", "Users", "UserId")
                .WithColumn("Username").AsString(128).NotNullable()
                .WithColumn("Password").AsString(128).NotNullable()
                .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("CreatedAt").AsDateTime().WithDefaultValue(SystemMethods.CurrentUTCDateTime)
                .WithColumn("UpdatedAt").AsDateTime().WithDefaultValue(SystemMethods.CurrentUTCDateTime);

            Create.Table("Users_Roles")
                .WithColumn("UserId").AsInt32().ForeignKey("FK_Users_Roles_UserId", "Users", "UserId").NotNullable()
                .WithColumn("RoleId").AsByte().ForeignKey("FK_Users_Roles_RoleId", "_Roles", "RoleId").NotNullable();

            Insert.IntoTable("Users")
                .Row(new { AgentId = 1, FirstName = "Root", LastName = "FreightOps", Email = "root@freightops.com" });
            Insert.IntoTable("Users_Memberships")
                .Row(new { UserId = 1, Username = "root@freightops.com", Password = "root@freightops.com" });
            Insert.IntoTable("Users_Roles")
                .Row(new { UserId = 1, RoleId = 1 });

            Execute.EmbeddedScript("");
        }

        public override void Down()
        {
            Delete.Table("Users_Roles");
            Delete.Table("Users_Memberships");
            Delete.Table("Users");
            Delete.Table(AgentsTableSchema.TableName);

            // Master
            Delete.Table(RolesTableSchema.TableName);
        }
    }
}
