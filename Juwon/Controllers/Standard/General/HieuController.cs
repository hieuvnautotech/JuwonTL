using Juwon.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Juwon.Controllers.Standard.General
{
    public class HieuController : Controller
    {
        private readonly IHieuService hieuService;
        public HieuController(IHieuService IHieuService)
        {
            hieuService = IHieuService;
        }
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return await Task.Run(() => View("~/Views/Standard/General/Hieu/Hieu.cshtml"));
        }

        [HttpGet]
        public async Task<ActionResult> Search(string keyWord = "")
        {
            try
            {
                var result = await hieuService.SearchActive(keyWord);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpGet]
        public async Task<ActionResult> SearchAll(string keyWord = "")
        {
            var result = await hieuService.SearchAll(keyWord);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}