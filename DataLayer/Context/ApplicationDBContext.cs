using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Interfaces;
using DomainClasses;
using DomainClasses.Entities.Common;
using DomainClasses.Entities.Gym;

namespace DataLayer.Context
{
    //site data will save in file, for this porpuse 
    public class ApplicationDBContext : IDbContext
    {
        public static string ServerBasePath = "";

        public IList<Gym> Gyms { get; set; }
        public IList<DomainClasses.Entities.Common.Image> Images { get; set; }


        public ApplicationDBContext()
        {
            var imagesContent = System.IO.File.ReadAllText(ServerBasePath + @"\Data\images.json");
            var gymsContent = System.IO.File.ReadAllText(ServerBasePath + @"\Data\gyms.json");

            Images = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DomainClasses.Entities.Common.Image>>(imagesContent);
            Gyms = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DomainClasses.Entities.Gym.Gym>>(gymsContent);

            if (Images == null)
                Images = new List<DomainClasses.Entities.Common.Image>();
            if (Gyms == null)
                Gyms = new List<Gym>();
        }

        public void SaveChanges()
        {
            var imagesContent = Newtonsoft.Json.JsonConvert.SerializeObject(Images);
            var gymsContent = Newtonsoft.Json.JsonConvert.SerializeObject(Gyms);

            System.IO.File.WriteAllText(ServerBasePath + @"\Data\images.json", imagesContent);
            System.IO.File.WriteAllText(ServerBasePath + @"\Data\gyms.json", gymsContent);
        }

        /// <summary>
        /// با توجه به اینکه داده ها به صورت json در فایل ذخیره می شود برای اطمینان از ست شدن درست آی دی ها این متد اضافه گردید
        /// </summary>
        /// <param name="Item">آیتمی که قصد افزودن آن را به مجموعه داریم</param>
        /// <returns>مقدار آی دی عنصر اضافه شده</returns>
        public int AddGym(DomainClasses.Entities.Gym.Gym Item)
        {
            int nextId = 0;
            if (Gyms.Any())
                nextId = Gyms.Max(x => x.Id) + 1;

            Item.Id = nextId;
            Item.CreationTime = DateTime.Now;
            Gyms.Add(Item);
            SaveChanges();

            return nextId;
        }

        public void DeleteGym(int Id)
        {
            var imagesToDelete = Images.Where(x => x.GymId == Id).ToList();
            foreach (var item in imagesToDelete)
                Images.Remove(item);
            var gym = Gyms.FirstOrDefault(x => x.Id == Id);
            if (gym != null)
                Gyms.Remove(gym);
            SaveChanges();
        }

        public void UpdateGym(Gym Item)
        {
            var gym = Gyms.FirstOrDefault(x => x.Id == Item.Id);
            if (gym != null)
            {
                Gyms.Remove(gym);
                Gyms.Add(Item);
            }
            SaveChanges();
        }

        public int AddImage(Image Item)
        {
            int nextId = 0;
            if (Images.Any())
            nextId = Images.Max(x => x.Id) + 1;

            Item.Id = nextId;
            Images.Add(Item);
            SaveChanges();

            return nextId;
        }

        public void DeleteImage(int Id)
        {
            var imagesToDelete = Images.FirstOrDefault(x => x.Id == Id);
            if (imagesToDelete != null)
                Images.Remove(imagesToDelete);
            SaveChanges();
        }

        public void UpdateImage(Image Item)
        {
            var image = Images.FirstOrDefault(x => x.Id == Item.Id);
            if (image != null)
            {
                image = Item;
            }
            SaveChanges();
        }
    }
}
