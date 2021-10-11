using AutoMapper;
using RealmDataProviders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmDataProviders.Translators
{
    internal class Map
    {
        private static IMapper _mapper;
        private static object _lock = new object();
        public static IMapper Mapper
        {
            get
            {
                if (_mapper == null)
                {
                    lock (_lock)
                    {
                        if (_mapper == null)
                        {
                            var configuration = new MapperConfiguration(cfg =>
                        {
                            cfg.CreateMap<DomainModel.Contact, RContact>()
                            .ForMember(source => source.Fields, option => option.MapFrom(d=>d.Fields));

                            cfg.CreateMap<DomainModel.ContactField, RContactField>();

                            cfg.CreateMap<RContact, DomainModel.Contact>()
                            .ForMember(source => source.Fields, option => option.MapFrom(d=>d.Fields));
                            cfg.CreateMap<RContactField, DomainModel.ContactField>();
                        });
                            // configuration.AssertConfigurationIsValid();
                            _mapper = configuration.CreateMapper();
                        }
                    }
                }
                return _mapper;
            }

        }
    }

}
