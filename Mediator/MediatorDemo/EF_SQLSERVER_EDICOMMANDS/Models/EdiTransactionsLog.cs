namespace EF_SQLSERVER_EDI_COMMANDS.Models;

public partial class EdiTransactionsLog
{
    public int Id { get; set; }

    public string Message { get; set; } = null!;

    public string Type { get; set; } = null!;

    public DateTime CreateDate { get; set; }
}
