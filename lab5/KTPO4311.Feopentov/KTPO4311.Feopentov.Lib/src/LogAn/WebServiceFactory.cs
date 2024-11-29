using System;
using System.Collections.Generic;
using System.Text;

namespace KTPO4311.Feopentov.Lib.src.LogAn
{
    public static class WebServiceFactory
    {
        private static IWebService customService = null;

        ///<summary>Создание объектов </summary>
        public static IWebService Create()
        {
            if (customService != null)
            {
                return customService;
            }
            return new WebService();
        }
        public static void SetWebService(IWebService srvc)
        {
            customService = srvc;
        }
    }
}
