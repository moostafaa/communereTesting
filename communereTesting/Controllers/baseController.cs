using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using communereTesting.Helpers;
using System.IO;

namespace communereTesting.Controllers
{

    /// <summary>
    /// در این کنترل پایه عملیات مربوط به اعتبار سنجی و احراز هویت درخواست ها انجام خواهد شد.
    /// </summary>
    public class baseController : Controller
    {

        public baseController()
        {

        }

        public string UploadFile(HttpPostedFileBase file)
        {
            string filePath = "", randFileName = "";
            if (file != null && file.ContentLength > 0)
            {
                randFileName = Path.GetRandomFileName() + Path.GetExtension(file.FileName);
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Images/"), randFileName);
                filePath = "/Images/" + randFileName;
                file.SaveAs(path);
            }

            return filePath;
        }

        protected string getExceptionFullDetail(Exception ex)
        {
#if DEBUG
            string msg = ex.Message;

            ex = ex.InnerException;
            while (ex != null)
            {
                msg += Environment.NewLine + ex.Message;
                ex = ex.InnerException;
            }

            return msg;
#else
            return "خطایی در عملیات شما رخ داد, دقایقی بعد مجددا تلاش کنید.";
#endif
        }

        #region Alerts Creation Part

        public void Success(string message, bool dismissable = true, bool autoclose = false, int autoclosetime = 15000)
        {
            AddAlert(AlertStyles.Success, message, dismissable, autoclose, autoclosetime);
        }

        public void Information(string message, bool dismissable = true, bool autoclose = false, int autoclosetime = 15000)
        {
            AddAlert(AlertStyles.Information, message, dismissable, autoclose, autoclosetime);
        }

        public void Warning(string message, bool dismissable = true, bool autoclose = false, int autoclosetime = 15000)
        {
            AddAlert(AlertStyles.Warning, message, dismissable, autoclose, autoclosetime);
        }

        public void Danger(string message, bool dismissable = true, bool autoclose = false, int autoclosetime = 15000)
        {
            AddAlert(AlertStyles.Danger, message, dismissable, autoclose, autoclosetime);
        }

        public void Block(string message, bool dismissable = true, bool autoclose = false, int autoclosetime = 15000)
        {
            AddAlert(AlertStyles.Block, message, dismissable, autoclose, autoclosetime);
        }

        private void AddAlert(string alertStyle, string message, bool dismissable, bool autoclose, int autoclosetime)
        {
            var alerts = TempData.ContainsKey(Alert.TempDataKey)
                            ? (List<Alert>)TempData[Alert.TempDataKey]
                            : new List<Alert>();

            alerts.Add(new Alert
            {
                AlertStyle = alertStyle,
                Message = message,
                Dismissable = dismissable,
                AutoClose = autoclose,
                AutoCloseTime = autoclosetime
            });

            TempData[Alert.TempDataKey] = alerts;
        }

        #endregion
    }
}