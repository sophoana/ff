using System.Collections.Generic;

namespace FF.Data.Models
{
    public partial class FruitVariety : UpdateableModel, IFruitVariety
    {
        public FruitVariety()
        {
            this.AkaFruitVarieties = new List<FruitVariety>();
        }

        public int FruitVarietyId { get; set; }
        public int FruitId { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string WikiLink { get; set; }
        public byte[] StockImage { get; set; }
        public int? AkaFruitVarietyId { get; set; }

        public virtual Fruit Fruit { get; set; }
        public virtual ICollection<FruitVariety> AkaFruitVarieties { get; set; }
        public virtual FruitVariety AkaFruitVariety { get; set; }
    }
}
