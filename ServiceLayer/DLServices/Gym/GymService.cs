using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Gym;

namespace ServiceLayer.DLServices.Gym
{
    public class GymService : Contract.Gym.IGymService
    {
        private DataLayer.Interfaces.IDbContext context;

        /// <summary>
        /// سازنده به منظور IOC ایجاد شده است
        /// به علت ساده تر بودن پروژه و ذخیره سازی در فایل این مورد در حال حاضر پیاده سازی نشده است
        /// </summary>
        public GymService()
        {
            context = new DataLayer.Context.ApplicationDBContext();
        }

        public GymViewModel Create(AddGymViewModel item)
        {
            var model = AutoMapper.Mapper.Map<DomainClasses.Entities.Gym.Gym>(item);


            var id = context.AddGym(model);
            model.Id = id;

            return AutoMapper.Mapper.Map<GymViewModel>(model);
        }

        public void Delete(int Id)
        {
            context.DeleteGym(Id);
        }

        public void Edit(EditGymViewModel item)
        {
            var model = AutoMapper.Mapper.Map<DomainClasses.Entities.Gym.Gym>(item);
            context.UpdateGym(model);
        }

        public GymViewModel Get(int Id)
        {
            var gym = context.Gyms.FirstOrDefault(x => x.Id == Id);
            var gymViewModel = AutoMapper.Mapper.Map<GymViewModel>(gym);
            gymViewModel.Images = GetImages(Id);
            gymViewModel.CoverImage = getCoverImage(gymViewModel.Images);
            return gymViewModel;
        }

        public EditGymViewModel GetForEdit(int Id)
        {
            var gym = context.Gyms.FirstOrDefault(x => x.Id == Id);
            return AutoMapper.Mapper.Map<EditGymViewModel>(gym);
        }

        public List<GymViewModel> GetGyms()
        {
            var models = AutoMapper.Mapper.Map<List<GymViewModel>>(context.Gyms);
            foreach (var item in models)
            {
                item.Images = GetImages(item.Id);
                item.CoverImage = getCoverImage(item.Images);
            }
            return models;
        }

        private string getCoverImage(List<ViewModel.Common.ImageViewModel> images)
        {
            var itm = images.FirstOrDefault(x => x.IsCover == true);
            if (itm != null)
                return itm.Path;
            return "";
        }

        private List<ViewModel.Common.ImageViewModel> GetImages(int gymId)
        {
            return AutoMapper.Mapper.Map<List<ViewModel.Common.ImageViewModel>>(context.Images.Where(x => x.GymId == gymId).ToList()); ;
        }
    }
}
