using System;


namespace DomainModel
{
    public class ContactEmail : BaseEntity
    {
        public ContactEmail()
        {

        }
        public Guid Id { get; set; }
        public string Email { get; set; }

        //public Contact Contact { get; set; }

    }
}
