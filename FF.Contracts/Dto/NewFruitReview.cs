using System;

namespace FF.Contracts.Dto
{
    public class NewFruitReview
    {
        public int UserId { get; set; }
        public int LocationId { get; set; }
        public int FruitId { get; set; }
        public DateTime AquiredWhen { get; set; }
        public string Comment { get; set; }
        public byte[] Image { get; set; }
    }
}
