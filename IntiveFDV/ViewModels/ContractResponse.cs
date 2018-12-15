using System;
using System.Collections.Generic;

namespace ViewModels
{
    public class ContractResponse
    {
        public decimal Total { get; set; }
        public decimal Discount { get; set; }
        public bool HasFamilyDiscount { get; set; }
        public IList<DetailResponse> Details { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
