using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substitutes
{
    public class TestSession
    {
        private volatile static Dictionary<string, TestSession> sessions = new Dictionary<string, TestSession>();
        private static object _sessionLock = new object();
        private DatabaseStorage _databaseStorage;

        public static TestSession Current
        {
            get
            {
                TestSession currentSession = null;
                lock (_sessionLock)
                {
                    TestPrincipal currentPrincipal = System.Threading.Thread.CurrentPrincipal as TestPrincipal;
                    if (currentPrincipal != null)
                    {
                        currentSession = sessions[currentPrincipal.Identity.Name];
                        if (currentSession._databaseStorage == null)
                        {
                            currentSession._databaseStorage = new DatabaseStorage();
                        }
                    }
                }
                return currentSession;
            }
        }

        public static string StartSession(string sessionId)
        {
            lock (_sessionLock)
            {
                var tprincipal = new TestPrincipal(sessionId);
                sessions.Add(sessionId, new TestSession());
                System.Threading.Thread.CurrentPrincipal = tprincipal;
            }
            return sessionId;
        }


        public DatabaseStorage DatabaseStorage
        {
            get
            {
                return _databaseStorage;
            }
        }


    }
}
