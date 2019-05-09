using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace In_Play.Api.Client.Models.MLB
{
    public class Lineup
    {
        public LineupTeam HomeTeam;
        public LineupTeam AwayTeam;
        public List<Props> Props;
    }

    public class LineupTeam

    {
        public string Name;
        public string Alias;
        public decimal TotalPoints;
        public decimal TotalScore;
        public List<LineupTeamItem> Items;
    }

    public class LineupTeamItem
    {
        public int Id;
        public int EventId;
        public string Name;
        public string Status;
        public decimal EPPG;
        public decimal Score;
        public string Position;
        public string Alias;
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
