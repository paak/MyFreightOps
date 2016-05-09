namespace FreightOps.DbTableSchema
{
    public sealed class CountriesTableSchema
    {
        /// <summary>
        /// TableName
        /// </summary>
        public const string TableName = "_Countries";

        // Columns
        public static class Columns
        {
            public const string Code = "Code";
            public const string Name = "Name";
        }

        // Primary, Foreign keys
        public static class Keys
        {
            public const string PK_Role = "PK_Countries";
        }

        // Default values
        public static class Constraints
        {
            public const string DF_Countries_Name = "DF_Countries_Name";
        }

        // Indexes, Uniques
        public static class Indexes
        {
            public const string IX_Countries_Code = "IX_Countries_Code";
            public const string IX_Countries_Name = "IX_Countries_Name";
        }
    }
}
