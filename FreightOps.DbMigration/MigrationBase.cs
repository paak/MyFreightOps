using FluentMigrator;

using System.Globalization;
using System.Threading;

namespace FreightOps.DbMigration
{
    public class MigrationBase : Migration
    {
        protected const string SchemaName = "FreightOps";

        public static string ToTitleCase(string str = "")
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;

            return textInfo.ToTitleCase(str);
        }

        public override void Up()
        {
        }

        public override void Down()
        {
        }

        /// <summary>
        /// Drop Column with check exists column
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="columnName"></param>
        protected virtual void DropColumn(string tableName, string columnName)
        {
            if (Schema.Table(tableName).Column(columnName).Exists())
            {
                Delete.Column(columnName).FromTable(tableName);
            }
        }

        /// <summary>
        /// Exists Colum
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        protected virtual bool ExistsColum(string tableName, string columnName)
        {
            return Schema.Table(tableName).Column(columnName).Exists();
        }

        /// <summary>
        /// Reseed Identity column to maximum
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="columnName"></param>
        protected virtual void ReseedIdentity(string tableName, string columnName)
        {
            if (string.IsNullOrWhiteSpace(tableName))
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(columnName))
            {
                return;
            }

            string sql = "DECLARE @maxVal INT; " +
                "SELECT @maxVal = ISNULL(MAX({1}), 0) FROM {0}; " +
                "DBCC CHECKIDENT('{0}', RESEED, @maxVal); ";

            Execute.Sql(string.Format(sql, tableName, columnName));
        }
    }
}
