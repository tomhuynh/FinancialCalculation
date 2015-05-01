using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using Business.Calculation;
using Contract.Facades;
using Contract.Models;

namespace WebAPI.Controllers
{
    public class DownloadExcelController : ApiController
    {
        private readonly ICalculationFacade _calculationFacade;

        public DownloadExcelController()
        {
            _calculationFacade = new CalculationFacade();
        }

        [HttpPost, Route("calcEps")]
        public HttpResponseMessage Post(List<Alert> users)
        {
            try
            {
                byte[] excelData = _calculationFacade.ExportToExcelFile();

                var result = new HttpResponseMessage(HttpStatusCode.OK);
                var stream = new MemoryStream(excelData);
                result.Content = new StreamContent(stream);
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = "Data.xls"
                };

                return result;
            }
            catch (Exception ex)
            {
                //m_logger.ErrorException("Exception exporting as excel file: ", ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }




            /*
             Response.ContentType="application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
             Response.AddHeader("content-disposition","attachment;filename=ExcelFromArray.xlsx");
             Response.BinaryWrite(_xlPackage.GetAsByteArray()
              
             */



            //try
            //{
            //    //Response.write
            //    return 100;
            //}
            //catch (Exception e)
            //{
            //    var err = e.Message;
            //}

            //return 0;
        }

    }
}