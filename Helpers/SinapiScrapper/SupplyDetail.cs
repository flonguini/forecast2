using System;


namespace SinapiScrapper
{
    public class SupplyDetail
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public State State { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public bool IsRelieve { get; set; }
        public Supply Supply { get; set; }
        public Guid SupplyId { get; set; }

        public SupplyDetail()
        {
            Id = Guid.NewGuid();
        }
    }
}
