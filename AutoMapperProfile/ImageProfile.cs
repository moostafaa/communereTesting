using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ViewModel.Common;
using DomainClasses.Entities.Common;

namespace AutoMapperProfile
{
    /// <summary>
    /// تنظیمات مربوط به نگاشت آبجکت کلاس تصویر
    /// </summary>
    public class ImageProfile : Profile
    {
        [Obsolete]
        protected override void Configure()
        {
            CreateMap<AddImageViewModel, Image>();
            CreateMap<EditImageViewModel, Image>();


            CreateMap<Image, ImageViewModel>()
                //.ForMember(src => src.CreationTime, dest => dest.MapFrom(s => s.CreationTime))
                ;
            CreateMap<Image, EditImageViewModel>();
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
