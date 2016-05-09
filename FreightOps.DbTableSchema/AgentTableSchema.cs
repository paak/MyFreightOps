namespace FreightOps.DbTableSchema
{
    public sealed class AgentsTableSchema
    {
        /// <summary>
        /// TableName
        /// </summary>
        public const string TableName = "Agents";

        // Columns
        public static class Columns
        {
            public const string AgentId = "AgentId";
            public const string Name = "Name";
            public const string Addr1 = "Addr1";
            public const string Addr2 = "Addr2";
            public const string StateOrProvince = "StateOrProvince";
            public const string PostalCode = "PostalCode";
            public const string CityCode = "CityCode";
            public const string CountryCode = "CountryCode";
            public const string Website = "Website";
            public const string IsActivated = "IsActivated";

            public const string CreatedBy = "CreatedBy";
            public const string UpdatedBy = "UpdatedBy";
            public const string CreatedAt = "CreatedAt";
            public const string UpdatedAt = "UpdatedAt";
        }

        // Primary, Foreign keys
        public static class Keys
        {
            public const string PK_Agents = "PK_Agents";
            public const string FK_Agents_Country = "FK_Agents_Country";
            public const string FK_Agents_City = "FK_Agents_City";
        }

        // Default values
        public static class Constraints
        {
            private const string prefix = "DF_Agents_";

            public const string DF_Agents_CreatedAt = prefix + Columns.CreatedAt;
            public const string DF_Agents_UpdatedAt = prefix + Columns.UpdatedAt;
            public const string DF_Agents_IsActiavted = prefix + Columns.IsActivated;
        }

        // Indexes, Uniques
        public static class Indexes
        {
            private const string prefix = "IX_Agents_";

            public const string IX_Agents_Name = prefix + Columns.Name;
            public const string IX_Agents_CityCode = prefix + Columns.CityCode;
            public const string IX_Agents_CountryCode = prefix + Columns.CountryCode;
            public const string IX_Agents_IsActivated = prefix + Columns.IsActivated;
        }
    }
}
