using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTUB.FileManager.Site.Models.DTOs
{
	public class CreateDocRequest
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public string FileName {get; set; }
	}

}