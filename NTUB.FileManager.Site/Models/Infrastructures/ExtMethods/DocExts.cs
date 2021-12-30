using NTUB.FileManager.Site.Models.EFModels;
using NTUB.FileManager.Site.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTUB.FileManager.Site.Models.Infrastructures.ExtMethods
{
	public static class DocExts
	{
		public static DocEntity ToEntity(this Doc source)
			=> new DocEntity
			{
				Id=source.Id,
				Title=source.Title,
				Description=source.Description,
				FileName=source.FileName,
				ModifiedTime=source.ModifiedTime,
			};
	}
}