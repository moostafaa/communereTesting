using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ViewModel.Common
{
    public class AddImageViewModel
    {
        //آی دی باشگاه در اینجا ذخیره می گردد
        public int GymId { get; set; }
        //تصویر ارسال شده از سمت کلاینت
        public HttpPostedFileBase image { get; set; }
        //آدرس تصویر بعد از آپلود بر روی سرور در این متغیر قرار خواهد گرفت
        public string Path { get; set; }   

    }
}
