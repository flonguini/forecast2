using System;
using System.Collections.Generic;


namespace SinapiScrapper
{
    public class Supply
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public ICollection<SupplyDetail> Detail { get; set; }

        public Supply()
        {
            Id = Guid.NewGuid();
        }
    }
}
