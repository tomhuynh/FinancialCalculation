using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using ApiServer.App_Code;
using Contract.Facades;
using System.Web.Hosting;
using Contract.Models;
using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;

namespace Business.Calculation
{
    public class CalculationFacade : ICalculationFacade
    {
        private static Workbook s_workbook;
        private static Worksheet s_inputSheet;
        private static Worksheet s_outputSheet;
        const string Worksheet_Inputs = "Inputs";
        const string Worksheet_Outputs = "Outputs";

        public Worksheet FindByName(Sheets sheets, string name)
        {
            for (int sheetIndex = 1; sheetIndex <= sheets.Count; ++sheetIndex)
            {
                Worksheet curSheet = (Worksheet)sheets[sheetIndex];
                if (curSheet.Name == name)
                    return curSheet;
            }

            return null;
        }

        public async Task<decimal> CalculateOOOAsync(decimal income1, decimal income2)
        {
            var excelApp = ExcelHelper.Instance["OODemostration"];
                
            var workbookPath = HostingEnvironment.MapPath("~/Assets/calculator.xlsx");

            s_workbook = excelApp.Workbooks.Open(workbookPath, 0, true, 5,
                            "", "", true, XlPlatform.xlWindows, "\t", false, false,
                            0, true, true, 0);

                s_inputSheet = FindByName(s_workbook.Worksheets, Worksheet_Inputs);

            object[,] clientInputs = new object[2, 1];
            clientInputs[0, 0] = income1;
            clientInputs[1, 0] = income2;

            Range inRange = s_inputSheet.get_Range("C4", "C5");
            inRange.Value2 = clientInputs;

            s_outputSheet = FindByName(s_workbook.Worksheets, Worksheet_Outputs);
            Range outRange = s_outputSheet.get_Range("B6", "C6");

            var values = (object[,])outRange.Value2;

            decimal ret = (Convert.ToDecimal(values[1, 2]));

            var date = DateTime.Now;
            var fileName = @"C:\Out\" + date.Millisecond + @"ReportOO.xlsx";
            s_workbook.SaveAs(fileName);
            excelApp.Quit();

            return ret;
        }

        public async Task<decimal> CalculateEPAsync(decimal income1, decimal income2)
        {
            var workbookPath = HostingEnvironment.MapPath("~/Assets/calculator.xlsx");

            var _workbookTemplate = new FileInfo(workbookPath);
            using (var _xlsPackage = new ExcelPackage(_workbookTemplate))
            {
                var _wsInput = _xlsPackage.Workbook.Worksheets["Inputs"];
                _wsInput.Cells["C4"].Value = income1;
                _wsInput.Cells["C5"].Value = income2;

                var _wsOutputs = _xlsPackage.Workbook.Worksheets["Outputs"];
                decimal ret = (Convert.ToDecimal(_wsOutputs.Cells["C6"].Value));

                var date = DateTime.Now;
                var fileName = @"C:\Out\" + date.Millisecond + @"ReportEP.xlsx";

                var _outTemplate = new FileInfo(fileName);
                _xlsPackage.SaveAs(_outTemplate);

                return ret;
            }
        }

        public byte[] ExportToExcelFile()
        {
            var workbookPath = HostingEnvironment.MapPath("~/Assets/calculator.xlsx");

            var _workbookTemplate = new FileInfo(workbookPath);
            using (var _xlsPackage = new ExcelPackage(_workbookTemplate))
            {
                var _wsInput = _xlsPackage.Workbook.Worksheets["Inputs"];
                _wsInput.Cells["C4"].Value = 60000;
                _wsInput.Cells["C5"].Value = 1000;


                return _xlsPackage.GetAsByteArray();
            }

        }

        public Task<decimal> CalculateMemoAsync(decimal income1, decimal income2)
        {
            return Task.FromResult((income1 + income2)*0.75m);
        }
    }
}
