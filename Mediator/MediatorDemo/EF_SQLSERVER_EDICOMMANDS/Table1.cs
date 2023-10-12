using System;
using System.Collections.Generic;

namespace EF_SQLSERVER_EDI_COMMANDS;

public partial class Table1
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public byte[] RowVersion { get; set; } = null!;
}
