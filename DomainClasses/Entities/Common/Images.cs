using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainClasses.Entities.Common
{
    public class Image : BaseEntity
    {
        //image will be hard in <b>pictures</b> folder and path of file will be inserted to database
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
