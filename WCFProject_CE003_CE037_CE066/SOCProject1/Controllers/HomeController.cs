using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SOCProject1.ArtsService;

namespace SOCProject1.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ArtsService.Service1Client service = new Service1Client();
            IEnumerable<Art> arts = service.GetArts();
            return View(arts);
        }
        
        [HttpGet]
        public ActionResult CreateArt()
        {
            Art art = new Art();
            art.authorname = Request.Cookies.Get("UserName").Value;
            return View(art);
        }

        [HttpPost]
        public ActionResult CreateArt(Art model)
        {
            if (ModelState.IsValid)
            {
                ArtsService.Service1Client service = new Service1Client();
                service.insertArt(new Art
                {
                    authorname = Request.Cookies.Get("UserName").Value,
                    content = model.content,
                    title = model.title
                }) ;
                return RedirectToAction("Index", "Home");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        
        public ActionResult PersonalArts()
        {
            return View(new ArtsService.Service1Client().GetPersonalArts(Request.Cookies.Get("UserName").Value));
        }

        public ActionResult EditArt(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Art art = new ArtsService.Service1Client().GetArt((int)id);
            if (art == null)
            {
                return HttpNotFound();
            }
            return View(art);
        }

        [HttpPost]
        public ActionResult Editart(Art art)
        {
            new ArtsService.Service1Client().updateArt(art);
            return View();
        }

        public ActionResult DeleteArt(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            new ArtsService.Service1Client().deleteArt((int)id);
            return RedirectToAction("PersonalArts", "Home");
        }

        public ActionResult ArtDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Art art = new ArtsService.Service1Client().GetArt((int)id);
            if (art == null)
            {
                return HttpNotFound();
            }
            return View(art);
        }

    }
}