using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Movies.Core.Domain;
using Movies.Infrastructure.DTO;

namespace Movies.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
           => new MapperConfiguration(cfg =>
           {
               cfg.CreateMap<Movie, MovieDTO>();
               cfg.CreateMap<Director, DirectorDTO>();
           })
            .CreateMapper();
    }
}
