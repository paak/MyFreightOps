namespace FreightOps.DbTableSchema
{
    public sealed class RolesTableSchema
    {
        /// <summary>
        /// TableName
        /// </summary>
        public const string TableName = "_Roles";

        // Columns
        public static class Columns
        {
            public const string RoleId = "RoleId";
            public const string Name = "Name";
            public const string Description = "Description";
        }

        // Primary, Foreign keys
        public static class Keys
        {
            public const string PK_Role = "PK_Roles";
        }

        // Default values
        public static class Constraints
        {
            public const string DF_Role_Name = "DF_Roles_" + Columns.Name;
        }

        // Indexes, Uniques
        public static class Indexes
        {
            public const string IX_Role = "IX_Roles";
        }
    }
}
