using NTUB.FileManager.Site.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTUB.FileManager.Site.Models.Interfaces
{
	public interface IDocRepository
	{
		void Create(DocEntity entity);
		void Update(DocEntity entity);
		void Delete(DocEntity entity);
		IEnumerable<DocEntity> Search(string title, string description);
		DocEntity Load(int dosId);
	}
}
