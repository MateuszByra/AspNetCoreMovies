using AutoMapper;
using Movies.Infrastructure.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Web.AutoMapper
{
    public static class AutoMapperConfigWeb
    {
        /*docelowo użyty w startup. wykorzystuje konfiguracje insfrastruktury i dodaje swoja.*/
        public static IMapper Initialize()=>
            AutoMapperConfig.GetMapperConfigurationExpression()
    }
}
