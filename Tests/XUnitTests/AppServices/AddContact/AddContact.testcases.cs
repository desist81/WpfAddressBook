using ClientModel;
using System;
using System.Collections.Generic;

namespace XUnitTests.AppServices.AddContact
{
    public partial class AddContactTests
    {
        public static IEnumerable<object[]> AddContact_0_Empty_Test_TestCaseParams =>
        new TestCase(
            new AddContactData("Contact full name"),
            null,
            new AddContactExpectedResult(1)
        ).Params;


    }
}
