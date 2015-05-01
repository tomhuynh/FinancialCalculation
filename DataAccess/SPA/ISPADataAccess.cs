using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contract.Models;

namespace DataAccess.SPA
{
    public interface ISPADataAccess : IDisposable
    {
        SPADataContext DataContext { get; set; }
        Task<List<Alert>> GetAlertsAsync();
        Task<List<User>> GetUsersAsync();
    }
}
