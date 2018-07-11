namespace FF.Contracts.Models
{
    public interface IFruit
    {
        int FruitId { get; set; }
        string Name { get; set; }
        string Summary { get; set; }
        string Description { get; set; }
        string WikiLink { get; set; }
        byte[] StockImage { get; set; }
    }
}
