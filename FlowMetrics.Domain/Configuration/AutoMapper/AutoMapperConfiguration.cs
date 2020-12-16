using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlowMetrics.Domain.Configuration.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ViewModelToEntity());
                cfg.AddProfile(new EntityToViewModel());
            });
        }
    }
}
