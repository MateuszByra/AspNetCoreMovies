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
           })
            .CreateMapper();

        /// <summary>
        /// Mapper configuration with configuration from other app layer.
        /// </summary>
        /// <param name="configuration">Configure action</param>
        /// <returns></returns>
        public static IMapper InitializeMapperForWholeApplication(Action<IMapperConfigurationExpression> configuration)
        {
            return new MapperConfiguration(cfg =>
            {
                configuration(cfg);
                cfg.CreateMap<Movie, MovieDTO>();
            })
            .CreateMapper();
        }


    }
}
