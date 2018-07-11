using System.Collections.Generic;
using FF.Contracts.Models;

namespace FF.Data.Models
{
    public partial class Fruit : UpdateableModel, IFruit
    {
        public Fruit()
        {
            this.FruitVarieties = new List<FruitVariety>();
            this.Reviews = new List<Review>();
        }

        public int FruitId { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string WikiLink { get; set; }
        public byte[] StockImage { get; set; }

        public virtual ICollection<FruitVariety> FruitVarieties { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
