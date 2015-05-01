using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contract.Facades;
using DataAccess.SPA;

namespace Business.Facade.Alert
{
    public class AlertFacade : IAlertFacade, IDisposable
    {
        private readonly ISPADataAccess _spaDataAccess;

        public AlertFacade()
        {
            _spaDataAccess = new SPADataAccess();
        }

        public Task<List<Contract.Models.Alert>> GetAlertsAsync()
        {
            return _spaDataAccess.GetAlertsAsync();
        }

        public Task<List<Contract.Models.User>> GetUsersAsync()
        {
            return _spaDataAccess.GetUsersAsync();
        }

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                var demoDataAccess = this._spaDataAccess as IDisposable;

                if (demoDataAccess != null)
                {
                    demoDataAccess.Dispose();
                }
            }
        }

        #endregion
    }
}
