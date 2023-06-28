using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedTransactionsView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
CREATE OR REPLACE VIEW public.""ViewTransactions""
    AS
     SELECT ""Transactions"".""Id"",
    ""Transactions"".""CardId"",
    ""Transactions"".""Name"",
    ""Transactions"".""Description"",
    ""Transactions"".""Sum"",
    ""Transactions"".""PreviewBalance"",
    ""Transactions"".""TransactionStatusId"",
    ""Transactions"".""TransactionTypeId"",
    ""Transactions"".""CreatedAt"",
    ""Transactions"".""CreatedById"",
    ""AspNetUsers"".""FirstName"",
    ""AspNetUsers"".""LastName"" 
   FROM ""Transactions""
     JOIN ""AspNetUsers"" ON ""AspNetUsers"".""Id"" = ""Transactions"".""CreatedById"";
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW public.""ViewTransactions"";");
        }
    }
}
