﻿using System.Web;
using System.Web.Mvc;

namespace P3_MVC_EF6_CF
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
