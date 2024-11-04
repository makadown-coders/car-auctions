using System;

namespace AuctionService.Entities;

public class Auction
{
    public Guid Id { get; set; }
    public int ReservePrice { get; set; } = 0;

    /// <summary>
    /// username from claim
    /// </summary>
    public string Seller { get; set; } = string.Empty;
    /// <summary>
    /// username of winner
    /// </summary>
    public string Winner { get; set; }

    public int? SoldAmount { get; set; }
    public int? CurrentHighBid { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public Status Status { get; set; } = Status.Live;
    public DateTime AuctionEnd { get; set; }
    public Item Item { get; set; } 
}
