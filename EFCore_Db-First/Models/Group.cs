using System;
using System.Collections.Generic;

namespace EFCore_Db_First.Models;

public partial class Group
{
    public int GroupId { get; set; }

    public string GroupName { get; set; } = null!;

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
}
