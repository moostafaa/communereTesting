using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IDbContext
    {
        IList<DomainClasses.Entities.Gym.Gym> Gyms { get; set; }
        IList<DomainClasses.Entities.Common.Image> Images { get; set; }
        void SaveChanges();
        int AddGym(DomainClasses.Entities.Gym.Gym Item);
        void DeleteGym(int Id);
        void UpdateGym(DomainClasses.Entities.Gym.Gym Item);


        int AddImage(DomainClasses.Entities.Common.Image Item);
        void DeleteImage(int Id);
        void UpdateImage(DomainClasses.Entities.Common.Image Item);

    }
}
