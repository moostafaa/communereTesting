using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Gym
{
    /// <summary>
    /// مدل تعریف شده برای نمایش اطلاعات باشگاه انتخابی بر روی ویو
    /// </summary>
    public class GymViewModel
    {
        public int Id { get; set; }
        /// <summary>
        /// نام باشگاه
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// آدرس باشگاه
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// نام مدیر باشگاه
        /// </summary>
        public string Manager { get; set; }
        /// <summary>
        /// نوع کلاس باشگاه
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// تاریخ ثبت رکورد
        /// </summary>
        public DateTime CreationTime { get; set; }
        /// <summary>
        /// آدرس تصویر پیش فرض باشگاه
        /// </summary>
        public string CoverImage { get; set; }
        /// <summary>
        /// لیست تصاویر باشگاه
        /// </summary>
        public List<Common.ImageViewModel> Images { get; set; }
    }
}
