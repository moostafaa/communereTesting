using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ViewModel.Gym
{

    /// <summary>
    /// مدل تعریف شده برای استفاده در ویرایش اطلاعات باشگاه
    /// </summary>
    public class EditGymViewModel
    {
        public int Id { get; set; }
        /// <summary>
        /// نام باشگاه
        /// </summary>
        [Display(Name="نام باشگاه")]
        public string Name { get; set; }
        /// <summary>
        /// آدرس باشگاه
        /// </summary>
        [Display(Name = "آدرس باشگاه")]
        public string Address { get; set; }
        /// <summary>
        /// نام مدیر باشگاه
        /// </summary>
        [Display(Name = "مدیریت باشگاه")]
        public string Manager { get; set; }
        /// <summary>
        /// نوع کلاس باشگاه
        /// </summary>
        [Display(Name = "کلاس باشگاه")]
        public string Type { get; set; }
    }
}
