using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Common
{
    /// <summary>
    /// مدل تعریف شده برای نمایش آبجکت کلاس تصویر بر روی ویو
    /// </summary>
    public class ImageViewModel
    {
        public int Id { get; set; }
        /// <summary>
        /// محل ذخیره سازی تصویر
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// آی دی باشگاه مربوطه
        /// </summary>
        public int GymId { get; set; }
        /// <summary>
        /// آیا این تصویر نمایش داده شود
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// برای نمایش تصویر به صورت کاور
        /// </summary>
        public bool IsCover { get; set; }
    }
}
