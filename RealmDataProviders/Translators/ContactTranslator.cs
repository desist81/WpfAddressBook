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
                            .ForMember(source => source.PhoneNumbers, option => option.Ignore())
                            .ForMember(source => source.Emails, option => option.Ignore());

                            cfg.CreateMap<DomainModel.ContactEmail, RContactEmail>();
                            cfg.CreateMap<DomainModel.ContactPhone, RContactPhone>();

                            cfg.CreateMap<RContact, DomainModel.Contact>();
                            cfg.CreateMap<RContactEmail, DomainModel.ContactEmail>();
                            cfg.CreateMap<RContactPhone, DomainModel.ContactPhone>();
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
    