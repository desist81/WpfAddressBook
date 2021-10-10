using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substitutes.DataProviders
{
    public abstract class DataProvider : IDisposable
    {
        private bool _disposed;
        public DataProvider()
        {
         }

        ~DataProvider() => Dispose(false);

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
                }
                _disposed = true;
            }
        }
    }
}
