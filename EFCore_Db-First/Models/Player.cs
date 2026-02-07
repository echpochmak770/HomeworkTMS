using System;
using System.Collections.Generic;

namespace EFCore_Db_First.Models;

public partial class Player
{
    public int PlayerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int TeamId { get; set; }

    public int Age { get; set; }

    public double Salary { get; set; }

    public virtual Team Team { get; set; } = null!;
}
