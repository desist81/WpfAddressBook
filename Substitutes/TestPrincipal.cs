using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Substitutes
{
    public class TestPrincipal : IPrincipal
    {
        IIdentity _identity;
        public TestPrincipal(string sessionId)
        {
            _identity = new GenericIdentity(sessionId);
        }

        public IIdentity Identity => _identity;

        public bool IsInRole(string role)
        {
            return true;
        }
    }
}

