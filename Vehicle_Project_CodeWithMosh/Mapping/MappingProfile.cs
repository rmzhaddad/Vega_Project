using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle_Project_CodeWithMosh.Controllers.Resources;
using Vehicle_Project_CodeWithMosh.Models;


namespace Vehicle_Project_CodeWithMosh.Controllers
{
    public class MappingProfile : Profile 
    {

        public MappingProfile()
        {
            CreateMap<Make, MakeResource>();
            CreateMap<Model, ModelResource>();
            CreateMap<Feature, FeatureResource>();
            CreateMap<Vehicle, VehicleResource>()
                .ForMember(vr => vr.Contact, opt => opt.MapFrom(v => new VehicleResource.contactResource { Name = v.ContactName, Email = v.ContactEmail, Phone = v.ContactPhone }))
                .ForMember(vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select(vf =>vf.FeatureId)));                  
            //api to domain
            CreateMap<VehicleResource,Vehicle>().ForMember(v => v.ContactName, opt => opt.MapFrom(vr => vr.Contact.Name));
            CreateMap<VehicleResource, Vehicle>().ForMember(v => v.ContactEmail, opt => opt.MapFrom(vr => vr.Contact.Email));
            CreateMap<VehicleResource, Vehicle>().ForMember(v => v.ContactPhone, opt => opt.MapFrom(vr => vr.Contact.Phone));
            CreateMap<VehicleResource, Vehicle>().ForMember(v => v.Features, opt => opt.MapFrom(vr => vr.Features.Select(id => new VehicleFeature {FeatureId=id })));

        }

    }
}
