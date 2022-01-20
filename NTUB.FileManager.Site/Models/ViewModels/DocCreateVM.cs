using NTUB.FileManager.Site.Models.DTOs;
using NTUB.FileManager.Site.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NTUB.FileManager.Site.Models.ViewModels
{
	public class DocCreateVM
	{
		[Display(Name="標題")]
		[Required]
		[MaxLength(30)]
		public string Title { get; set; }

		[Display(Name = "描述")]
		[MaxLength(60)]
		public string Description { get; set; }

		[Display(Name = "檔案名稱")]
		public string FileName { get; set; }
	}

	public class DocEditVM
	{
		public int Id { get; set; }

		[Display(Name = "標題")]
		[Required]
		[MaxLength(30)]
		public string Title { get; set; }

		[Display(Name = "描述")]
		[MaxLength(60)]
		public string Description { get; set; }
		public string FileName { get; set; }
		
	}

	public static class DocEditVMExts
	{
		public static EditDocRequest ToRequest(this DocEditVM source)
		{
			return new EditDocRequest
			{
				Id = source.Id,
				Title = source.Title,
				Description = source.Description,
				FileName = source.FileName,
			};
		}
	}

	public static class DocEntityExts
	{
		public static DocEditVM ToEditVM(this DocEntity source)
		{
			return new DocEditVM
			{
				Id = source.Id,
				Title = source.Title,
				Description = source.Description,
				FileName = source.FileName,

			};
		}
	}

	public	class DocIndexVM
	{
		public int Id { get; set; }
		public string FileName { get; set; }

		[Display(Name = "標題")]
		public string Title { get; set; }
		public string Description { get; set; }

		[Display(Name = "異動日期")]
		[DisplayFormat(ApplyFormatInEditMode =false,DataFormatString ="{0:yyyy/MM/dd HH:mm:ss}")]
		public DateTime ModifiedTime { get; set; }

		[Display(Name = "描述")]
		public string BriefDescription
		{
			get
			{
				if(string.IsNullOrEmpty(this.Description))
				{
					return string.Empty;
				}
				int maxLength = 10;
				return this.Description.Length > maxLength
					? this.Description.Substring(0,maxLength)+"..."
					:this.Description;
			}
		}

	}
}