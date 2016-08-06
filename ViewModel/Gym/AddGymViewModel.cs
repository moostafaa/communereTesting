using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ViewModel.Gym
{
    public class AddGymViewModel
    {
        //[Display(Name = "")]
        public int Id { get; set; }
        /// <summary>
        /// نام باشگاه
        /// </summary>
        [Display(Name = "نام باشگاه")]
        //[Required]
        public string Name { get; set; }
        /// <summary>
        /// آدرس باشگاه
        /// </summary>
        [Display(Name = "آدرس")]
        //[Required]
        public string Address { get; set; }
        /// <summary>
        /// نام مدیر باشگاه
        /// </summary>
        [Display(Name = "مدیر باشگاه")]
        //[Required]
        public string Manager { get; set; }
        /// <summary>
        /// نوع کلاس باشگاه
        /// </summary>
        [Display(Name = "کلاس باشگاه")]
        //[Required]
        public string Type { get; set; }
    }
}
