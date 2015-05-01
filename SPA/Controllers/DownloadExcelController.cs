using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Mvc;
using Business.Calculation;
using Business.Facade.Alert;
using Contract.Facades;
using Contract.Models;
using Newtonsoft.Json;
using OfficeOpenXml;
using RestSharp;

namespace SPA.Controllers
{
    [RoutePrefix("abc")]
    public class DownloadExcelController : Controller
    {
        [HttpGet, Route("calcEps")]
        public ActionResult Get()
        {
            try
            {
                var baseUrl = "http://localhost:85/api";
                var client = new RestClient(baseUrl);
                var request = new RestRequest("alerts", Method.GET);

                var response = client.Execute(request);

                var users = JsonConvert.DeserializeObject<List<Alert>>(response.Content);

                using (var _xlsPackage = new ExcelPackage())
                {
                    var _ws = _xlsPackage.Workbook.Worksheets.Add("Users");

                    var _label = new string[] {"Id", "Description", "Income1", "Income2", "Income3", "Income4", "Income5", "Income6" };
                       
                    var _data = new List<object[]>();
                    _data.Add(_label);

                    foreach (var user in users)
                    {
                        _data.Add(
                            new object[]
                            {
                                user.Id,
                                user.Description,
                                user.Income1,
                                user.Income2,
                                user.Income3,
                                user.Income4,
                                user.Income5,
                                user.Income6
                            });
                    }

                    _ws.Cells["A1"].LoadFromArrays(_data);

                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;  filename=ExcelDemo.xlsx");

                    Response.BinaryWrite(_xlsPackage.GetAsByteArray());
                }
            }
            catch (Exception e)
            {
                var err = e.Message;
            }

            return null;
        }

    }
}