﻿using HAA.API.Helper;
using HAA.BAL.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace HAA.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            AutoMapper.Mapper.Initialize(config: cfg =>
            {
                cfg.AddProfile<AotomapperProfileBDL>();
                cfg.AddProfile<AutomapperProfileApiDl>();
            });
        }
    }
}