using NTUB.FileManager.Site.Models.DTOs;
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
            if(file==null || file.FileName==null || file.ContentLength==0)
			{
                ModelState.AddModelError("FileName", "檔案必填");
                return View(model);
			}
            //將檔案儲存，得知實際存的檔名
            string path =Server.MapPath("~/Files/");
            string newFileName = SaveFile(file, path);
            //將新增名存到model
            model.FileName = newFileName;
            //新增紀錄
            service.Create(model.ToRequest());
            //redirect to index
            return RedirectToAction("Index");
        }

        public ActionResult Edit (int id)
		{
            var entity =repository.Load(id);
            return View(entity.ToEditVM());
		}

        [HttpPost]
        public ActionResult Edit(DocEditVM model, HttpPostedFileBase file)
		{
            if (ModelState.IsValid==false) return View(model);

            string path = Server.MapPath("~/Files/");
            string newFileName = TrySaveFile(file, path);

            string origFileName = repository.Load(model.Id).FileName;
            model.FileName = string.IsNullOrEmpty(newFileName) ? origFileName : newFileName;

            service.Update(model.ToRequest());
            TryDeleteFile(path, origFileName);
            return RedirectToAction("Index");

		}

        private string SaveFile(HttpPostedFileBase file,string path)
		{
            string ext=System.IO.Path.GetExtension(file.FileName);

            string targetFileName=Guid.NewGuid().ToString("N")+ ext;

            string fullName=System.IO.Path.Combine(path,targetFileName);

            file.SaveAs(fullName);
            return targetFileName;

		}
    }
}