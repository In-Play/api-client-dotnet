using Microsoft.Build.Framework;

namespace In_Play.Api.Client.Models.Direct
{
    public class OrderRequest
    {
        [Required] public Side Side { get; set; }

        [Required] public decimal LimitPrice { get; set; }

        [Required] public int Quantity { get; set; }

        [Required] public string SymbolId { get; set; }
    }
}