using AutoMapper;
using Movies.Infrastructure.Commands.Movies;
using Movies.Infrastructure.Mappers;
using Movies.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Web.AutoMapper
{
    public static class AutoMapperConfigWeb
    {
        /*docelowo użyty w startup. wykorzystuje konfiguracje insfrastruktury i dodaje swoja.*/
        public static IMapper Initialize() =>
            AutoMapperConfig.InitializeMapperForWholeApplication(cfg => {

                cfg.CreateMap<MovieViewModel, CreateMovie>()
                    .ForMember(dest => dest.DurationMinutes, opt => opt.MapFrom(src => src.DurationInMinutes))
                    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));
            });
    }
}
