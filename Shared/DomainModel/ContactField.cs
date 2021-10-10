using System;


namespace DomainModel
{
    public class ContactField : BaseEntity
    {
        public ContactField()
        {

        }
        public Guid Id { get; set; }
      
        public string Content { get; set; }

        public FieldType FieldType { get; set; }
        public Contact Contact { get; set; }
    }
}
