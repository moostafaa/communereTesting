using DomainClasses.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Common;

namespace ServiceLayer.DLServices.Common
{
    public class ImageService : Contract.Common.IImageService
    {
        DataLayer.Interfaces.IDbContext context;

        public ImageService()
        {
            context = new DataLayer.Context.ApplicationDBContext();
        }

        public ImageViewModel Create(AddImageViewModel item)
        {
            var model = AutoMapper.Mapper.Map<Image>(item);
            model.IsActive = true;
            var id = context.AddImage(model);
            model.Id = id;

            return AutoMapper.Mapper.Map<ImageViewModel>(null);
        }

        public void Delete(int Id)
        {
            context.DeleteImage(Id);
        }

        public void Edit(EditImageViewModel item)
        {
            var model = AutoMapper.Mapper.Map<Image>(item);
            context.UpdateImage(model);
        }

        public ImageViewModel Get(int Id)
        {
            var image = context.Images.FirstOrDefault(x => x.Id == Id);
            return AutoMapper.Mapper.Map<ImageViewModel>(image);
        }

        public EditImageViewModel GetForEdit(int Id)
        {
            var image = context.Images.FirstOrDefault(x => x.Id == Id);
            return AutoMapper.Mapper.Map<EditImageViewModel>(image);
        }

        public ImageListViewModel GetGymImages(int GymId)
        {
            var imageList = AutoMapper.Mapper.Map<List<ImageViewModel>>(context.Images.Where(x => x.GymId == GymId).ToList());
            return
                new ImageListViewModel { Images = imageList };
        }

        public ImageListViewModel GetImages()
        {
            var imageList = AutoMapper.Mapper.Map<List<ImageViewModel>>(context.Images);
            return
                new ImageListViewModel { Images = imageList };
        }

        public void SetAsCover(int Id)
        {
            var image = context.Images.FirstOrDefault(x => x.Id == Id);
            if (image != null)
            {
                var allImages = context.Images.Where(x => x.GymId == image.GymId).ToList();
                foreach (var item in allImages)
                {
                    item.IsCover = false;
                    context.UpdateImage(item);
                }
                image.IsCover = true;
                context.UpdateImage(image);
            }
        }
    }
}
