using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract.Models;

namespace Contract.Facades
{
    public interface ICalculationFacade
    {
        Task<decimal> CalculateOOOAsync(decimal income1, decimal income2);
        Task<decimal> CalculateEPAsync(decimal income1, decimal income2);
        byte[] ExportToExcelFile();
        Task<decimal> CalculateMemoAsync(decimal income1, decimal income2);
    }
}
