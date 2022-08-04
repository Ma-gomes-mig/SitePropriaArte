using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.SitePropriaArte.Controllers
{
    [Authorize]
    public class QuadroController : Controller
    {
        //GET: Usuario/EspacoGaleria
        public ActionResult EspacoGaleria()
        {
            return View(); //page_load
        }
    }
}