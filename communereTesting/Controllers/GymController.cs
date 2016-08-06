using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace communereTesting.Controllers
{
    public class GymController : baseController
    {
        ServiceLayer.Contract.Gym.IGymService service;
        ServiceLayer.Contract.Common.IImageService imageService;


        public GymController()
        {
            //با کمک IOC آبجکت ها باید تزریق شوند
            service = new ServiceLayer.DLServices.Gym.GymService();
            imageService = new ServiceLayer.DLServices.Common.ImageService();
        }

        // GET: Gym
        public ActionResult Index()
        {
            return View(service.GetGyms());
        }

        public ActionResult Gym(int Id)
        {
            var gym = service.Get(Id);
            ViewBag.Gym = gym;
            return View(gym.Images);
        }

        public ActionResult Create()
        {
            return View(new ViewModel.Gym.AddGymViewModel());
        }

        [HttpPost]
        public ActionResult Create(ViewModel.Gym.AddGymViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("داده ها به درستی وارد نشده اند");
                service.Create(model);
                Success("با موفقیت ذخیره گردید");
                return RedirectToAction("ManageImages", new { Id = model.Id });
            }
            catch (Exception ex)
            {
                Danger(getExceptionFullDetail(ex));
            }
            return View(model);
        }

        public ActionResult Edit(int Id)
        {
            return View(service.GetForEdit(Id));
        }

        [HttpPost]
        public ActionResult Edit(ViewModel.Gym.EditGymViewModel model)
        {
            try
            {
                service.Edit(model);
                Success("ویرایش باشگاه با موفقیت انجام گرفت");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Danger(getExceptionFullDetail(ex));
            }
            return View(model);
        }

        public ActionResult Delete(ViewModel.Gym.DeleteGymViewModel model)
        {
            try
            {
                service.Delete(model.Id);
                Success("باشگاه انتخابی با موفقیت حذف گردید");
            }
            catch (Exception ex)
            {
                Danger(getExceptionFullDetail(ex));
            }
            return RedirectToAction("Index");
        }

        public ActionResult ManageImages(int Id)
        {
            ViewBag.Gym = service.Get(Id);
            return View(imageService.GetGymImages(Id));
        }

        [HttpPost]
        public ActionResult NewImage(ViewModel.Common.AddImageViewModel model)
        {
            try
            {
                model.Path = UploadFile(model.image);
                imageService.Create(model);
                Success("تصویر جدید با موفقیت ثبت گردید");
            }
            catch (Exception ex)
            {
                Danger(getExceptionFullDetail(ex));
            }
            return RedirectToAction("ManageImages", new { @Id = model.GymId });
        }

        public ActionResult DeleteImage(ViewModel.Common.DeleteImageViewModel model)
        {
            try
            {

                imageService.Delete(model.Id);
                Success("تصویر جدید با موفقیت حذف گردید");
            }
            catch (Exception ex)
            {
                Danger(getExceptionFullDetail(ex));
            }
            return RedirectToAction("ManageImages", new { @Id = model.GymId });
        }

        public ActionResult SetCover(ViewModel.Common.DeleteImageViewModel model)
        {
            try
            {

                imageService.SetAsCover(model.Id);
                Success("تصویر انتخابی به عنوان تصویر کاور ثبت گردید");
            }
            catch (Exception ex)
            {
                Danger(getExceptionFullDetail(ex));
            }
            return RedirectToAction("ManageImages", new { @Id = model.GymId });
        }
    }
}