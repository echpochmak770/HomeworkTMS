using System;
using System.Collections.Generic;

namespace EFCore_Db_First.Models;

public partial class Team
{
    public int TeamId { get; set; }

    public string TeamName { get; set; } = null!;

    public int CoachId { get; set; }

    public int GroupId { get; set; }

    public int? Rate { get; set; }

    public virtual Coach Coach { get; set; } = null!;

    public virtual Group Group { get; set; } = null!;

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();

    public virtual ICollection<Schedule> ScheduleTeamAs { get; set; } = new List<Schedule>();

    public virtual ICollection<Schedule> ScheduleTeamBs { get; set; } = new List<Schedule>();
}
