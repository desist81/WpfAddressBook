using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmDataProviders
{
    public abstract class DataProvider : IDisposable
    {
        private bool _disposed;
        private readonly Realm _realmInstance;
        public DataProvider()
        {
            //var config = new RealmConfiguration("Default.realm");
            //Realm.DeleteRealm(config);
            _realmInstance = Realm.GetInstance();
        }

        ~DataProvider() => Dispose(false);

        public Realm RealmInstance => _realmInstance;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _realmInstance?.Dispose();
                }
                _disposed = true;
            }
        }
    }
}
