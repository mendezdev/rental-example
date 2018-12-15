using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Models.Requests;
using ViewModels;

namespace Domain.Implementation
{
    public class RentalDomain : IRentalDomain
    {
        public ContractResponse Rent(IList<RentalRequest> requests)
        {
            throw new NotImplementedException();
        }
    }
}
