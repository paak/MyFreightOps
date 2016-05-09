using FluentMigrator;
using FreightOps.DbTableSchema;

namespace FreightOps.DbMigration
{
    [Migration(2)]
    public class M001_Create_Table_Agents : MigrationBase
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

            #region Agent
            // Table schema
            Create.Table(AgentsTableSchema.TableName)
                .WithColumn(AgentsTableSchema.Columns.AgentId).AsInt32()
                    .Identity()
                    .PrimaryKey(AgentsTableSchema.Keys.PK_Agents)
                .WithColumn(AgentsTableSchema.Columns.Name).AsString(70)
                    .NotNullable()
                .WithColumn(AgentsTableSchema.Columns.Addr1).AsString(100)
                    .NotNullable()
                .WithColumn(AgentsTableSchema.Columns.Addr2).AsString(100)
                    .Nullable()
                .WithColumn(AgentsTableSchema.Columns.StateOrProvince).AsString(100)
                    .Nullable()
                .WithColumn(AgentsTableSchema.Columns.CityCode).AsString(5)
                    .NotNullable()
                .WithColumn(AgentsTableSchema.Columns.CountryCode).AsString(2)
                    .NotNullable()
                    .ForeignKey(AgentsTableSchema.Keys.FK_Agents_Country,
                        CountriesTableSchema.TableName, CountriesTableSchema.Columns.Code)
                .WithColumn(AgentsTableSchema.Columns.CreatedAt).AsDateTime()
                    .WithDefaultValue(SystemMethods.CurrentUTCDateTime)
                .WithColumn(AgentsTableSchema.Columns.UpdatedAt).AsDateTime()
                    .WithDefaultValue(SystemMethods.CurrentUTCDateTime)
                .WithColumn(AgentsTableSchema.Columns.IsActivated).AsBoolean();

            // Indexes
            Create.Index(AgentsTableSchema.Indexes.IX_Agents_Name)
                .OnTable(AgentsTableSchema.TableName)
                    .OnColumn(AgentsTableSchema.Columns.Name)
                    .Ascending();
            Create.Index(AgentsTableSchema.Indexes.IX_Agents_CityCode)
                .OnTable(AgentsTableSchema.TableName)
                    .OnColumn(AgentsTableSchema.Columns.CityCode)
                    .Ascending();
            Create.Index(AgentsTableSchema.Indexes.IX_Agents_CountryCode)
                .OnTable(AgentsTableSchema.TableName)
                    .OnColumn(AgentsTableSchema.Columns.CountryCode)
                    .Ascending();
            Create.Index(AgentsTableSchema.Indexes.IX_Agents_IsActivated)
                .OnTable(AgentsTableSchema.TableName)
                    .OnColumn(AgentsTableSchema.Columns.IsActivated)
                    .Ascending();

            // Deafult data
            Insert.IntoTable(AgentsTableSchema.TableName)
                .Row(new { Name = "Freight Ops" });
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
