using System;
using System.Collections.Generic;

namespace EFCore_Db_First.Models;

public partial class Schedule
{
    public int ScheduleId { get; set; }

    public int GroupId { get; set; }

    public int TeamAid { get; set; }

    public int TeamBid { get; set; }

    public DateTime MatchTime { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual Team TeamA { get; set; } = null!;

    public virtual Team TeamB { get; set; } = null!;
}
