using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using AutoMapper;
using AutoMapperProfile;

namespace communereTesting
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //به منظور دسترسی به آدرس صحیح پروژه در شروع کار این آدرس را در متغیر استاتیک کلاس کانتکس ذخیره می کنیم
            DataLayer.Context.ApplicationDBContext.ServerBasePath = Server.MapPath("~");
            InitializeAutoMapperWithProfiles();
        }

        /// <summary>
        /// initialize automapper with custom profiles
        /// </summary>
        private void InitializeAutoMapperWithProfiles()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<GymProfile>();
                cfg.AddProfile<ImageProfile>();
            });
        }
    }
}
