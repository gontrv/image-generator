using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using imageGenerator.Models;

namespace imageGenerator.Controllers
{
    public class HomeController : Controller
    {
        ImageGetter _imgGetter;

        public HomeController()
        {
            _imgGetter = new ImageGetter(@"https://raw.githubusercontent.com/gontrv/data-publishing/master/");
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetImage(string imageName)
        {
            if (_imgGetter.TryGet(imageName))
            {
                return File(_imgGetter.Data, _imgGetter.Ext);
            }
            return HttpNotFound();
        }
    }
}