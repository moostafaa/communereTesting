using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ViewModel.Gym;
using DomainClasses.Entities.Gym;

namespace AutoMapperProfile
{
    /// <summary>
    /// تنظیمات مربوط به نگاشت آبجکت های دامین و ویو
    /// </summary>
    public class GymProfile : Profile
    {
        [Obsolete]
        protected override void Configure()
        {
            CreateMap<AddGymViewModel, Gym>();
            CreateMap<EditGymViewModel, Gym>();


            CreateMap<Gym, GymViewModel>()
                //.ForMember(src => src.CreationTime, dest => dest.MapFrom(s => s.CreationTime))
                .ForMember(src => src.Type, dest => dest.MapFrom(s => (int)s.Type))
                ;
            CreateMap<Gym, EditGymViewModel>()
                .ForMember(src => src.Type, dest => dest.MapFrom(s => (int)s.Type))
                ;
            
        }


        public override string ProfileName
        {
            get
            {
                return GetType().Name;
            }
        }
    }
}
