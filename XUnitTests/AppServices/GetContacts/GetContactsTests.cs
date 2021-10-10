using AppServiceInterfaces;
using Substitutes.DataProviders;
using WpfContactsModule;
using WpfContactsModule.AppServices;
using Xunit;

namespace XUnitTests.AppServices.GetContacts
{
    public partial class GetContactsTests : BaseServiceTests
    {
        [Theory]
        [Trait("ContactRepositoryAppService", "GetContacts")]
        [MemberData(nameof(GetContacts_0_Empty_Test_TestCaseParams))]
        public void GetContacts_0_Empty_Test(object data, object requiredCase, object expectedResult)
        {
            var dataProvider = new ContactDataProviderMock();
            IContactRepositoryAppService service = new ContactRepositoryAppService(dataProvider);
            var contacts =  service.GetContactsCollection(data.ToString());
            Assert.Equal(expectedResult, contacts.Count);
        }

     
    }
}
