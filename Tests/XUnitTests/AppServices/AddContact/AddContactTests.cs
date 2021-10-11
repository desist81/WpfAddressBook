using AppServiceInterfaces;
using ClientModel;
using Substitutes.DataProviders;
using WpfContactsModule;
using WpfContactsModule.AppServices;
using Xunit;

namespace XUnitTests.AppServices.AddContact
{
    public partial class AddContactTests : BaseServiceTests
    {
        [Theory]
        [Trait("ContactRepositoryAppService", "AddContact")]
        [MemberData(nameof(AddContact_0_Empty_Test_TestCaseParams))]
        public void AddContact_0_Empty_Test(AddContactData data, object requiredCase, AddContactExpectedResult expectedResult)
        {
            var contactDataProvider = new ContactDataProviderMock();
            var fieldsDataProvider = new ContactFieldDataProviderMock();
            IContactRepositoryAppService service = new ContactRepositoryAppService(contactDataProvider, fieldsDataProvider);
            service.SaveContact(data.ContactToAdd);
            var contacts = service.GetContactsCollection(string.Empty);
            Assert.Equal(expectedResult.ContactsCount, contacts.Count);
        }


    }
}
