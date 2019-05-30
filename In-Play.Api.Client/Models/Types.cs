namespace In_Play.Api.Client.Models
{
    //status exchange
    public enum StatusExchange : byte
    {
        New = 0,
        Approved = 1,
        Ended = 2,
        Settlement = 3,
        Suspended = 4
    }

    //options for exchanges(Spread, MoneyLine, TotalPoints)
    public enum OptionExchange : byte
    {
        HC,
        ML,
        TP
    }

    //status event
    public enum StatusEvent : byte
    {
        Scheduled = 0,
        Live = 1,
        Closed = 2,
        Cancelled = 3,
        Final = 4,
        Postponed = 5
    }

    //order status
    public enum Status
    {
        Opened,
        Activated,
        PartialFilled,
        Filled,
        Done,
        Rejected,
        Cancelled,
        Expiried,
        OpenedPosition,
        PartialFilledPosition,
        FilledPosition,
        VirtualPosition,
        VirtualOrder
    }


    //order side
    public enum Side : byte
    {
        Buy = 0,
        Sell = 1
    }


    //type of exchange
    public enum TypeEvent : byte
    {
        Sport = 1,
        Props = 2,
        MultipleFantasy = 3,
        SingleFantasy = 4,
        Combo = 5,
        MultipleCombo = 6,
        PointsCombo = 7
    }

    public enum Result : byte
    {
        Undefined,
        Win,
        Loss,
        Tie,
        Emergency
    }
}