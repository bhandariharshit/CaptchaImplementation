using CaptchaImplementation.Common;
using CaptchaImplementation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaptchaImplementation.Controllers
{
    public class CaptchaController : Controller
    {
        // GET: Captcha
        public ActionResult Index()
        {
            return View();
        }
        // POST: Captcha
        [HttpPost]
        public ActionResult Index(CaptchaModel objCaptchaModel)
        {
            if (IsValidCaptcha(objCaptchaModel))
            {
                return RedirectToAction("Success");
            }
            ViewBag.ErrorMessage="Incorrect Captcha, Please try again";
            return View("Index");
        }

        /// <summary>
        /// Method to check whether the captcha is valid or not
        /// </summary>
        /// <param name="objCaptchaModel"></param>
        /// <returns></returns>
        public bool IsValidCaptcha(CaptchaModel objCaptchaModel)
        {
            bool check = false;
            try
            {
                if(!String.IsNullOrEmpty(objCaptchaModel.Text) && Session[Cons.CaptchaSessionKey].ToString()==objCaptchaModel.Text)
                {
                    check = true;
                }
            }
            catch (Exception ex)
            {
                //log exception
                throw;
            }
            return check;
        }
        /// <summary>
        /// Method to generate captcha
        /// </summary>
        public void GenerateCaptcha()
        {
            try
            {
                CaptchaHandler.GenerateCaptcha(200,40,5);
            }
            catch (Exception ex)
            {

                throw;
            };
        }

        public ActionResult Success()
        {
            ViewBag.Message = "Correct Captcha";
            return View();
        }
    }
}
