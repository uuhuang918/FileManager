using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTUB.FileManager.Site.Models.Entities
{
	public class DocEntity
	{
        public int Id { get; set; }

    
        public string Title { get; set; }

     
        public string Description { get; set; }

     
        public string FileName { get; set; }

        public DateTime ModifiedTime { get; set; }
    }
}