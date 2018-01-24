using NHibernate;
using System;

namespace Service.Controllers
{
    public class DAL : IDisposable
    {
        private ISession _session;

        public DAL()
        {
            _session = NhibernateSession.OpenSession();
        }

        public ISession GetSession()
        {
            return _session;
        }

        public void ClosSession()
        {
            _session.Close();

        }

        public void Dispose()
        {
            if (_session.IsConnected)
                this.ClosSession();
        }
    }
}
