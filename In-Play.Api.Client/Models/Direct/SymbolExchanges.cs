using System;
using System.Collections.Generic;

namespace In_Play.Api.Client.Models.Direct
{
    public class SymbolExchanges
    {
        public Dictionary<string, ExchangeSettings> Exchanges { get; set; }
        public Dictionary<string, SymbolSettings> Symbols { get; set; }
    }


    public class ExchangeSettings
    {
        public string Name { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool CommonCurrency { get; set; }
        public bool Closed { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string FullName { get; set; }
        public string AwayName { get; set; }
        public string AwayAlias { get; set; }
        public string HomeName { get; set; }
        public string HomeAlias { get; set; }
        public StatusEvent StatusEvent { get; set; }
        public StatusExchange StatusExchange { get; set; }
        public TypeEvent TypeEvent { get; set; }
        public DateTime StartDateEvent { get; set; }
        public DateTime? EndDateEvent { get; set; }
        public decimal? HomeScore { get; set; }
        public decimal? AwayScore { get; set; }
        public Guid? HomeTeamId { get; set; }
        public Guid? AwayTeamId { get; set; }
        public decimal? HomePoints { get; set; }
        public decimal? AwayPoints { get; set; }
        public int? EventId { get; set; }
        public int Favorite { get; set; }
        public string Comment { get; set; }
        public Category Category { get; set; }
        public List<string> Symbols { get; set; }
    }

    public class SymbolSettings
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Exchange { get; set; }
        public string Currency_Id { get; set; }
        public StatusExchange Status { get; set; }
        public OptionExchange OptionExchange { get; set; }
        public decimal? ExpectedValue { get; set; }
        public decimal? ActualValue { get; set; }
        public decimal? Probability { get; set; }
        public decimal LastPrice { get; set; }
        public Side? Side { get; set; }
        public decimal LastAsk { get; set; }
        public decimal LastBid { get; set; }
        public int? PriceChangeDirection { get; set; }
        public int DelayTime { get; set; }
        public decimal? ExchangeLimit { get; set; }
        public Result? Result { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public DateTime? SettlementDate { get; set; }
    }
}