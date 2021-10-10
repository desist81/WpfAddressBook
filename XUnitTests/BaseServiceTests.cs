using Substitutes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTests
{
    public class BaseServiceTests
    {
        public BaseServiceTests()
        {
            TestSession _currentSession = null;

            if (TestSession.Current == null)
            {
                string sessionId = TestSession.StartSession(Guid.NewGuid().ToString());
                _currentSession = TestSession.Current;
            }

        }

        public TestSession Session => TestSession.Current;
    }
}
