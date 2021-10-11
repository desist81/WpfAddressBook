using ClientModel;
using System;

namespace XUnitTests.AppServices.AddContact
{
    public partial class AddContactTests
    {
        public class AddContactData
        {
            public AddContactData(string fullName)
            {
                ContactToAdd = new ContactBindingEntity(new DomainModel.Contact()
                {
                    Id = Guid.NewGuid(),
                    FullName = fullName
                });
                ContactToAdd.DataState = ClientInfrastructure.DataState.Added;

            }
            public ContactBindingEntity ContactToAdd { get; set; }

        }

        public class AddContactExpectedResult
        {
            public AddContactExpectedResult(int count)
            {
                ContactsCount = count;
            }
            public int ContactsCount { get; set; }
        }

    }
}
