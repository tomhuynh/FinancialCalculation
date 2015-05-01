using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiServer.App_Code
{
    public class ExcelHelper
    {
        private Dictionary<string, Microsoft.Office.Interop.Excel.Application> s_instances = new Dictionary<string, Microsoft.Office.Interop.Excel.Application>();

        private static ExcelHelper s_instance = new ExcelHelper();

        public static ExcelHelper Instance
        {
            get
            {
                return s_instance;
            }
        }

        public Microsoft.Office.Interop.Excel.Application this[string name]
        {
            get
            {
                if (!s_instances.ContainsKey(name))
                {
                    s_instances[name] = new Microsoft.Office.Interop.Excel.Application();
                    s_instances[name].DisplayAlerts = false;
                    s_instances[name].ScreenUpdating = false;
                    //s_instances[name].Visible = true;
                }

                return s_instances[name];
            }
        }
    }
}