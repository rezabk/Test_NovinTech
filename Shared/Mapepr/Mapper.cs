using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Shared.Mapepr
{
    public class Mapper
    {
        public Task<TDestination> MapAsync<TSource, TDestination>(TSource source, TDestination destination)
        {
            var mapperConfiguration = new MapperConfiguration(configuration =>
            {
                configuration.CreateMap<TSource, TDestination>();
            });
            var mapper = mapperConfiguration.CreateMapper();
            return Task.Run(() => mapper.Map(source, destination));
        }
    }
}
