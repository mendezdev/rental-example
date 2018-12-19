using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Responses
{
    public class DetailResponse
    {
        public string RentalOption { get; set; }
        public int Quantity { get; set; }
        public Customer Customer { get; set; }
        public decimal RentalCost { get; set; }
        public bool HasFamilyPromotion { get; set; }
        public decimal Discount { get; set; }
        public DateTime RentalStart { get; set; }
        public DateTime RentalEnd { get; set; }
    }
}
