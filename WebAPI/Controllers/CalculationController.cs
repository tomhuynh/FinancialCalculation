using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Business.Calculation;
using Contract.Facades;

namespace WebAPI.Controllers
{
    public class CalculationController : ApiController
    {
        private readonly ICalculationFacade _calculationFacade;

        public CalculationController()
        {
            _calculationFacade = new CalculationFacade();
        }

        [HttpGet, Route("calcOOs/{income1:decimal}/{income2:decimal}")]
        public async Task<decimal> CalculacOO(decimal income1, decimal income2)
        {
            try
            {
                return await _calculationFacade.CalculateOOOAsync(income1, income2);
            }
            catch (Exception e)
            {
                var err = e.Message;
            }

            return 0;
        }

        [HttpGet, Route("calcEps/{income1:decimal}/{income2:decimal}")]
        public async Task<decimal> CalculacEP(decimal income1, decimal income2)
        {
            try
            {
                return await _calculationFacade.CalculateEPAsync(income1, income2);
            }
            catch (Exception e)
            {
                var err = e.Message;
            }

            return 0;
        }

        [HttpGet, Route("calcMemo/{income1:decimal}/{income2:decimal}")]
        public async Task<decimal> calcMemo(decimal income1, decimal income2)
        {
            try
            {
                return await _calculationFacade.CalculateMemoAsync(income1, income2);
            }
            catch (Exception e)
            {
                var err = e.Message;
            }

            return 0;
        }

        

    }
}