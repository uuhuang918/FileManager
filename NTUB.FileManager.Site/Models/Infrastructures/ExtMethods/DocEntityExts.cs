using NTUB.FileManager.Site.Models.EFModels;
using NTUB.FileManager.Site.Models.Entities;
using NTUB.FileManager.Site.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTUB.FileManager.Site.Models.Infrastructures.ExtMethods
{
	public static class DocEntityExts
	{
		public static Doc ToDoc(this DocEntity source)
			=> new Doc
			{
				Title = source.Title,
				Description = source.Description,
				FileName = source.FileName,
				ModifiedTime = source.ModifiedTime

			};

		public static DocIndexVM ToIndexVM(this DocEntity source)
			=> new DocIndexVM
			{
				Id=source.Id,
				Title = source.Title,
				Description = source.Description,
				ModifiedTime = source.ModifiedTime,
				FileName = source.FileName,

			};
	}
}