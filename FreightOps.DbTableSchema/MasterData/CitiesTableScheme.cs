namespace FreightOps.DbTableSchema
{
    public sealed class CitiesTableSchema
    {
        /// <summary>
        /// TableName
        /// </summary>
        public const string TableName = "_Cities";

        // Columns
        public static class Columns
        {
            public const string Code = "Code";
            public const string Name = "Name";
        }

        // Primary, Foreign keys
        public static class Keys
        {
            public const string PK_Role = "PK_Cities";
        }

        // Default values
        public static class Constraints
        {
            public const string DF_Countries_Name = "DF_Cities_Name";
        }

        // Indexes, Uniques
        public static class Indexes
        {
            public const string IX_Countries_Code = "IX_Cities_Code";
            public const string IX_Countries_Name = "IX_Cities_Name";
        }
    }
}
