using System.Collections.Generic;

namespace In_Play.Api.Client.Models.MLB
{
    public class Lineup
    {
        public LineupTeam AwayTeam;
        public LineupTeam HomeTeam;
        public List<Props> Props;
    }

    public class LineupTeam

    {
        public string Alias;
        public List<LineupTeamItem> Items;
        public string Name;
        public decimal TotalPoints;
        public decimal TotalScore;
    }

    public class LineupTeamItem
    {
        public string Alias;
        public decimal EPPG;
        public int EventId;
        public int Id;
        public string Name;
        public string Position;
        public decimal Score;
        public string Status;
        public int TeamId;
    }

    public class Props
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public List<string> PropertyName { get; set; }
        public int Index { get; set; }
        public int TeamSize { get; set; }
    }
}