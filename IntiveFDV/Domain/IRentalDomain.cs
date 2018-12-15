using System.Collections.Generic;
using ViewModels;
using Models.Requests;
using Models.Enums;

namespace Domain
{
    public interface IRentalDomain
    {
        ContractResponse Rent(IList<RentalRequest> requests);
    }
}
