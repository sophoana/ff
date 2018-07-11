namespace FF.Data.Models
{
    public interface IFruitVariety
    {

        int FruitVarietyId { get; set; }
        int FruitId { get; set; }
        string Name { get; set; }
        string Summary { get; set; }
        string Description { get; set; }
        string WikiLink { get; set; }
        byte[] StockImage { get; set; }
        int? AkaFruitVarietyId { get; set; }

    }
}
