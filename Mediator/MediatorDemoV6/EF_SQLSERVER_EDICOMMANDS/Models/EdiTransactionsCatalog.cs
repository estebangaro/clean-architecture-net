namespace EF_SQLSERVER_EDI_COMMANDS.Models;

public partial class EdiTransactionsCatalog
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;
}
