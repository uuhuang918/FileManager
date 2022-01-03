using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTUB.FileManager.Site.Models.DTOs
{
	public class EditDocRequest
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
	}
}
