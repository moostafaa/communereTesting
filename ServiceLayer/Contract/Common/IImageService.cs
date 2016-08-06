using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Common;

namespace ServiceLayer.Contract.Common
{
    public interface IImageService
    {
        /// <summary>
        /// انتخاب تصویر برای ویرایش
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        EditImageViewModel GetForEdit(int Id);
        /// <summary>
        /// حذف تصویر بر اساس آی دی
        /// </summary>
        /// <param name="Id"></param>
        void Delete(int Id);
        /// <summary>
        /// به روز رسانی اطلاعات تصویر انتخابی
        /// </summary>
        /// <param name="item"></param>
        void Edit(EditImageViewModel item);
        /// <summary>
        /// ثبت تصویر جدید
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        ImageViewModel Create(AddImageViewModel item);
        /// <summary>
        /// بازگردانی لیست کلیه تصاویر
        /// </summary>
        /// <returns></returns>
        ImageListViewModel GetImages();
        /// <summary>
        /// بازگردانی لیست تصاویر مربوط به باشگاه انتخابی
        /// </summary>
        /// <param name="GymId"></param>
        /// <returns></returns>
        ImageListViewModel GetGymImages(int GymId);
        /// <summary>
        /// بازگردانی یک تصویر انتخابی
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        ImageViewModel Get(int Id);
        /// <summary>
        /// ثبت تصویر به عنوان تصویر کاور
        /// </summary>
        /// <param name="Id"></param>
        void SetAsCover(int Id);
    }
}
