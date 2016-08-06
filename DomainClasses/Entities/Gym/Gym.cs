using DomainClasses.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainClasses.Entities.Gym
{
    /// <summary>
    /// ذخیره سازی اطلاعات پایه ای باشگاه
    /// </summary>
    public class Gym : BaseEntity
    {
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
        public ClassType Type { get; set; }
        /// <summary>
        /// تاریخ ثبت رکورد
        /// </summary>
        public DateTime CreationTime { get; set; }
    }
}
