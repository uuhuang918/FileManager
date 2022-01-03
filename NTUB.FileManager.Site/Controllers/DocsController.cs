using NTUB.FileManager.Site.Models.Infrastructures.ExtMethods;
using NTUB.FileManager.Site.Models.Infrastructures.Repositories;
using NTUB.FileManager.Site.Models.Interfaces;
using NTUB.FileManager.Site.Models.Services;
using NTUB.FileManager.Site.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTUB.FileManager.Site.Controllers
{
    public class DocsController : Controller
    {
        private DocService service;
        private IDocRepository repository;
        public DocsController()
		{
            service = new DocService();
            repository = new DocRepository();
		}
        // GET: Docs
        public ActionResult Index(string title,string description)
        {
            var data = repository
                .Search(title, description)
                .Select(x => x.ToIndexVM());
            
            ViewBag.C_Title=title;
            ViewBag.C_Description=description;

            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DocCreateVM model, HttpPostedFileBase file)
        {
            //檢查有沒有上傳檔案(必填)
            //將檔案儲存，得知實際存的檔名
            //將新增名存到model
            //新增紀錄
            //redirect to index
            return View(model);
        }

    }
}