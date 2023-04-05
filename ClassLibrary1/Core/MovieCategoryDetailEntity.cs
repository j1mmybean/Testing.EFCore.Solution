using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public class MovieCategoryDetailEntity
	{
		public int MovieID { get; set; }
		public int MovieCategoryID { get; set; }
		public MovieCategoryDetailEntity(int movieID, int movieCategoryID)
		{
			MovieID = movieID;
			MovieCategoryID = movieCategoryID;
		}
	}
}
