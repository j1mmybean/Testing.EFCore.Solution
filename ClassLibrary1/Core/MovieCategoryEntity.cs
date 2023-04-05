using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public class MovieCategoryEntity
	{
		public int MovieCategoryID { get; set; }
		public string Name { get; set; }
		public MovieCategoryEntity(string name)
		{
			Name = name;
		}
	}
}
