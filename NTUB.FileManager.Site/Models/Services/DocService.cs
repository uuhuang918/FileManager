using NTUB.FileManager.Site.Models.DTOs;
using NTUB.FileManager.Site.Models.Entities;
using NTUB.FileManager.Site.Models.Infrastructures.Repositories;
using NTUB.FileManager.Site.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTUB.FileManager.Site.Models.Services
{
	public class DocService
	{
		private readonly IDocRepository _repo;

		public DocService()
		{
			this._repo = new DocRepository();
		}
		public DocService(IDocRepository repo)
		{
			_repo = repo;
		}
		public void Create(CreateDocRequest request)
		{
			DocEntity entity = new DocEntity
			{
				Title = request.Title,
				Description = request.Description,
				FileName = request.FileName,
				ModifiedTime = DateTime.Now,
			};
			_repo.Create(entity);
		}
		public void Update(EditDocRequest request)
		{
			DocEntity entity = this._repo.Load(request.Id);

			entity.Title = request.Title;
			entity.Description = request.Description;
			entity.FileName = request.FileName;
			entity.ModifiedTime = DateTime.Now;
			_repo.Update(entity);
		}
		public void Delete(int docId)
		{
			this._repo.Delete(docId);
		}
	}
}