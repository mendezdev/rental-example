using Models.Enums;

namespace Models.Entities
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentificationNumber { get; set; }
        public IdentificationType IdentificationType { get; set; }
    }
}
