using Models.Entities;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Requests
{
    public class RentalRequest
    {
        public Customer Customer { get; set; }
        public RentalType RentalType { get; set; }
        public int Quantity { get; set; }
    }
}
