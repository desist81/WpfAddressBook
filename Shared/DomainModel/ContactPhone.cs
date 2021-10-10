using System;


namespace DomainModel
{
    public class ContactPhone : BaseEntity
    {
        public ContactPhone()
        {

        }
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }

       // public Contact Contact { get; set; }
    }
}
