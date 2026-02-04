using System;
using System.Collections.Generic;

namespace EFCore_Db_First.Models;

public partial class Coach
{
    public int CoachId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
}
