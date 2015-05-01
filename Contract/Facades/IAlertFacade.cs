using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract.Models;

namespace Contract.Facades
{
    public interface IAlertFacade
    {
        Task<List<Alert>> GetAlertsAsync();
        Task<List<User>> GetUsersAsync();
    }
}
