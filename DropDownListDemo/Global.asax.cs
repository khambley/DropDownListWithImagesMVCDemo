using DropDownListDemo.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Optimization;
using System.Web.Routing;

namespace DropDownListDemo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Country, ImageSelectListItem>()
                    .ForMember(dest => dest.ImageFileName, opt => opt.MapFrom(src => src.ImageFile))
                    .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.CountryName))
                    .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.CountryId.ToString(CultureInfo.InvariantCulture)));
        });
                
        }

    }
}
