using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace In_Play.Api.Client.Models.MLB
{
    public class Exchange
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public string AwayName { get; set; }
        public string AwayAlias { get; set; }
        public string HomeName { get; set; }
        public string HomeAlias { get; set; }
        public string StatusEvent { get; set; }
        public DateTime StartDateEvent { get; set; }
        public DateTime? EndDateEvent { get; set; }
        public Category Category { get; set; }
        public String TypeEvent { get; set; }
        public decimal? HomePoints { get; set; }
        public decimal? AwayPoints { get; set; }
        public decimal? HomeScore { get; set; }
        public decimal? AwayScore { get; set; }
        public Guid? HomeTeam_Id { get; set; }
        public Guid? AwayTeam_Id { get; set; }
        public int? EventId { get; set; }
        public string Comment { get; set; }
        public string StatusExchange { get; set; }
        public ICollection<Symbol> Symbols { get; set; }
    }
}
