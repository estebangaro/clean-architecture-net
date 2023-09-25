namespace Notifications.Models.EFCore;

public partial class Emisor
{
    public int Id { get; set; }

    public string Rfc { get; set; } = null!;

    public DateTime FechaOperacion { get; set; }

    public decimal Capital { get; set; }
}
