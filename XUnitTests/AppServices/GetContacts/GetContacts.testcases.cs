using System;
using System.Collections.Generic;

namespace XUnitTests.AppServices.GetContacts
{ 
    public partial class GetContactsTests
    {
        public static IEnumerable<object[]> GetContacts_0_Empty_Test_TestCaseParams =>
        new TestCase(
            String.Empty,
            null,
            0
        ).Params;
               
    }
}
