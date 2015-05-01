using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Business.Facade.Alert;
using Contract.Facades;
using Contract.Models;

namespace WebAPI.Controllers
{
    //[RoutePrefix("api")]
    public class HomeController : ApiController
    {
        private readonly IAlertFacade _alertFacade;

        public HomeController()
        {
            _alertFacade = new AlertFacade();
        }

        [HttpGet, Route("alerts")]
        public Task<List<Alert>> GetAlertsAsync()
        {
            try
            {
                return _alertFacade.GetAlertsAsync();
            }
            catch (Exception e)
            {
                var err = e.Message;
            }

            return null;
        }

    }
}
