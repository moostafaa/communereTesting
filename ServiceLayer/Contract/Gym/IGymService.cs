using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Gym;

namespace ServiceLayer.Contract.Gym
{
    /// <summary>
    /// قرار داد الزامات پیاده سازی سرویس مربوط به باشگاه
    /// </summary>
    public interface IGymService
    {
        /// <summary>
        /// آبجکت مربوط به باشگاه را برای ویرایش برگردان
        /// </summary>
        /// <param name="Id">آی دی باشگاه</param>
        /// <returns>باشگاه را بر می گرداند در صورت وجود نداشتن آی دی نال برگشت داده می شود</returns>
        EditGymViewModel GetForEdit(int Id);
        /// <summary>
        /// حذف آیتم مربوطه از دیتابیس
        /// </summary>
        /// <param name="Id"></param>
        void Delete(int Id);
        /// <summary>
        /// ذخیره تغییرات اعمال شده بر روی باشگاه
        /// </summary>
        /// <param name="item"></param>
        void Edit(EditGymViewModel item);
        /// <summary>
        /// ایجاد باشگاه جدید
        /// </summary>
        /// <param name="item"></param>
        /// <returns>آیتم باشگاه ایجاد شده برگردانده می شود</returns>
        GymViewModel Create(AddGymViewModel item);
        /// <summary>
        /// لیست کلی باشگاه ها برگردانده می شود
        /// </summary>
        /// <returns></returns>
        List<GymViewModel> GetGyms();
        /// <summary>
        /// اطلاعات باشگاه بر اساس آی دی مربوطه برگشت داده می شود
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        GymViewModel Get(int Id);
    }
}
