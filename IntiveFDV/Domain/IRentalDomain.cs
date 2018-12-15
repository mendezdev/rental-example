using System.Collections.Generic;
using ViewModels;
using Models.Requests;

namespace Domain
{
    public interface IRentalDomain
    {
        ContractResponse Rent(IList<RentalRequest> requests);
    }
}
